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
    /// Interaction logic for freeCar.xaml
    /// </summary>
    public partial class freeCar : Window
    {
        public Player Player { get; private set; }

        public freeCar(Player player)
        {
            Player = player;

            InitializeComponent();
            if (player.ItemStatus["car"] == true || player.ItemStatus["house"] == false)
            {
                acceptCar.IsEnabled = false;
            }

            Dictionary<Border, string> kepek = new Dictionary<Border, string>()
            {
                { brdCarBuy, "auto.png" },
                { getCar, "garazs.jpg" }
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

        private void acceptCar_Click(object sender, RoutedEventArgs e)
        {
            Player.ItemStatus["car"] = true;
            DialogResult = true;
            Close();

        }



        private void sellCar_Click(object sender, RoutedEventArgs e)
        {
            Player.Balance += 10000;
            DialogResult = true;
            Close();
        }
    }
}
