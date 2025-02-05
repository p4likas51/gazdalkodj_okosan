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
        Player player1 = new Player("p1", Brushes.Red);
        public MainWindow()
        {
            InitializeComponent();

            Loaded += (sender, e) =>
            {
                GameGrid.Children.Add(player1.Shape);
                UpdatePlayerPosition();
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
            player1.MovePlayer();
            UpdatePlayerPosition();
        }
    }
}