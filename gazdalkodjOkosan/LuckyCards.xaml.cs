﻿using System;
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
            int randomCard = random.Next(1, 14);
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
                    wonPrize(6000, Player);
                    break;
                case 7:
                    WorkerOfTheYear(10000, Player);
                    break;
                case 8:
                    moneyGetBack(3000, Player);
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
                    GetRepairTool(Player);
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
            lblCard.Content = $"Autóvásárlási akció! A következő autóvásárlásnál {amount}%-os  kedvezményt kapsz.";
        }

        private void Promotion(int amount, Player player)
        {
            player.Bonus = amount;
            lblCard.Content = "Előléptettek, így extra fizetést kapsz!";

        }

        private void LessBonus(int amount, Player player)
        {
            player.Bonus = amount;
            lblCard.Content = "Új kormányrendelet miatt csökkent a pályakezdő támogatásod!";
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

            if (player.ItemStatus["carInsurance"] == false)
            {
                player.ItemStatus["carInsurance"] = true;
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
            lblCard.Content = "KUPONNAPOK! A következő berendezés vásárásodra 20% kedvezményt kapsz. A következő autó vagy lakás vásárlásodra 10% kedvezményt kapsz!";
        }
        private void OnePlusRound()
        {
            PlusRound = true;
            lblCard.Content = "Nagy késésben vagy munkahelyedről!\nDobj mégegyszer!";
        }
        private void GetRepairTool(Player player)
        {
            lblCard.Content = "Találtál egy szerelődobozt az utcán, ha bármid elromlik egyszer meg tudod javítani!";
            player.RepairTool = true;
        }
    }
}
