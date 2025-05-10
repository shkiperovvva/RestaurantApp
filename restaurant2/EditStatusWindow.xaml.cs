using System.Collections.Generic;
using System.Windows;

namespace restaurant2
{
    public partial class EditStatusWindow : Window
    {
        public string SelectedStatus { get; private set; }

        public readonly List<string> _availableStatuses = new List<string> { "оформлен", "начат", "готов" };

        public EditStatusWindow(string currentStatus)
        {
            InitializeComponent();

            StatusComboBox.ItemsSource = _availableStatuses;
            StatusComboBox.SelectedItem = currentStatus;
        }

        public void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (StatusComboBox.SelectedItem != null)
            {
                SelectedStatus = StatusComboBox.SelectedItem.ToString();
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите статус.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
