using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FOOD.Managers.Implementation;
using FOOD.Managers.Interface;
using FoodOrdering.Manager.Implementation;
using FoodOrdering.Manager.Interface;

namespace FOOD.Menu
{
    public class CustomerMenu
    {
        IFoodInterface foodInterface = new FoodManager();
        IUserInterface userInterface = new UserManager();
        IWalletInterface walletInterface = new WalletManager();
        IOrderInterface orderInterface = new OrderManager();
        IDepositInterface depositInterface = new DepositManager();

        public void customerMain()
        {
            System.Console.WriteLine("Press 1 to order for food:\nPress 2 to Top Up your wallet:\nPress 3 to check wallet balance\nPress 4 to view all available foods\nPress 5 to log out ");
            int press = int.Parse(System.Console.ReadLine());

            if (press == 1)
            {
                Ordering();
            }
            else if (press == 2)
            {
                Deposit();
                customerMain();
            }
            else if (press == 3)
            {
                CheckBalance();
                customerMain();
            }
            else if (press == 4)
            {
                ViewAllFood();
                customerMain();
            }
            else if (press == 5)
            {
                MainMenu menu = new MainMenu();
                menu.Main();
            }
            else
            {
                System.Console.WriteLine("Incorrect input, please try again");
                customerMain();
            }
        }

        public void Ordering()
        {
            System.Console.WriteLine("Enter your wallet: ");
            string benefactorWallet = Console.ReadLine();
            System.Console.WriteLine("Enter the food type you want");
            string foodType = Console.ReadLine();
            System.Console.WriteLine("Enter food name you want to buy: ");
            string food = Console.ReadLine();
            string beneficiaryWallet = "ABOD/WLT/001";
            System.Console.WriteLine("Enter the portion you wanna buy");
            int portion = int.Parse(System.Console.ReadLine());
            var fd = foodInterface.Get(food);
            var amount = fd.price;
            System.Console.WriteLine("The amount of the food per portion is: " + amount);
            var customerInfo = walletInterface.Get(benefactorWallet);
            var pay = orderInterface.Make(benefactorWallet, beneficiaryWallet, amount, food, portion);
            if (pay == null)
            {
                System.Console.WriteLine("Payment unsuccessful!!!");
            }
            else
            {
                System.Console.WriteLine("Payment successful\nYour food is ready for pick up");
            }
            customerMain();
        }
        public void Deposit()
        {
            Console.Write("Enter the amount: ");
            double amount = double.Parse(Console.ReadLine());
            System.Console.WriteLine("Enter ur wallet Id : ");
            string wltid = Console.ReadLine();

            var deposit = depositInterface.AddMoney(wltid, amount);
            if (deposit == null)
            {
                System.Console.WriteLine("Deposit Failed!!!");
            }
            else
            {
                var depositref = depositInterface.Get(deposit.ReferenceNumber);
                System.Console.WriteLine($"Deposit succesful with the ref number {depositref.ReferenceNumber}");
            }
        }

        private void CheckBalance()
        {
            System.Console.WriteLine("Enter your wallet id: ");
            string wallet = Console.ReadLine();
            Console.WriteLine("Enter your Email adress: ");
            string mail = Console.ReadLine();
            walletInterface.GetBalance(wallet, mail);
        }

         private void ViewAllFood()
        {
            var allFood = foodInterface.GetAll();
            foreach (var food in allFood)
            {
                System.Console.WriteLine($"FOOD ID: {food.id}\tFOOD NAME: {food.foodName}\tFOOD TYPE: {food.foodType}\tFOOD PRICE: {food.price}\tFOOD PORTION: {food.portion}");
            }
        }

    }
}