using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
    /// Interaction logic for Ikea.xaml
    /// </summary>
    public partial class Ikea : Window
    {
        public Player Player { get; private set; }
        public Ikea(Player player)
        {
            Player = player;
            InitializeComponent();
            if (Player.ItemStatus["sofa"] == true || player.Balance < player.ItemPrices["sofa"] || player.ItemStatus["house"] == false)
            {
                SofaBuy.IsEnabled = false;
            }
            if (Player.ItemStatus["cabinet"] == true || player.Balance < player.ItemPrices["cabinet"] || player.ItemStatus["house"] == false)
            {
                CabinetBuy.IsEnabled = false;
            }
            if (Player.ItemStatus["bed"] == true || player.Balance < player.ItemPrices["bed"] || player.ItemStatus["house"] == false)
            {
                BedBuy.IsEnabled = false;
            }

            lblSofa.Content = $"Kanapé - {player.ItemPrices["sofa"]}Ft";
            lblBed.Content = $"Ágy - {player.ItemPrices["bed"]}Ft";
            lblCabinet.Content = $"Szekrény - {player.ItemPrices["cabinet"]}Ft";

            Dictionary<Border, string> kepek = new Dictionary<Border, string>()
            {
                { Ikeabackground, "ikeabelter.jpg" },
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



        private void SofaBuy_Click(object sender, RoutedEventArgs e)
        {

       
             Player.ItemStatus["sofa"] = true;

             lblIkeaText.Content = "Vásároltál egy kanapét!";
            Player.Balance -= Player.ItemPrices["sofa"];
            Player.DiscountItems = 1;
            DialogResult = true;
            Close();

        }

        private void CabinetBuy_Click(object sender, RoutedEventArgs e)
        {


                Player.ItemStatus["cabinet"] = true;
                lblIkeaText.Content = "Vásároltál egy ruhásszekrényt!";
            Player.Balance -= Player.ItemPrices["cabinet"];
            Player.DiscountItems = 1;
            DialogResult = true;
            Close();


        }

        private void BedBuy_Click(object sender, RoutedEventArgs e)
        {
    

                Player.ItemStatus["bed"] = true;
                lblIkeaText.Content = "Vásároltál egy ágyat!";
            Player.Balance -= Player.ItemPrices["bed"];
            Player.DiscountItems = 1;
            DialogResult = true;
            Close();

        }
    }
}
