using gazdalkodjOkosan.images;
using System.IO;
using System.Numerics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace gazdalkodjOkosan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double ROUND = 1;
        Player player1 = new Player("player1", Brushes.Red);
        Player player2 = new Player("player2", Brushes.Blue);
        public MainWindow()
        {
            InitializeComponent();

            Dictionary<Border, string> kepek = new Dictionary<Border, string>()
            {
                { borderIkea, "Ikea_logo.svg.png" },
                { borderMedia, "mediamarkt.png" },
                { borderRacsok, "racsok.jpg" },
                { borderSzerencse, "szerencse.png" },
                { borderSzerencse2, "szerencse.png" },
                { borderSzerencse3, "szerencse.png" },
                { borderSzerencse4, "szerencse.png" },
                { borderHazvasarlas, "hazvasarlas.jpg" },
                { borderAutovasarlas, "autovasarlas.jpg" },
                { borderBiztositas1, "hazbiztositas.jpg" },
                { borderBiztositas2, "autobiztositas.jfif" },
                { borderAllatkert, "allatkert.jpg" },
                { borderVidampark, "vidampark.jpg" },
                { borderJatekbolt, "regio.png" },
                { borderMav, "máv-logo(utazó mező).png" },
                { borderHev, "hev.png" },
                { borderBkv, "bkv.png" },
                { borderRablas, "rablas.jpg" },
                { borderTarca, "tarca.jpg" },
                { borderTropicarium, "tropicarium.png" },
                { borderStadion, "stadion.jpg" },
                { borderLotto, "lotto.jfif" },
                { borderStart, "start.png" },
                { borderMadar, "madarszar.jpg" },



            };

            Loaded += (sender, e) =>
            {
                GameGrid.Children.Add(player1.Shape);
                Grid.SetRow(player1.Shape, player1.Row);
                Grid.SetColumn(player1.Shape, player1.Column);

                GameGrid.Children.Add(player2.Shape);
                Grid.SetRow(player2.Shape, player2.Row);
                Grid.SetColumn(player2.Shape, player2.Column);

                foreach (var kep in kepek)
                {
                    var path = System.IO.Path.Combine(Environment.CurrentDirectory, "images", kep.Value);
                    ImageSource src = new BitmapImage(new Uri(path, UriKind.Absolute));
                    kep.Key.Background = new ImageBrush(src);
                }
            };
        }
        private void UpdatePlayerPosition(Player player)
        {
            Grid.SetRow(player.Shape, player.Row);
            Grid.SetColumn(player.Shape, player.Column);
        }
        private void updateBalance()
        {
            lblp1Balance.Foreground = Brushes.Red;
            lblp1Balance.Content = $"{player1.Balance}Ft";
            lblp2Balance.Foreground = Brushes.Blue;
            lblp2Balance.Content = $"{player2.Balance}Ft";
        }
        private void PlayARound(Player player)
        {
            lblActionText.Content = "";
            lblAction.Content = "";
            player.MovePlayer();
            UpdatePlayerPosition(player);
            lblDice.Content = $"Piros játékos dobása: {player.DiceRoll}";
            var element = Table.FindElementInGrid(GameGrid, player.Row, player.Column);
            lblSzoveg.Content = element.Name;
            updateBalance();
            FieldActions(element, player);
            updateBalance();
        }

        public void FieldActions(FrameworkElement currentPosition, Player player)
        {
            if (currentPosition.Name == "borderBiztositas2")
            {
                if (player.CarInsurance == true)
                {
                    lblActionText.Content = "Már van gépjármű biztosításod!";
                }
                else
                {
                    CarInsurance carInsuranceWindow = new CarInsurance(player, "car");
                    carInsuranceWindow.ShowDialog();
                }

            }
            if (currentPosition.Name == "borderBiztositas1")
            {
                if (player.HouseInsurance == true)
                {
                    lblActionText.Content = "Már van házbiztosításod!";
                }
                else
                {
                    CarInsurance carInsuranceWindow = new CarInsurance(player, "house");
                    carInsuranceWindow.ShowDialog();
                }
                
            }
            if (currentPosition.Name == "borderAutovasarlas")
            {
                CarMarket carMarketWindow = new CarMarket(player);
                carMarketWindow.ShowDialog();
            }
            if (currentPosition.Name == "borderRablas")
            {
                if (player.Balance <= 10000) player.Balance = 0;
                else player.Balance -= 10000;
                lblActionText.Content = "Rabló mezőre léptél:";
                lblAction.Content = "-10000Ft";
            }

            if (currentPosition.Name.StartsWith("borderSzerencse"))
            {
                LuckyCard window = new LuckyCard(player);
                window.ShowDialog();
            }

            if (currentPosition.Name == "borderIkea")
            {
                Ikea window = new Ikea(player);
                window.ShowDialog();
            }




            if (currentPosition.Name == "borderAllatkert")
            {
                lblActionText.Content = "A családdal elmentetek a helyi állatkertbe. Jó szórakozást!";
            }

            if (currentPosition.Name == "borderVidampark")
            {
                lblActionText.Content = "A barátaiddal elmentetek a Family Parkba. Jó szórakozást!";
            }

            if (currentPosition.Name == "borderTropicarium")
            {
                lblActionText.Content = "Cápales! Figyeljétek meg a különböző egzotikus fajokat!";
            }

            if (currentPosition.Name == "borderStadion")
            {
                lblActionText.Content = "Fradi - Videoton. Vesszen a Ferencváros!";
            }

            if (currentPosition.Name == "borderMadar")
            {
                if (player.Balance <= 1000) player.Balance = 0;
                else player.Balance -= 1000;
                lblActionText.Content = "Leszart egy madár, el kell vinned a kabátod a tisztítóba";
                lblAction.Content = "-1000Ft";
            }
            if (currentPosition.Name == "borderTarca")
            {
                player.Balance += 3000;
                lblActionText.Content = "Találtál egy tárcát a földön";
                lblAction.Content = "+3000Ft";
            }

        }

        private void invest(int amount, Player player)
        {
            player.Balance += amount;
            lblActionText.Content = "Befektetésed jól sikerült! Kapsz 6000 Ft-ot.";

        }



        private void CarDiscount(int amount, Player player)
        {
            player.DiscountCar = amount;
            lblActionText.Content = "Autóvásárlási akció! A következő autóvásárlásnál 2000 Ft kedvezményt kapsz.";
        }

        private void Promotion(int amount, Player player)
        {
            player.Bonus = amount;
            lblActionText.Content = "Előléptettek, így extra fizetést kapsz!";

        }

        private void LessBonus(int amount, Player player)
        {
            player.Bonus = amount;
            lblActionText.Content = "Új kormányrendelet miatt csökkent a pályakezdő támogatásod!";
        }

        private void Taxes(int amount, Player player)
        {
            player.Balance -= amount;
            lblActionText.Content = "Váratlan adófizetés! Elfelejtett számlád van. Fizess 2500 Ft-ot.";
        }

        private void wonPrize(int amount, Player player)
        {
            player.Balance += amount;
            lblActionText.Content = "Jótékonysági tombola fődíját megnyerted!";
        }

        private void missingRound(int amount, Player player)
        {
            
        }

        private void WorkerOfTheYear(int amount, Player player)
        {
            player.Balance += amount;
            lblActionText.Content = "Megnyerted az év dolgozója díjat! Kapsz 5000 Ft jutalmat.";
        }

        private void moneyGetBack(int amount, Player player)
        {
            player.Balance += amount;
            lblActionText.Content = "Visszatérítés a biztosítótól! Kapsz 2500 Ft-ot.";
        }

        private void freeHouseInsurance(int amount, Player player)
        {
            lblActionText.Content = "Ingyen lakásbiztosítás!";

            if (player.HouseInsurance == false)
            {
                player.HouseInsurance = true;
            }
            else
            {
                lblActionText.Content = "Már van lakásbiztosításod.";
            }
        }

        private void Coupons(int amount, Player player)
        {
            player.DiscountItems = 0.8;
            player.DiscountCar = 0.9;
            player.DiscountHouse = 0.9;
            lblActionText.Content = "KUPONNAPOK! A következő berendezés vásárásodra 20% kedvezményt kapsz. A következő autó vagy lakás vásárlásodra 10% kedvezményt kapsz!";
        }


        private void btnDice_Click(object sender, RoutedEventArgs e)
        {

            if (ROUND % 2 == 1)
            {
                var currentPosition = Table.FindElementInGrid(GameGrid, player1.Row, player1.Column);
                lblProba.Content = $"volt pozi: {currentPosition.Name}";
                if (currentPosition.Name != "borderRacsok")
                {
                    PlayARound(player1);
                }
                else
                {
                    Jail jailwindow = new Jail(player1);
                    jailwindow.ShowDialog();
                    if (jailwindow.OutOfJail == true)
                    {
                        PlayARound(player1);
                    }
                }

            }
            else
            {
                var currentPosition = Table.FindElementInGrid(GameGrid, player2.Row, player2.Column);
                lblProba.Content = $"volt pozi: {currentPosition.Name}";
                if (currentPosition.Name != "borderRacsok")
                {
                    PlayARound(player2);
                }
                else
                {
                    Jail jailwindow = new Jail(player2);
                    jailwindow.ShowDialog();
                    if (jailwindow.OutOfJail == true)
                    {
                        PlayARound(player2);
                    }
                }
                    
            }
            ROUND++;
        }
    }
}