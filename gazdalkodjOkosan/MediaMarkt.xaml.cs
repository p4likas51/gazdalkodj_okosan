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
    /// Interaction logic for MediaMarkt.xaml
    /// </summary>
    public partial class MediaMarkt : Window
    {
        public Player Player { get; private set; }
        public MediaMarkt(Player player)
        {
            InitializeComponent();
            Player = player;

            if (Player.ItemStatus["tv"] == true || Player.Balance < Player.ItemPrices["tv"] || Player.ItemStatus["house"] == false)
            {
                TvBuy.IsEnabled = false;
            }
            if (Player.ItemStatus["oven"] == true || Player.Balance < Player.ItemPrices["oven"] || Player.ItemStatus["house"] == false)
            {
                OvenBuy.IsEnabled = false;
            }
            if (Player.ItemStatus["washingmachine"] == true || Player.Balance < Player.ItemPrices["washingmachine"] || Player.ItemStatus["house"] == false)
            {
                WashingmachineBuy.IsEnabled = false;
            }

            Dictionary<Border, string> kepek = new Dictionary<Border, string>()
            {
                { MediaBackground, "mediabelter.jpg" },
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
        }

        private void TvBuy_Click(object sender, RoutedEventArgs e)
        {
            Player.ItemStatus["tv"] = true;
            lblMediaText.Content = "Vásároltál egy televíziót!";
            Player.Balance -= Player.ItemPrices["tv"];
            Player.DiscountItems = 1;
            DialogResult = true;
            Close();
        }

        private void OvenBuy_Click(object sender, RoutedEventArgs e)
        {
            Player.ItemStatus["oven"] = true;
            lblMediaText.Content = "Vásároltál egy sütőt!";
            Player.Balance -= Player.ItemPrices["oven"];
            Player.DiscountItems = 1;
            DialogResult = true;
            Close();

        }

        private void WashingmachineBuy_Click(object sender, RoutedEventArgs e)
        {
            Player.ItemStatus["washingmachine"] = true;
            lblMediaText.Content = "Vásároltál egy mosógépet!";
            Player.Balance -= Player.ItemPrices["washingmachine"];
            Player.DiscountItems = 1;
            DialogResult = true;
            Close();

        }
    }
}
