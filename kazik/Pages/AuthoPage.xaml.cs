using kazik.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace kazik.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthoPage.xaml
    /// </summary>
    public partial class AuthoPage : Page
    {
        public static ObservableCollection<User> users { get; set; }
        public AuthoPage()
        {
            InitializeComponent();
            Login_txt.Text = Properties.Settings.Default.Login;

            DataContext = this;
        }

        private void AuthoButton(object sender, RoutedEventArgs e)
        {
            users = new ObservableCollection<User>(DBconnection.DB.User.ToList());
            var k = users.Where(a => a.Login == Login_txt.Text && a.Password == Password_txt.Password).FirstOrDefault();
            if (k != null)
            {
                if (safe_chbx.IsChecked.GetValueOrDefault())
                {
                    Properties.Settings.Default.Login = Login_txt.Text;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.Login = null;
                    Properties.Settings.Default.Save();
                }
                NavigationService.Navigate(new Pages.MainPage(k));
            }
            else MessageBox.Show("Логин или пароль введены неверно", "error", MessageBoxButton.OK, MessageBoxImage.Error);

            DataContext = this;
        }

        private void RegButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.RegPage());
        }
    }
}
