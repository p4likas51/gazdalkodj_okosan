using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace gazdalkodjOkosan
{
    public class Player
    {
        public string Name { get; set; }
        public int Balance { get; set; }
        public List<string> Items { get; private set; }
        public Brush PlayerColor { get; set; }
        public Ellipse Shape {  get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public int DiceRoll { get; set; }
        private int Step {  get; set; }
        public bool CarInsurance = false;
        public bool HouseInsurance = false;

        public Player(string name, Brush playerColor, int startingBalance = 10000)
        {
            Name = name;
            PlayerColor = playerColor;
            Balance = startingBalance;
            Items = new List<string>();
            Shape = new Ellipse()
            {
                Width = 100,
                Height = 100,
                Fill = playerColor,
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };
            Row = 2;
            Column = 1;

        }
        public void MovePlayer()
        {
            Random random = new Random();
            DiceRoll = random.Next(1, 7);

            for (int i = 0; i < DiceRoll; i++)
            {
                if (Row == 2 && Column < 8) Column++;
                else if (Column == 8 && Row < 7) Row++;
                else if (Row == 7 && Column > 1) Column--;
                else if (Column == 1 && Row > 2) Row--;
            }
            Step += DiceRoll;
            if (Step >= 24)
            {
                Balance += 5000;
                Step = Step - 24;
            }
        }

    }
}
