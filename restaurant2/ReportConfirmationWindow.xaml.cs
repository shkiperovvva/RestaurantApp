using System;
using System.Diagnostics;
using System.Windows;

namespace restaurant2
{
    public partial class ReportConfirmationWindow : Window
    {
        private string _filePath;

        public ReportConfirmationWindow(string filePath)
        {
            InitializeComponent();
            _filePath = filePath;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ViewReportButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo(_filePath) { UseShellExecute = true });
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось открыть отчет: {ex.Message}");
            }
        }
    }
}
