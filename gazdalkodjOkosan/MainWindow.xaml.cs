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
        double ROUND = 1;
        Player player1 = new Player("player1", Brushes.Red);
        Player player2 = new Player("player2", Brushes.Blue);
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

                GameGrid.Children.Add(player2.Shape);
                Grid.SetRow(player2.Shape, player2.Row);
                Grid.SetColumn(player2.Shape, player2.Column);

                foreach (var kep in kepek)
                {
                    var path = System.IO.Path.Combine(Environment.CurrentDirectory, kep.Value);
                    ImageSource src = new BitmapImage(new Uri(path));
                    kep.Key.Background = new ImageBrush(src);
                }
            };
        }
        private void UpdatePlayerPosition(Player player)
        {
            // Set the Grid.Row and Grid.Column properties for the player's position
            Grid.SetRow(player.Shape, player.Row);
            Grid.SetColumn(player.Shape, player.Column);
        }
        private void btnDice_Click(object sender, RoutedEventArgs e)
        {

            if (ROUND % 2 == 1)
            {
                player1.MovePlayer(); // Update player's grid position
                UpdatePlayerPosition(player1); // Update the position on the grid
                lblDice.Content = $"Piros játékos dobása: {player1.DiceRoll}";
            }
            else
            {
                player2.MovePlayer(); // Update player's grid position
                UpdatePlayerPosition(player2); // Update the position on the grid
                lblDice.Content = $"Kék játékos dobása: {player2.DiceRoll}";
            }
            ROUND++;
        }
    }
}