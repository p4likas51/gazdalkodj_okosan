using System.IO;
using System.Numerics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace gazdalkodjOkosan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Player player1 = new Player("player1", Brushes.Red);
        public MainWindow()
        {
            InitializeComponent();

            Dictionary<Border, string> kepek = new Dictionary<Border, string>()
            {
                { borderIkea, "Ikea_logo.svg.png" },
                { borderIkea2, "Ikea_logo.svg.png" },
                { borderRacsok, "racsok.jpg" },
                { borderSzerencse, "szerencse.png" },
                { borderSzerencse2, "szerencse.png" },
                { borderSzerencse3, "szerencse.png" },
                { borderSzerencse4, "szerencse.png" },
                { borderHazvasarlas, "hazvasarlas.jpg" },
                { borderAutovasarlas, "autovasarlas.jpg" },
                { borderBiztositas1, "hazbiztositas.jpg" },
                { borderBiztositas2, "autobiztositas.jfif" },
                { borderAllatkert, "allatkert.jpg" },
                { borderVidampark, "vidampark.jpg" },
                { borderJatekbolt, "regio.png" },
                { borderMav, "máv-logo(utazó mező).png" },
                { borderHev, "hev.png" },
                { borderBkv, "bkv.png" },
                { borderRablas, "kiraboltak-bunozo(penzveszto mezo).png" },




            };

            Loaded += (sender, e) =>
            {
                GameGrid.Children.Add(player1.Shape);
                Grid.SetRow(player1.Shape, player1.Row);
                Grid.SetColumn(player1.Shape, player1.Column);

                foreach (var kep in kepek)
                {
                    var path = System.IO.Path.Combine(Environment.CurrentDirectory, kep.Value);
                    ImageSource src = new BitmapImage(new Uri(path));
                    kep.Key.Background = new ImageBrush(src);
                }
            };
        }
        private void UpdatePlayerPosition()
        {
            // Set the Grid.Row and Grid.Column properties for the player's position
            Grid.SetRow(player1.Shape, player1.Row);
            Grid.SetColumn(player1.Shape, player1.Column);
        }
        private void btnDice_Click(object sender, RoutedEventArgs e)
        {
            player1.MovePlayer(); // Update player's grid position
            UpdatePlayerPosition(); // Update the position on the grid
        }
    }
}