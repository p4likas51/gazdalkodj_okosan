using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
    /// Interaction logic for CarInsurance.xaml
    /// </summary>
    public partial class CarInsurance : Window
    {
        private double Amount;
        private string Type;
        public Player Player { get; private set; }

        public CarInsurance(Player player, string type)
        {
            InitializeComponent();
            Player = player;
            Type = type.ToLower();
            if (Type == "car")
            {
                Amount = player.ItemPrices["carInsurance"];
                lblTitle.Content = "Gépjármű biztosítás";
            }
             else if (Type == "house")
            {
                Amount = player.ItemPrices["houseInsurance"];
                lblTitle.Content = "Házbiztosítás";
            }
            if(Type == "car")
            {
                if (Player.Balance >= Amount && Player.ItemStatus["car"] == true) btnCarInsurance.IsEnabled = true;

            }
            if(Type == "house")
            {
                if (Player.Balance >= Amount && Player.ItemStatus["house"] == true) btnCarInsurance.IsEnabled = true;

            }
            lblAmount.Content = $"-{Amount}";
        }

        private void btnCarInsurance_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            btn.IsEnabled = false;
            if (Player.Balance >= Amount)
            {
                Player.Balance -= Amount;
            }
            lblAmount.Content = "Sikeres biztosítás vásárlás!";
            if (Type.ToLower() == "car") Player.ItemStatus["carInsurance"] = true;
            if (Type.ToLower() == "house") Player.ItemStatus["houseInsurance"] = true;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
