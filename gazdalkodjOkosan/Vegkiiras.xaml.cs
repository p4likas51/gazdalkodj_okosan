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
    /// Interaction logic for Vegkiiras.xaml
    /// </summary>
    public partial class Vegkiiras : Window
    {
        public Player Player { get; set; }

        public Vegkiiras(Player player)
        {
            Player = player;
            InitializeComponent();

            winningText.Content = $"A győztes: {Player.Name} játékos.";

            Dictionary<Border, string> kepek = new Dictionary<Border, string>()
            {
                { winningBg, "gyoztes.jfif" },
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

        private void btnKilepes_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
            DialogResult = true;
            Close();
        }
    }
}
