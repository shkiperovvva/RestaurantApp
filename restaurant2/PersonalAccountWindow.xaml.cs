using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace restaurant2
{
    public partial class PersonalAccountWindow : Window
    {
        public PersonalAccountWindow(Users user)
        {
            InitializeComponent();
            LoadUserData(user);

            if (this.FindName("LogOutButton") is Button logOutButton)
            {
                logOutButton.Click += LogOutButton_Click;
            }
        }

        private void LoadUserData(Users user)
        {
            NameTextBlock.Text = user.name_user;
            LastNameTextBlock.Text = user.lastname_user;
            EmailTextBlock.Text = user.email;

            RoleTextBlock.Text = user.role_user switch
            {
                1 => "Клиент",
                2 => "Сотрудник",
                3 => "Администратор системы",
                _ => "Неизвестная роль"
            };
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                foreach (Window window in Application.Current.Windows.OfType<Window>().ToList())
                {
                    if (window != this)
                        window.Close();
                }
                this.Close();
            }
        }
    }
}
