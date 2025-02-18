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
    /// Interaction logic for CarMarket.xaml
    /// </summary>
    public partial class CarMarket : Window
    {
        private double Amount;
        public Player Player;
        public string Item { get; set; }
        public CarMarket(Player player, string item)
        {
            InitializeComponent();
 

            Player = player;
            Item = item;
            Dictionary<Border, string> kepek = new Dictionary<Border, string>()
            {
                {borderCar, "auto.png" },
                {borderHouse, "haz.jpg" }
                
            };
            Loaded += (sender, e) =>
            {
                foreach (var kep in kepek)
                {
                    var path = System.IO.Path.Combine(Environment.CurrentDirectory, "images", kep.Value);
                    ImageSource src = new BitmapImage(new Uri(path, UriKind.Absolute));
                    kep.Key.Background = new ImageBrush(src);
                }
            };
            if (Item == "car")
            {
                borderHouse.Visibility = Visibility.Collapsed;
                lblTitle.Content = "Autó vásárlás";
                Amount = player.ItemPrices["car"];
                lblCarBuy.Content = $"Összeg: -{Amount}Ft";
                if (player.Balance >= Amount && player.ItemStatus["house"] == true && player.ItemStatus["car"] == false) btnCarBuy.IsEnabled = true;
            }
            if (Item == "house")
            {
                borderCar.Visibility = Visibility.Collapsed;
                lblTitle.Content = "Ház vásárlás";
                Amount = player.ItemPrices["house"];
                lblCarBuy.Content = $"Összeg: {Amount}Ft";
                if (player.Balance >= Amount && player.ItemStatus["house"] == false) btnCarBuy.IsEnabled = true;
            }
        }

        private void btnCarBuy_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            btn.IsEnabled = false;
            Player.Balance -= Amount;
            if (Item == "car")
            {
                Player.ItemStatus["car"] = true;
                Player.DiscountCar = 1;
            }
            if (Item == "house")
            {
                Player.ItemStatus["house"] = true;
                Player.DiscountHouse = 1;
            }

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
