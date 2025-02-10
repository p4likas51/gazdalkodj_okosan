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
    /// Interaction logic for CarInsurance.xaml
    /// </summary>
    public partial class CarInsurance : Window
    {
        public Player Player { get; private set; }

        public CarInsurance(Player player)
        {
            InitializeComponent();
            Player = player;
        }
    }
}
