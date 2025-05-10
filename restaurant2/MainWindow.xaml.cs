using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;

namespace restaurant2
{
    [Table("users", Schema = "restaurant")]
    public class Users
    {
        [Key]
        public int id_user { get; set; }
        public string name_user { get; set; }
        public string lastname_user { get; set; }
        public string email { get; set; }
        public string password_user { get; set; }
        public int role_user { get; set; }
        [ForeignKey("role_user")]
        public virtual User_Role Role { get; set; } 
    }


    [Table("user_role", Schema = "restaurant")]
    public class User_Role
    {
        [Key]
        public int id_role { get; set; }
        public string about_role { get; set; }
    }


    [Table("client", Schema = "restaurant")]
    public class Client
    {
        [Key]
        public int id_client { get; set; }
        public string name_client { get; set; }
        public string lastname_client { get; set; }
        public string email { get; set; }
        public string password_client { get; set; }
    }


    [Table("employee", Schema = "restaurant")]
    public class Employee
    {
        [Key]
        public int id_employee { get; set; }
        public string name_employee { get; set; }
        public string lastname_employee { get; set; }
        public string email { get; set; }
        public string password_employee { get; set; }

    }


    [Table("menu", Schema = "restaurant")]
    public class Menu
    {
        [Key]
        public int id_dish { get; set; }
        public string name_dish { get; set; }
        public string about_dish { get; set; }
        public decimal price { get; set; }
        public string category_gramme { get; set; } 
    }


    [Table("orders", Schema = "restaurant")]
    public class Orders
    {
        [Key]
        public int id_order { get; set; }
        public int id_client { get; set; }
        [ForeignKey("id_client")]
        public virtual Client Client { get; set; }

        public int? id_employee { get; set; }
        [ForeignKey("id_employee")]
        public virtual Employee Employee { get; set; }

        [Column(TypeName = "timestamp with time zone")]
        public DateTime date_order { get; set; } = DateTime.UtcNow;
        public string status_order { get; set; } = "в корзине";

        public virtual ICollection<Item_Order> Item_Orders { get; set; } = new List<Item_Order>();
    }



    [Table("item_order", Schema = "restaurant")]
    public class Item_Order
    {
        [Key]
        public int id_item { get; set; }

        public int id_order { get; set; }
        [ForeignKey("id_order")]
        public virtual Orders Order { get; set; } 

        public int id_dish { get; set; } 
        [ForeignKey("id_dish")]
        public virtual Menu Dish { get; set; } 

        public double quantity { get; set; }
        public double total_price { get; set; }
    }

    [Table("temp_cart", Schema = "restaurant")]
    public class TempCart
    {
        [Key]
        public int id_cart { get; set; }

        public int id_client { get; set; }
        [ForeignKey("id_client")]
        public virtual Client Client { get; set; }

        public int id_dish { get; set; }
        [ForeignKey("id_dish")]
        public virtual Menu Dish { get; set; }

        public double quantity { get; set; }
        public double total_price { get; set; }
        public DateTime created_at { get; set; }
    }
    public class ClientOrder
    {
        public long id_order { get; set; }
        public long id_client { get; set; }
        public long id_employee { get; set; }
        public string employee_name { get; set; }
        public DateTime date_order { get; set; }
        public string status_order { get; set; }
        public double total_price { get; set; }
        public List<OrderItem> items { get; set; } = new List<OrderItem>();
    }

    public class OrderItem
    {
        public long id_dish { get; set; }
        public string name_dish { get; set; }
        public double quantity { get; set; }
        public double total_price { get; set; }
    }


    public class RestaurantContext : DbContext
    {
        public static RestaurantContext _context;

