using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace gazdalkodjOkosan
{
    public class Player
    {
        public double DiscountCar { get; set; }
        public double DiscountItems { get; set; }
        public double DiscountHouse { get; set; }
        public int Bonus { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
        public List<string> Items { get; private set; }
        public Brush PlayerColor { get; set; }
        public Ellipse Shape {  get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public int DiceRoll { get; set; }
        public Dictionary<string, bool> ItemStatus;
        public Dictionary<string, double> ItemPrices;

        private int Step {  get; set; }
        public bool CarInsurance = false;
        public bool HouseInsurance = false;

        public Player(string name, Brush playerColor, int startingBalance = 10000)
        {
            ItemStatus = new Dictionary<string, bool>()
            {
                {"house", false },
                {"car", false },
                {"tv", false },
                {"oven", false },
                {"cabinet", false },
                {"bed", false },
                {"lego", false },
                {"washingmachine", false },
                {"sofa", false },
                {"houseInsurance", false },
                {"carInsurance", false }

            };
            DiscountCar = 1;
            DiscountHouse = 1;
            DiscountItems = 1;
            ItemPrices = new Dictionary<string, double>()
            {
                {"house", 30000 * DiscountHouse},
                {"car", 20000 * DiscountCar},
                {"tv", 12000 * DiscountItems},
                {"oven", 4000 * DiscountItems},
                {"cabinet", 4000 * DiscountItems},
                {"bed", 5000 * DiscountItems},
                {"lego", 2000 * DiscountItems},
                {"washingmachine", 5000 * DiscountItems},
                {"sofa", 10000 * DiscountItems},
                {"houseInsurance", 30000 },
                {"carInsurance", 20000 },
            };
            Name = name;
            Bonus = 0;
            PlayerColor = playerColor;
            Balance = startingBalance;
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
                Balance += 5000 + Bonus;
                Step = Step - 24;
            }
        }

    }
}
