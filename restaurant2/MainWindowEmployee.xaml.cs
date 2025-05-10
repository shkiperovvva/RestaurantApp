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
    public partial class MainWindowEmployee : Window
    {
        public string CurrentUserEmail { get; set; }

        public MainWindowEmployee()
        {
            InitializeComponent();
        }

        public MainWindowEmployee(string email)
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

        public void ViewOrdersButton_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow orderWindow = new OrderWindow();
            orderWindow.Show();
        }

        public void PersonalAccountButton_Click(object sender, RoutedEventArgs e)
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
    }
}