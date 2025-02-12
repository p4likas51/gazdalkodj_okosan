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
            InitializeComponent();

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
    }
}
