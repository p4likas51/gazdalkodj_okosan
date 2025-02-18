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

namespace gazdalkodjOkosan
{
    /// <summary>
    /// Interaction logic for Jail.xaml
    /// </summary>
    public partial class Jail : Window
    {
        private int amount = 15000;
        public bool OutOfJail { get; private set; }
        public Player Player { get; private set; }
        public Jail(Player player)
        {
            InitializeComponent();
            Player = player;
            if (Player.Balance >= amount) btnPayJail.IsEnabled = true;
            lblAmount.Content = $"-{amount}Ft";
        }

        private void btnRollJail_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            btn.IsEnabled = false;
            Random random = new Random();
            var diceRoll = random.Next(1, 7);
            lblRoll.Content = $"A dobásod: {diceRoll}";
            btnExit.Visibility = Visibility.Visible;
            if (diceRoll == 6) OutOfJail = true;
            else OutOfJail = false;
        }

        private void btnPayJail_Click(object sender, RoutedEventArgs e)
        {
            if (Player.Balance >= amount)
            {
                Player.Balance -= amount;
                OutOfJail = true;
                DialogResult = true;
                Close();
            }
            else OutOfJail = false;

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
