using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using Microsoft.EntityFrameworkCore;

namespace restaurant2
{
    public partial class ClientOrdersWindow : Window
    {
        private readonly int _clientId;
        public ObservableCollection<OrderViewModel> Orders { get; set; }

        public ClientOrdersWindow(int clientId)
        {
            InitializeComponent();
            _clientId = clientId;
            Orders = new ObservableCollection<OrderViewModel>();
            DataContext = this;
            LoadClientOrders();
        }

        private void LoadClientOrders()
        {
            try
            {
                using (var context = new RestaurantContext())
                {
                    var ordersData = context.Orders
                        .Where(o => o.id_client == _clientId)
                        .Include(o => o.Item_Orders)
                        .ThenInclude(io => io.Dish)
                        .Include(o => o.Employee)
                        .ToList();

                    var orderGroups = ordersData
                        .GroupBy(o => o.id_order)
                        .Select(g => new
                        {
                            Order = g.First(),
                            Items = g.SelectMany(o => o.Item_Orders.Select(io => new
                            {
                                io.Dish.name_dish,
                                io.quantity,
                                io.total_price
                            }))
                        })
                        .ToList();

                    Orders.Clear();

                    foreach (var group in orderGroups)
                    {
                        var order = group.Order;
                        var orderViewModel = new OrderViewModel
                        {
                            id_order = order.id_order,
                            client_name = order.Client?.name_client + " " + order.Client?.lastname_client,
                            employee_name = order.Employee?.name_employee + " " + order.Employee?.lastname_employee,
                            date_order = order.date_order,
                            status_order = order.status_order,
                            Items = new ObservableCollection<ItemViewModel>(group.Items.Select(i => new ItemViewModel
                            {
                                name_dish = i.name_dish,
                                quantity = i.quantity,
                                total_price = i.total_price
                            })),
                            TotalOrderPrice = group.Items.Sum(i => i.total_price)
                        };
                        Orders.Add(orderViewModel);
                    }

                    OrdersItemsControl.ItemsSource = Orders;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке заказов: {ex.Message}", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        public class OrderViewModel : INotifyPropertyChanged
        {
            public int id_order { get; set; }
            public string client_name { get; set; }
            public string employee_name { get; set; }
            public DateTime date_order { get; set; }
            public string status_order { get; set; }
            public ObservableCollection<ItemViewModel> Items { get; set; }
            public double TotalOrderPrice { get; set; }

            public Brush StatusColor => status_order?.ToLower() switch
            {
                "начат" => Brushes.Red,
                "готов" => Brushes.Green,
                "оформлен" => Brushes.Orange,
                _ => Brushes.LightGray
            };

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
    }
}