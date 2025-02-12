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
    /// Interaction logic for Ikea.xaml
    /// </summary>
    public partial class Ikea : Window
    {
        public Player Player { get; private set; }
        public Ikea(Player player)
        {
            Player = player;
            InitializeComponent();
            if (Player.ItemStatus["sofa"] == true)
            {
                SofaBuy.IsEnabled = false;
            }
            if (Player.ItemStatus["cabinet"] == true)
            {
                CabinetBuy.IsEnabled = false;
            }
            if (Player.ItemStatus["bed"] == true)
            {
                BedBuy.IsEnabled = false;
            }


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
          
        }

        private void CabinetBuy_Click(object sender, RoutedEventArgs e)
        {


                Player.ItemStatus["cabinet"] = true;
                lblIkeaText.Content = "Vásároltál egy ruhásszekrényt!";

           

        }

        private void BedBuy_Click(object sender, RoutedEventArgs e)
        {
    

                Player.ItemStatus["bed"] = true;
                lblIkeaText.Content = "Vásároltál egy ágyat!";

            
        }
    }
}
