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
    /// Interaction logic for Lego.xaml
    /// </summary>
    public partial class Lego : Window
    {
        public Player Player { get; private set; }

        public Lego(Player player)
        {
            Player = player;
            InitializeComponent();

            if (Player.ItemStatus["lego"] == true || player.Balance < player.ItemPrices["lego"] || player.ItemStatus["house"] == false)
            {
                btnLegoBuy.IsEnabled = false;
            }

                Dictionary<Border, string> kepek = new Dictionary<Border, string>()
            {
                { LegoBackground, "regiouzlet.jpg" },
                { legoBuy, "lego.png" }
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Player.ItemStatus["lego"] = true;

            lblLegoText.Content = "Vásároltál egy LEGO-t!";
            Player.Balance -= Player.ItemPrices["lego"];
            Player.DiscountItems = 1;
            DialogResult = true;
            Close();


        }
    }
}
