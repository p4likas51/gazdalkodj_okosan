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
    /// Interaction logic for Steal.xaml
    /// </summary>
    public partial class Steal : Window
    {
        public Player Player { get; private set; }

        public Steal(Player player)
        {
            Player = player;
            InitializeComponent();
            if (Player.ItemStatus["tv"] == true || Player.ItemStatus["house"] == false)
            {
                btnStealTv.IsEnabled = false;
            }
            if (Player.ItemStatus["oven"] == true || Player.ItemStatus["house"] == false)
            {
                btnStealOven.IsEnabled = false;
            }
            if (Player.ItemStatus["cabinet"] == true || Player.ItemStatus["house"] == false)
            {
                btnStealCabinet.IsEnabled = false;
            }
            if (Player.ItemStatus["bed"] == true || Player.ItemStatus["house"] == false)
            {
                btnStealBed.IsEnabled = false;
            }
            if (Player.ItemStatus["lego"] == true || Player.ItemStatus["house"] == false)
            {
                btnStealLego.IsEnabled = false;
            }
            if (Player.ItemStatus["washingmachine"] == true || Player.ItemStatus["house"] == false)
            {
                btnStealWashing.IsEnabled = false;
            }
            if (Player.ItemStatus["sofa"] == true || Player.ItemStatus["house"] == false)
            {
                btnStealSofa.IsEnabled = false;
            }

            Dictionary<Border, string> kepek = new Dictionary<Border, string>()
            {
                { stealIcon, "rablas.jpg" },
                { stealIcon2, "rablas.jpg" }
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

        private void btnStealTv_Click(object sender, RoutedEventArgs e)
        {
            Player.ItemStatus["tv"] = true;
            lblStealText.Content = "Lopattál egy televíziót!";
            DialogResult = true;
            Close();
        }

        private void btnStealOven_Click(object sender, RoutedEventArgs e)
        {
            Player.ItemStatus["oven"] = true;
            lblStealText.Content = "Lopattál egy sütőt!";
            DialogResult = true;
            Close();
        }

        private void btnStealCabinet_Click(object sender, RoutedEventArgs e)
        {

            Player.ItemStatus["cabinet"] = true;
            lblStealText.Content = "Lopattál egy ruhásszekrényt!";
            DialogResult = true;
            Close();
        }

        private void btnStealBed_Click(object sender, RoutedEventArgs e)
        {
            Player.ItemStatus["bed"] = true;
            lblStealText.Content = "Lopattál egy ágyat!";
            DialogResult = true;
            Close();

        }

        private void btnStealLego_Click(object sender, RoutedEventArgs e)
        {
            Player.ItemStatus["lego"] = true;
            lblStealText.Content = "Lopattál egy LEGO-t!";
            DialogResult = true;
            Close();

        }

        private void btnStealSofa_Click(object sender, RoutedEventArgs e)
        {

            Player.ItemStatus["sofa"] = true;
            lblStealText.Content = "Lopattál egy kanapét!";
            DialogResult = true;
            Close();
        }

        private void btnStealWashing_Click(object sender, RoutedEventArgs e)
        {
            Player.ItemStatus["washingmachine"] = true;
            lblStealText.Content = "Lopattál egy mosógépet!";
            DialogResult = true;
            Close();

        }
    }
}
