using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.EntityFrameworkCore;
using System.Windows.Data;
using System.Globalization;

namespace restaurant2
{
    public partial class OrderWindow : Window
    {
        public ObservableCollection<OrderViewModel> Orders { get; set; }
        public ObservableCollection<OrderViewModel> FilteredOrders { get; set; }
        public ICommand ChangeStatusCommand { get; private set; }

        public OrderWindow()
        {
            InitializeComponent();
            Orders = new ObservableCollection<OrderViewModel>();
            FilteredOrders = new ObservableCollection<OrderViewModel>();
            ChangeStatusCommand = new RelayCommand(ChangeStatus);
            DataContext = this;
            LoadOrdersData();
        }

        private void LoadOrdersData()
        {
            try
            {
                using (var context = new RestaurantContext())
                {
                    var orderGroups = context.Item_Order
                        .Include(io => io.Order)
                        .ThenInclude(o => o.Client)
                        .Include(io => io.Order)
                        .ThenInclude(o => o.Employee)
                        .Include(io => io.Dish)
                        .GroupBy(io => io.Order.id_order)
                        .Select(group => new
                        {
                            OrderId = group.Key,
                            Items = group.ToList()
                        })
                        .ToList();

                    Orders.Clear();

                    foreach (var orderGroup in orderGroups)
                    {
                        var firstItem = orderGroup.Items.First();
                        var orderViewModel = new OrderViewModel
                        {
                            id_order = firstItem.Order.id_order,
                            client_name = firstItem.Order.Client.name_client + " " + firstItem.Order.Client.lastname_client,
                            employee_name = firstItem.Order.Employee?.name_employee + " " + firstItem.Order.Employee?.lastname_employee,
                            date_order = firstItem.Order.date_order,
                            status_order = firstItem.Order.status_order,
                            Items = new ObservableCollection<ItemViewModel>(orderGroup.Items.Select(io => new ItemViewModel
                            {
                                name_dish = io.Dish.name_dish,
                                quantity = io.quantity,
                                total_price = io.total_price
                            })),
                            TotalOrderPrice = orderGroup.Items.Sum(io => io.total_price)
                        };
                        Orders.Add(orderViewModel);
                    }

                    ApplyFilter(null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
            }
        }

        private void StatusFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox && comboBox.SelectedItem is ComboBoxItem selectedItem && selectedItem.Content != null)
            {
                string filterValue = selectedItem.Content.ToString();
                ApplyFilter(filterValue == "Все статусы" ? null : filterValue);
            }
        }


        private void ApplyFilter(string statusFilter)
        {
            if (FilteredOrders == null)
                FilteredOrders = new ObservableCollection<OrderViewModel>();

            FilteredOrders.Clear();

            if (Orders != null)
            {
                var filteredCollection = statusFilter == null
                    ? Orders
                    : Orders.Where(o => o.status_order != null && o.status_order.Equals(statusFilter, StringComparison.OrdinalIgnoreCase));

                foreach (var order in filteredCollection)
                    FilteredOrders.Add(order);
            }

            if (OrdersItemsControl != null)
                OrdersItemsControl.ItemsSource = FilteredOrders;
        }



        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ChangeStatus(object parameter)
        {
            if (parameter is OrderViewModel order)
            {
                var editWindow = new EditStatusWindow(order.status_order)
                {
                    Owner = this
                };

                if (editWindow.ShowDialog() == true)
                {
                    string newStatus = editWindow.SelectedStatus;
                    if (newStatus != order.status_order)
                    {
                        try
                        {
                            using (var context = new RestaurantContext())
                            {
                                var orderToUpdate = context.Orders.FirstOrDefault(o => o.id_order == order.id_order);
                                if (orderToUpdate != null)
                                {
                                    orderToUpdate.status_order = newStatus;
                                    context.SaveChanges();

                                    order.status_order = newStatus;

                                    MessageBox.Show("Статус заказа успешно обновлен.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Заказ не найден в базе данных.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка при обновлении статуса: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
        }
    }

    public class OrderViewModel : INotifyPropertyChanged
    {
        public int id_order { get; set; }
        public string client_name { get; set; }
        public string employee_name { get; set; }
        public DateTime date_order { get; set; }

        private string _status_order;
        public string status_order
        {
            get => _status_order;
            set
            {
                if (_status_order != value)
                {
                    _status_order = value;
                    OnPropertyChanged(nameof(status_order));
                    OnPropertyChanged(nameof(StatusColor));
                }
            }
        }

        public Brush StatusColor => _status_order?.ToLower() switch
        {
            "начат" => Brushes.Red,
            "готов" => Brushes.Green,
            "оформлен" => Brushes.Orange,
            _ => Brushes.LightGray
        };

        public ObservableCollection<ItemViewModel> Items { get; set; }
        public double TotalOrderPrice { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }

    public class ItemViewModel
    {
        public string name_dish { get; set; }
        public double quantity { get; set; }
        public double total_price { get; set; }
    }

    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute ?? throw new ArgumentNullException("execute");
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}