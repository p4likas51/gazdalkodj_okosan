using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace gazdalkodjOkosan
{
    public static class Table
    {
        public static  FrameworkElement FindElementInGrid(Grid grid, int row, int column)
        {
            foreach (FrameworkElement element in grid.Children)
            {
                if (Grid.GetRow(element) == row && Grid.GetColumn(element) == column)
                {
                    return element;
                }
            }
            return null;
        }
        
    }
}
