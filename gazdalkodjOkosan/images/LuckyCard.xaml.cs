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

namespace gazdalkodjOkosan.images
{

    public partial class LuckyCard : Window
    {
        public Player Player { get; private set; }
        public LuckyCard(Player player)
        {
            Player = player;
            InitializeComponent();
        }

        private void Btn_LuckyCard_Click(object sender, RoutedEventArgs e)
        {
            LuckyText.Content = "alma";
            
        }

    }
}
