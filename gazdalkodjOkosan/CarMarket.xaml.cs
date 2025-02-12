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
        private int Amount;
        public Player Player;
        public CarMarket(Player player)
        {
            InitializeComponent();
            Player = player;
            Dictionary<Border, string> kepek = new Dictionary<Border, string>()
            {
                {borderCar, "auto.png" }
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
            Amount = player.ItemPrices["car"];
            lblCarBuy.Content = $"-{Amount}";
            MessageBox.Show($"auto ara: {Amount}");
            if (player.Balance >= Amount) btnCarBuy.IsEnabled = true;
        }

        private void btnCarBuy_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            btn.IsEnabled = false;
            Player.Balance -= Amount;
            Player.ItemStatus["car"] = true;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
