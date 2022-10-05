using kazik.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public static ObservableCollection<User> Users { get; set; }
        public RegPage()
        {
            InitializeComponent();
        }

        private void Cancel_event(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AuthoPage());
        }

        private void Save_event(object sender, RoutedEventArgs e)
        {
            var nyms = new Regex(@"[0-9]");
            var symbols = new Regex(@"[!@#$%^]");
            var latinLetters = new Regex(@"[A-Z]");

            var matchesNum = nyms.IsMatch(txt_password.Password.ToString());
            var matchesSymb = symbols.IsMatch(txt_password.Password.ToString());
            var matchesLetters = latinLetters.IsMatch(txt_password.Password.ToString());

            if (matchesNum && matchesSymb && matchesLetters && txt_password.Password.ToString().Length >= 6)
            {
                try
                {
                    User a = new User
                    {
                        Login = txt_login.Text,
                        Password = txt_password.Password.ToString(),
                        Name = txt_name.Text,
                        Balance = 5000
                    };
                    DBconnection.DB.User.Add(a);
                    DBconnection.DB.SaveChanges();
                    MessageBox.Show("OK");
                    NavigationService.GoBack();
                }
                catch (Exception)
                {
                    throw new Exception("Error");
                }
            }
            else
            {
                MessageBox.Show("Придумай пароль получше");
            }
        }
    }
}
