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
    /// Interaction logic for LuckyCards.xaml
    /// </summary>
    public partial class LuckyCards : Window
    {
        public bool PlusRound {  get; set; }
        public Player Player { get; set; }
        public LuckyCards(Player player)
        {
            InitializeComponent();
            Player = player;
            
        }

        private void btnPickCard_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            btn.IsEnabled = false;
            Random random = new Random();
            int randomCard = random.Next(1, 19);
            switch (randomCard)
            {
                case 1:
                    invest(4000, Player);
                    break;
                case 2:
                    CarDiscount(0.7, Player);
                    break;
                case 3:
                    Promotion(5000, Player);
                    break;
                case 4:
                    LessBonus(2000, Player);
                    break;
                case 5:
                    Taxes(7000, Player);
                    break;
                case 6:
                    wonPrize(10000, Player);
                    break;
                case 7:
                    WorkerOfTheYear(10000, Player);
                    break;
                case 8:
                    moneyGetBack(9000, Player);
                    break;
                case 9:
                    freeHouseInsurance(Player);
                    break;
                case 10:
                    Coupons(Player);
                    break;
                case 11:
                    OnePlusRound();
                    break;
                case 12:
                    GetRepairTool(8000, Player);
                    break;
                case 13:
                    shortCircuit(5000, Player);
                    break;
                case 14:
                    dogIncident(5000, Player);
                    break;
                case 15:
                    freeCar(Player);
                    break;
                case 16:
                    houseFire(Player);
                    break;
                case 17:
                    stealSomething(Player);
                    break;
                case 18:
                    carAccident(Player);
                    break;

            }
            btnExit.Visibility = Visibility.Visible;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void invest(int amount, Player player)
        {
            player.Balance += amount;
            lblCard.Content = $"Befektetésed jól sikerült! Kapsz {amount} Ft-ot.";

        }



        private void CarDiscount(double amount, Player player)
        {
            player.DiscountCar = amount;
            lblCard.Content = $"Autóvásárlási akció! A következő autóvásárlásnál 30%-os  kedvezményt kapsz.";
        }

        private void Promotion(int amount, Player player)
        {
            player.Bonus = amount;
            lblCard.Content = $"Előléptettek, így extra fizetést kapsz!\n(+{amount}Ft)";

        }

        private void LessBonus(int amount, Player player)
        {
            player.Bonus = amount;
            lblCard.Content = $"Új kormányrendelet miatt csak kevésbé nő a pályakezdő támogatásod!\n(+{amount}Ft)";
        }

        private void Taxes(int amount, Player player)
        {
            if (player.Balance <= amount) player.Balance = 0;
            else player.Balance -= amount;
            lblCard.Content = $"Váratlan adófizetés! Elfelejtett számlád van. Fizess {amount} Ft-ot.";
        }

        private void wonPrize(int amount, Player player)
        {
            player.Balance += amount;
            lblCard.Content = "Jótékonysági tombola fődíját megnyerted!";
        }

        private void WorkerOfTheYear(int amount, Player player)
        {
            player.Balance += amount;
            lblCard.Content = $"Megnyerted az év dolgozója díjat! Kapsz {amount} Ft jutalmat.";
        }

        private void moneyGetBack(int amount, Player player)
        {
            player.Balance += amount;
            lblCard.Content = $"Visszatérítés a biztosítótól! Kapsz {amount} Ft-ot.";
        }

        private void freeHouseInsurance(Player player)
        {
            lblCard.Content = "Ingyen lakásbiztosítás!";
            if (player.ItemStatus["house"] == false)
            {
                lblCard.Content = $"Nem kaphatsz lakásbiztosítást, még nincs lakásod";
            }
            else if (player.ItemStatus["houseInsurance"] == false)
            {
                player.ItemStatus["houseInsurance"] = true;
            }
            else
            {
                lblCard.Content = "Már van lakásbiztosításod.";
            }
        }

        private void Coupons(Player player)
        {
            player.DiscountItems = 0.8;
            player.DiscountCar = 0.9;
            player.DiscountHouse = 0.9;
            lblCard.Content = "KUPONNAPOK! A következő berendezés vásárlásodra 20% kedvezményt kapsz. A következő autó vagy lakás vásárlásodra 10% kedvezményt kapsz!";
        }
        private void OnePlusRound()
        {
            PlusRound = true;
            lblCard.Content = "Nagy késésben vagy munkahelyedről!\nDobj mégegyszer!";
        }
        private void GetRepairTool(int amount, Player player)
        {
            if (player.RepairTool)
            {
                lblCard.Content = $"Haverod adott egy szerszámosládát, mert nem tudta, hogy már van neked.\nFeltetted Marketplacere és el is vitték +{amount}Ft";
                player.Balance += amount;
            }
            else
            {
                lblCard.Content = "Találtál egy szerelődobozt az utcán, ha bármid elromlik egyszer meg tudod javítani!";
                player.RepairTool = true;
            }

        }

        private void shortCircuit(int amount, Player player)
        {
            if (player.ItemStatus["house"])
            {
                if (player.RepairTool)
                {
                    lblCard.Content = $"Volt szerelőkészleted ezt most megúsztad!";
                    player.RepairTool = false;
                }
                else
                {
                    if (player.Balance <= amount) player.Balance = 0;
                    else player.Balance -= amount;
                    lblCard.Content = $"Bedugva hagytad a karácsonyfa világításod, ami rövidzárlatot kapott. A sérült bútorokért fizetned kell {amount} Ft-ot.";
                }
            }
            else
            {
                lblCard.Content = $"Amíg nincs ház, nics mi elromoljon így könnyebb spórolni is!\n+{amount}Ft";
                player.Balance += amount;
            }
            

        }

        private void dogIncident(int amount, Player player)
        {
            if (player.ItemStatus["sofa"])
            {
                if (player.RepairTool)
                {
                    lblCard.Content = $"Kölyök kutyusod megrágta az asztal szélét, de csodadobozodnak hála meg tudtad javítani!";
                    player.RepairTool = false;
                }
                else
                {
                    if (player.Balance <= amount) player.Balance = 0;
                    else player.Balance -= amount;
                    lblCard.Content = $"A kölyök labradorod széttépte a kanapéd, amíg nem voltál otthon.\nFizess {amount} Ft-ot új bútorra.";
                }
            }
            else
            {
                lblCard.Content = $"Kutyusod nyert egy ügyességi versenyt\nJutalmad: {amount}Ft";
                player.Balance += amount;
            }
            
        }
        private void freeCar( Player player)
        {

            lblCard.Content = $"Örököltél egy autót, eladhatod vagy megtarthatod!";
            freeCar window = new freeCar(player);
            window.ShowDialog();
        }
        private void houseFire(Player player)
        {
            if (player.ItemStatus["house"])
            {
                if (player.ItemStatus["houseInsurance"] == true)
                {
                    lblCard.Content = "Leégett a házad de fizet a biztosítód, de felbontották a szerződést újat kell majd kötnöd";
                    player.ItemStatus["houseInsurance"] = false;
                }
                else
                {
                    lblCard.Content = "Leégett a házad és még biztosításod sem volt...";
                    foreach (var key in player.ItemStatus.Keys.ToList())
                    {
                        player.ItemStatus[key] = player.ItemStatus[key] = false;
                    }
                }
            }
            else
            {
                player.Balance += 1000;
                lblCard.Content = "Találtál a földön 1000Ft-ot!";
            }
        }

        private void stealSomething(Player player)
        {
            lblCard.Content = $"Felkeresett egy régi tolvaj ismerősöd. Lopass vele egy tetszőleges berendezést a házadba! (nem lehet autó)\r\n";
            Steal window = new Steal(player);
            window.ShowDialog();
        }

        private void carAccident(Player player)
        {
            if (player.ItemStatus["car"])
            {
                if (player.ItemStatus["carInsurance"] == true)
                {
                    lblCard.Content = "Totálkár lett az autód egy baleset miatt, de fizet a biztosítód";
                    player.ItemStatus["carInsurance"] = false;
                }
                else
                {
                    lblCard.Content = "Totálkár lett az autód egy baleset miatt és még biztosításod sem volt...";
                    player.ItemStatus["car"] = false;
                }
            }
            else
            {
                player.Balance -= 1000;
                lblCard.Content = "Nagyon megfogott egy utcazenész előadása adtál neki 1000Ft-ot";
            }
        }
    }
}