        public static RestaurantContext GetContext()
        {
            if (_context == null) _context = new RestaurantContext();
            return _context;
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<User_Role> User_Role { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Item_Order> Item_Order { get; set; }
        public DbSet<TempCart> TempCart { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Host=172.20.7.53;Port=5432;Database=db2992_23;Username=st2992;Password=pwd2992");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>()
                .Property(m => m.category_gramme)
                .HasColumnType("jsonb");

            modelBuilder.Entity<Orders>()
                .HasMany(o => o.Item_Orders)
                .WithOne(io => io.Order)
                .HasForeignKey(io => io.id_order)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TempCart>()
                .HasOne(tc => tc.Client)
                .WithMany()
                .HasForeignKey(tc => tc.id_client);

            modelBuilder.Entity<TempCart>()
                .HasOne(tc => tc.Dish)
                .WithMany()
                .HasForeignKey(tc => tc.id_dish);
        }
    }
    public class Cart
    {
        public List<CartItem> Items { get; set; }

        public Cart()
        {
            Items = new List<CartItem>();
        }
    }

    public class CartItem
    {
        public Menu Dish { get; set; } 
        public int Quantity { get; set; }
        public decimal TotalCost => Dish.price * Quantity;

        public CartItem(Menu dish, int quantity)
        {
            Dish = dish;
            Quantity = quantity;
        }
    }
    public partial class MainWindow : Window
    {
        public Cart _cart;
        public string CurrentUserEmail { get; set; }
        private Orders _currentOrder;
        private int _currentClientId;

        public MainWindow(string email)
        {
            InitializeComponent();
            _cart = new Cart();
            CurrentUserEmail = email;
            LoadMenuData();

            using (var context = new RestaurantContext())
            {
                var client = context.Client.FirstOrDefault(c => c.email == email);
                if (client != null)
                {
                    _currentClientId = client.id_client;
                    LoadSavedCart(client.id_client);
                }
            }
        }

        private void LoadSavedCart(int clientId)
        {
            try
            {
                using (var context = new RestaurantContext())
                {
                    var savedItems = context.TempCart
                        .Include(tc => tc.Dish)
                        .Where(tc => tc.id_client == clientId)
                        .ToList();

                    foreach (var item in savedItems)
                    {
                        _cart.Items.Add(new CartItem(item.Dish, (int)item.quantity));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки корзины: {ex.Message}");
            }
        }


        private void LoadMenuData()
        {
            using (var context = new RestaurantContext())
            {
                MenuDataGrid.ItemsSource = context.Menu.ToList();
            }
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
        private void AddToCartButton_Click(object sender, RoutedEventArgs e)
        {
            if (_cart == null)
            {
                _cart = new Cart(); 
            }

            if (MenuDataGrid.SelectedItem is Menu selectedDish)
            {
                var existingItem = _cart.Items.FirstOrDefault(item => item.Dish.id_dish == selectedDish.id_dish);

                if (existingItem != null)
                {
                    existingItem.Quantity++;
                }
                else
                {
                    _cart.Items.Add(new CartItem(selectedDish, 1));
                }

                MessageBox.Show("Блюдо добавлено в корзину!", "Успех",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Выберите блюдо из меню!", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ViewCartButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(CurrentUserEmail))
            {
                MessageBox.Show("Сначала выполните вход в систему.");
                return;
            }

            using (var context = new RestaurantContext())
            {
                var client = context.Client.FirstOrDefault(c => c.email == CurrentUserEmail);
                if (client == null)
                {
                    MessageBox.Show("Клиент не найден.");
                    return;
                }
                _currentClientId = client.id_client;
                var cartWindow = new CartWindow(_cart, client.id_client);
                cartWindow.ShowDialog();

                if (cartWindow.DialogResult == true)
                {
                    _cart.Items.Clear();
                }
            }
        }
        private void ViewMyOrdersButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentClientId == 0)
            {
                MessageBox.Show("Сначала добавьте что-нибудь в корзину или оформите заказ.");
                return;
            }

            var ordersWindow = new ClientOrdersWindow(_currentClientId);
            ordersWindow.ShowDialog();
        }
    }
}
