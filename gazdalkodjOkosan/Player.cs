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
        public bool RepairTool {  get; set; }
        public double DiscountCar
        {
            get { return _discountCar; }
            set
            {
                _discountCar = value;
                UpdateItemPrices();
            }
        }
        private double _discountCar;
        public double DiscountHouse
        {
            get { return _discountHouse; }
            set
            {
                _discountHouse = value;
                UpdateItemPrices();
            }
        }
        private double _discountHouse;
        public double DiscountItems
        {
            get { return _discountItems; }
            set
            {
                _discountItems = value;
                UpdateItemPrices();
            }
        }
        private double _discountItems;
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

        public Player(string name, Brush playerColor, int startingBalance = 30000)
        {
            RepairTool = false;
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

            _discountCar = 1;
            _discountHouse = 1;
            _discountItems = 1;

            ItemPrices = new Dictionary<string, double>();

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

            // **Itt frissítjük az árakat, miután minden kedvezményt beállítottunk**
            UpdateItemPrices();
        }


        public void UpdateItemPrices()
        {
            ItemPrices["house"] = 60000 * DiscountHouse;
            ItemPrices["car"] = 30000 * DiscountCar;
            ItemPrices["tv"] = 15000 * DiscountItems;
            ItemPrices["oven"] = 10000 * DiscountItems;
            ItemPrices["cabinet"] = 12000 * DiscountItems;
            ItemPrices["bed"] = 14000 * DiscountItems;
            ItemPrices["lego"] = 8000 * DiscountItems;
            ItemPrices["washingmachine"] = 12000 * DiscountItems;
            ItemPrices["sofa"] = 10000 * DiscountItems;
            ItemPrices["houseInsurance"] = 30000; 
            ItemPrices["carInsurance"] = 20000;
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

        public void MovePlayer(int step)
        {
            for (int i = 0; i < step; i++)
            {
                if (Row == 2 && Column < 8) Column++;
                else if (Column == 8 && Row < 7) Row++;
                else if (Row == 7 && Column > 1) Column--;
                else if (Column == 1 && Row > 2) Row--;
            }
            Step += step;
            if (Step >= 24)
            {
                Balance += 5000 + Bonus;
                Step = Step - 24;
            }
        }

    }
}
