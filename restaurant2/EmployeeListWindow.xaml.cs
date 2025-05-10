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

namespace restaurant2
{
    public partial class EmployeeListWindow : Window
    {
        public EmployeeListWindow()
        {
            InitializeComponent();
            LoadEmployeesData();
        }

        private void LoadEmployeesData()
        {
            using (var context = new RestaurantContext())
            {
                EmployeesDataGrid.ItemsSource = context.Employee.ToList();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DeleteEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeesDataGrid.SelectedItem is Employee selectedEmployee)
            {
                MessageBoxResult result = MessageBox.Show(
                    $"Удалить сотрудника {selectedEmployee.name_employee} {selectedEmployee.lastname_employee}?",
                    "Подтверждение удаления",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        using (var context = new RestaurantContext())
                        {
                            context.Employee.Remove(selectedEmployee);
                            var userToRemove = context.Users.FirstOrDefault(u => u.email == selectedEmployee.email);
                            if (userToRemove != null)
                            {
                                context.Users.Remove(userToRemove);
                            }

                            context.SaveChanges();
                        }
                        LoadEmployeesData();

                        MessageBox.Show("Сотрудник успешно удалён из employee и users", "Успех",
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
                MessageBox.Show("Выберите сотрудника для удаления", "Предупреждение",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new EmployeeAddWindow();
            if (addWindow.ShowDialog() == true)
            {
                LoadEmployeesData();
            }
        }
    }
}