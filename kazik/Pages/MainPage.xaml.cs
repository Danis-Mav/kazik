using kazik.DB;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace kazik.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public int[] red = new int[18] {1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36};
        
        public decimal bet = 0;

        public string betStr = "";

        public static User user;
        public MainPage(User z)
        {
            InitializeComponent();
            user = z;
            lbBalance.DataContext = user.Balance;
            
        }

        private void btn10_Click(object sender, RoutedEventArgs e)
        {
            bet += 10;
            lbBet.Content = bet.ToString(); 
        }

        private void btn25_Click(object sender, RoutedEventArgs e)
        {
            bet += 25;
            lbBet.Content = bet.ToString();
        }

        private void btn50_Click(object sender, RoutedEventArgs e)
        {
            bet += 50;
            lbBet.Content = bet.ToString();
        }

        private void btn100_Click(object sender, RoutedEventArgs e)
        {
            bet += 100;
            lbBet.Content = bet.ToString();
        }

        private void btnX_Click(object sender, RoutedEventArgs e)
        {
            bet = 0;
            lbBet.Content = bet.ToString();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            int value = rnd.Next(0, 36);
            lbResult.Content = value.ToString();
            user.Balance -= bet;
            if (value == 0)
            {
                if (betStr == "Green")
                {
                    lbWinOrLose.Content = $"Win {bet * 50}";
                    user.Balance += bet * 50;
                }
                else lbWinOrLose.Content = "You loooooser";
            }
            else if (red.Contains(value))
            {
                if (betStr == "Red")
                {
                    lbWinOrLose.Content = $"Win {bet * 2}";
                    user.Balance += bet * 2;
                }
                else lbWinOrLose.Content = "You loooooser";
            }
            else
            {
                if (betStr == "Black")
                {
                    lbWinOrLose.Content = $"Win {bet * 2}";
                    user.Balance += bet * 2;
                }
                else lbWinOrLose.Content = "You loooooser";
            }
        }

        private void Red_Click(object sender, RoutedEventArgs e)
        {
            betStr = "Red";
        }

        private void Green_Click(object sender, RoutedEventArgs e)
        {
            betStr = "Green";
        }

        private void Black_Click(object sender, RoutedEventArgs e)
        {
            betStr = "Black";
        }
    }
}
