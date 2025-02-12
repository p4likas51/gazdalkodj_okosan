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
        }

        private void SofaBuy_Click(object sender, RoutedEventArgs e)
        {
            Player.ItemStatus["sofa"] = true;
        }

        private void CabinetBuy_Click(object sender, RoutedEventArgs e)
        {
            Player.ItemStatus["cabinet"] = true;

        }

        private void BedBuy_Click(object sender, RoutedEventArgs e)
        {
            Player.ItemStatus["bed"] = true;

        }
    }
}
