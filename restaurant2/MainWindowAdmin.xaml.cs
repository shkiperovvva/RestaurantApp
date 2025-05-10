using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;

namespace restaurant2
{
    public partial class MainWindowAdmin : Window
    {
        public string CurrentUserEmail { get; set; }

        public MainWindowAdmin()
        {
            InitializeComponent();
            LoadMenuData();
        }

        public MainWindowAdmin(string email)
        {
            InitializeComponent();
            CurrentUserEmail = email;
            LoadMenuData();
        }

        private void LoadMenuData()
        {
            using (var context = new RestaurantContext())
            {
                MenuDataGrid.ItemsSource = context.Menu.ToList();
            }
        }

        public void ViewEmployeesButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeListWindow employeeListWindow = new EmployeeListWindow();
            employeeListWindow.Show();
        }

        private void DeleteItemButton_Click(object sender, RoutedEventArgs e)
        {
            if (MenuDataGrid.SelectedItem is Menu selectedItem)
            {
                MessageBoxResult result = MessageBox.Show(
                    $"Удалить позицию '{selectedItem.name_dish}' из меню?",
                    "Подтверждение удаления",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        using (var context = new RestaurantContext())
                        {
                            context.Menu.Remove(selectedItem);
                            context.SaveChanges();
                        }

                        LoadMenuData();
                        MessageBox.Show("Позиция успешно удалена", "Успех",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите позицию для удаления", "Предупреждение",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void AddItemButton_Click(object sender, RoutedEventArgs e)
        {
            AddItemWindow addItemWindow = new AddItemWindow();
            addItemWindow.ShowDialog();
            LoadMenuData();
        }

        private void PersonalAccountButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(CurrentUserEmail))
            {
                using (var context = new RestaurantContext())
                {
                    var user = context.Users
                        .Include(u => u.Role)
                        .FirstOrDefault(u => u.email == CurrentUserEmail);

                    if (user != null)
                    {
                        var personalAccountWindow = new PersonalAccountWindow(user);
                        personalAccountWindow.Show();
                    }
                    else
                    {
                        MessageBox.Show("Пользователь не найден.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Сначала выполните вход в систему.");
            }
        }

        private void GenerateReportsButton_Click(object sender, RoutedEventArgs e)
        {
            ReportGenerationWindow reportGenerationWindow = new ReportGenerationWindow();
            reportGenerationWindow.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        public void ViewClientButton_Click(object sender, RoutedEventArgs e)
        {
            ClientListWindow clientListWindow = new ClientListWindow();
            clientListWindow.Show();
        }
    }
}