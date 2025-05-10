using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace restaurant2
{
    public partial class EmployeeSelectionWindow : Window
    {
        public Employee SelectedEmployee { get; private set; }

        public EmployeeSelectionWindow(IEnumerable<Employee> employees)
        {
            InitializeComponent();
            EmployeesComboBox.ItemsSource = employees;
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedEmployee = EmployeesComboBox.SelectedItem as Employee;
            if (SelectedEmployee != null)
            {
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите сотрудника", "Ошибка",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}