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
        bool OUT = false;
        double ROUND = 1;
        Player player1 = new Player("Piros", Brushes.Red);
        Player player2 = new Player("Kék", Brushes.Blue);
        public MainWindow()
        {
            Welcome window = new Welcome();
            window.ShowDialog();
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
                { rctSofa, "kanape.jpg" },
                { rctCar, "auto.png" },
                { rctOven, "suto.webp" },
                { rctCabinet, "szekreny.jpg" },
                { rctTv, "tv.jpg" },
                { rctBed, "agy.jpg" },
                { rctLego, "lego.png" },
                { rctWashing, "mosogep.webp" }, 
                { Background, "asztal.jpg" },
                { Cards, "kartyak-keret.png" },
                { Title, "felirat-forgatva.png" },
                { Wallet, "wallet.png" },
                { brdDice, "dobokocka.png" }




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

                rctCar.Visibility = Visibility.Collapsed;
                rctBed.Visibility = Visibility.Collapsed;
                rctCabinet.Visibility = Visibility.Collapsed;
                rctLego.Visibility = Visibility.Collapsed;
                rctOven.Visibility = Visibility.Collapsed;
                rctSofa.Visibility = Visibility.Collapsed;
                rctTv.Visibility = Visibility.Collapsed;
                rctWashing.Visibility = Visibility.Collapsed;
            };
        }

        private void showItemImages(Player player)
        {
            if (player.ItemStatus["car"] == true)
            {
                rctCar.Visibility = Visibility.Visible;
            }
            else { rctCar.Visibility = Visibility.Collapsed; }

            if (player.ItemStatus["tv"] == true)
            {
                rctTv.Visibility = Visibility.Visible;
            }
            else { rctTv.Visibility = Visibility.Collapsed; }

            if (player.ItemStatus["oven"] == true)
            {
                rctOven.Visibility = Visibility.Visible;
            }
            else { rctOven.Visibility = Visibility.Collapsed; }

            if (player.ItemStatus["cabinet"] == true)
            {
                rctCabinet.Visibility = Visibility.Visible;
            }
            else { rctCabinet.Visibility = Visibility.Collapsed; }

            if (player.ItemStatus["bed"] == true)
            {
                rctBed.Visibility = Visibility.Visible;
            }
            else { rctBed.Visibility = Visibility.Collapsed; }

            if (player.ItemStatus["lego"] == true)
            {
                rctLego.Visibility = Visibility.Visible;
            }
            else { rctLego.Visibility = Visibility.Collapsed; }

            if (player.ItemStatus["washingmachine"] == true)
            {
                rctWashing.Visibility = Visibility.Visible;
            }
            else { rctWashing.Visibility = Visibility.Collapsed; }

            if (player.ItemStatus["sofa"] == true)
            {
                rctSofa.Visibility = Visibility.Visible;
            }
            else { rctSofa.Visibility = Visibility.Collapsed; }
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
        private void updateInsurance(Player player)
        {
            if (player.ItemStatus["carInsurance"]) lblCarInsurance.Content = "Gépjármű biztosítás: van";
            else lblCarInsurance.Content = "Gépjármű biztosítás: nincs";
            if (player.ItemStatus["houseInsurance"]) lblHouseInsurance.Content = "Ház biztosítás: van";
            else lblHouseInsurance.Content = "Ház biztosítás: nincs";
        }
        private void PlayARound(Player player)
        {
            updateInsurance(player);
            showItemImages(player);
            lblActionText.Content = "";
            lblAction.Content = "";
            player.MovePlayer();
            UpdatePlayerPosition(player);
            lblDice.Content = $"{player.Name} : {player.DiceRoll}";
            var element = Table.FindElementInGrid(GameGrid, player.Row, player.Column);
            updateBalance();
            FieldActions(element, player);
            updateInsurance(player);
            updateBalance();
            showItemImages(player);

            if (player.ItemStatus["house"] == true && player.ItemStatus["car"] == true && player.ItemStatus["tv"] == true && player.ItemStatus["oven"] == true && player.ItemStatus["cabinet"] == true && player.ItemStatus["bed"] == true && player.ItemStatus["lego"] == true && player.ItemStatus["washingmachine"] == true && player.ItemStatus["sofa"] == true)
            {
                Vegkiiras window = new Vegkiiras(player);
                window.ShowDialog();
            }
        }

        private void PlayARound(Player player, int step)
        {
            lblActionText.Content = "";
            lblAction.Content = "";
            player.MovePlayer(step);
            UpdatePlayerPosition(player);
            lblDice.Content = $"Piros játékos dobása: {player.DiceRoll}";
            var element = Table.FindElementInGrid(GameGrid, player.Row, player.Column);
            updateBalance();
            FieldActions(element, player);
            updateBalance();
        }

        public async void FieldActions(FrameworkElement currentPosition, Player player)
        {
            if (currentPosition.Name == "borderBiztositas2")
            {
                if (player.ItemStatus["carInsurance"] == true)
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
                if (player.ItemStatus["houseInsurance"] == true)
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
                CarMarket carMarketWindow = new CarMarket(player, "car");
                carMarketWindow.ShowDialog();
            }
            if (currentPosition.Name == "borderMav")
            {
                lblActionText.Content = "Elvonatozol az állatkertbe";
                btnDice.IsEnabled = false;
                await Task.Delay(2000);
                btnDice.IsEnabled = true;
                PlayARound(player, 7);
                
            }
            if (currentPosition.Name == "borderHev")
            {
                lblActionText.Content = "Elvonatozol a vidámparkba";
                btnDice.IsEnabled = false;
                await Task.Delay(2000);
                btnDice.IsEnabled = true;
                PlayARound(player, 4);

            }
            if (currentPosition.Name == "borderBkv")
            {
                lblActionText.Content = "Elvonatozol a tropicáriumba";
                btnDice.IsEnabled = false;
                await Task.Delay(2000);
                btnDice.IsEnabled = true;
                PlayARound(player, 9);

            }
            if (currentPosition.Name == "borderHazvasarlas")
            {
                CarMarket carMarketWindow = new CarMarket(player, "house");
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
                LuckyCards window = new LuckyCards(player);
                window.ShowDialog();
                if (window.PlusRound == true) ROUND++;
            }

            if (currentPosition.Name == "borderIkea")
            {
                Ikea window = new Ikea(player);
                window.ShowDialog();
            }


            if (currentPosition.Name == "borderJatekbolt")
            {
                Lego window = new Lego(player);
                window.ShowDialog();
            }

            if (currentPosition.Name == "borderMedia")
            {
                MediaMarkt window = new MediaMarkt(player);
                window.ShowDialog();
            }
            if (currentPosition.Name == "borderLotto")
            {
                player.Balance += 5000;
                lblActionText.Content = "Nyertél egy kaparós sorsjegyen";
                lblAction.Content = "+5000Ft";
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

        private void btnDice_Click(object sender, RoutedEventArgs e)
        {

            if (ROUND % 2 == 1)
            {
                var currentPosition = Table.FindElementInGrid(GameGrid, player1.Row, player1.Column);
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