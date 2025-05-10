using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace restaurant2
{
    public partial class CartWindow : Window
    {
        private Cart _cart;
        private int _idClient;
        private RestaurantContext _context;

        public CartWindow(Cart cart, int idClient)
        {
            InitializeComponent();
            _cart = cart;
            _idClient = idClient;
            _context = RestaurantContext.GetContext();
            DataContext = _cart;
            CartDataGrid.ItemsSource = _cart.Items;
            AddDeleteButtonColumn();
        }
        private void AddDeleteButtonColumn()
        {
            var deleteColumn = new DataGridTemplateColumn
            {
                Header = "Действие",
                Width = 100
            };

            var deleteButtonFactory = new FrameworkElementFactory(typeof(Button));
            deleteButtonFactory.SetValue(ContentProperty, "Удалить");
            deleteButtonFactory.SetValue(Button.StyleProperty, FindResource("RoundedButtonStyle"));
            deleteButtonFactory.AddHandler(Button.ClickEvent, new RoutedEventHandler(DeleteItem_Click));

            deleteColumn.CellTemplate = new DataTemplate
            {
                VisualTree = deleteButtonFactory
            };

            CartDataGrid.Columns.Add(deleteColumn);
        }

        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            if (CartDataGrid.SelectedItem is CartItem selectedItem)
            {
                _cart.Items.Remove(selectedItem);
                CartDataGrid.Items.Refresh();
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            SaveCartToDatabase();
            base.OnClosed(e);
        }

        private void SaveCartToDatabase()
        {
            try
            {
                using (var context = new RestaurantContext())
                {
                    // Удаляем старую корзину
                    context.TempCart.RemoveRange(context.TempCart.Where(tc => tc.id_client == _idClient));

                    // Сохраняем новую
                    foreach (var item in _cart.Items)
                    {
                        context.TempCart.Add(new TempCart
                        {
                            id_client = _idClient,
                            id_dish = item.Dish.id_dish,
                            quantity = item.Quantity,
                            total_price = (double)item.TotalCost
                        });
                    }

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения корзины: {ex.Message}");
            }
        }

        private void PlaceOrder_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateCart()) return;

            var employees = _context.Employee.ToList();
            if (!employees.Any())
            {
                MessageBox.Show("Нет доступных сотрудников!", "Ошибка",
                              MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var selectionWindow = new EmployeeSelectionWindow(employees)
            {
                Owner = this
            };

            if (selectionWindow.ShowDialog() == true)
            {
                ProcessOrder(selectionWindow.SelectedEmployee.id_employee);
            }
        }

        private bool ValidateCart()
        {
            if (!_cart.Items.Any())
            {
                MessageBox.Show("Корзина пуста!", "Ошибка",
                              MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private void ProcessOrder(int employeeId)
        {
            try
            {
                PlaceOrderInDatabase(employeeId);
                MessageBox.Show("Заказ успешно оформлен!", "Успех");
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка");
            }
        }

        private void PlaceOrderInDatabase(int idEmployee)
        {
            using (var conn = _context.Database.GetDbConnection())
            {
                conn.Open();

                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Оформление заказа
                        using (var cmd = conn.CreateCommand())
                        {
                            cmd.Transaction = transaction;
                            cmd.CommandText = "CALL restaurant.place_order(@p_id_client, @p_id_employee, @p_dish_ids, @p_quantities, @p_total_prices)";

                            cmd.Parameters.Add(new NpgsqlParameter("p_id_client", _idClient));
                            cmd.Parameters.Add(new NpgsqlParameter("p_id_employee", idEmployee));
                            cmd.Parameters.Add(new NpgsqlParameter("p_dish_ids", _cart.Items.Select(i => i.Dish.id_dish).ToArray()));
                            cmd.Parameters.Add(new NpgsqlParameter("p_quantities", _cart.Items.Select(i => i.Quantity).ToArray()));
                            cmd.Parameters.Add(new NpgsqlParameter("p_total_prices", _cart.Items.Select(i => i.TotalCost).ToArray()));

                            cmd.ExecuteNonQuery();
                        }

                        // Очистка корзины после оформления
                        using (var cmd = conn.CreateCommand())
                        {
                            cmd.Transaction = transaction;
                            cmd.CommandText = "SELECT restaurant.clear_temp_cart(@client_id)";
                            cmd.Parameters.Add(new NpgsqlParameter("client_id", _idClient));
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("Ошибка при оформлении заказа: " + ex.Message);
                    }
                }
            }
        }

        private void IncreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as System.Windows.Controls.Button)?.Tag is CartItem item)
            {
                item.Quantity++;
                CartDataGrid.Items.Refresh();
            }
        }

        private void DecreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as System.Windows.Controls.Button)?.Tag is CartItem item && item.Quantity > 1)
            {
                item.Quantity--;
                CartDataGrid.Items.Refresh();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
        private void ClearCart_Click(object sender, RoutedEventArgs e)
        {
            _cart.Items.Clear();
            CartDataGrid.Items.Refresh();
        }
    }
}
