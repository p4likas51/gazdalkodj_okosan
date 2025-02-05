using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void AddItem(string item)
        {
            Items.Add(item);
        }

        public void RemoveItem(string item)
        {
            Items.Remove(item);
        }

        public void AdjustBalance(int amount)
        {
            Balance += amount;
        }
        public void MovePlayer()
        {
            // Simulate a dice roll (1 to 6)
            Random random = new Random();
            int diceRoll = random.Next(1, 7); // Rolls a number between 1 and 6

            // Update the player's position
            for (int i = 0; i < diceRoll; i++)
            {
                // Move player by one space
                Column++;

                // If the player reaches the end of the row (5th column), move to the next row
                if (Column >= 6)
                {
                    Column = 0;
                    Row++;
                    // If we reach the 7th row, we reset back to the first row (optional, or could stop)
                    if (Row >= 9)
                    {
                        Row = 0;
                    }
                }
            }

            Console.WriteLine($"{Name} rolled a {diceRoll} and is now at position ({Row}, {Column})");
        }

    }
}
