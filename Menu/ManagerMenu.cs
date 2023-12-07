using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FOOD.Managers.Implementation;
using FOOD.Managers.Interface;

namespace FOOD.Menu
{
    public class ManagerMenu
    {
        IWalletInterface walletInterface = new WalletManager();
        IUserInterface userManager = new UserManager();
        IFoodInterface foodInterface = new FoodManager();

        public void ManagerMain()
        {
            System.Console.WriteLine("Select 1 to add food:\nSelect 2 to view all existing customer:\nSelect 3 to view all foods:\nSelect 4 to view avaliable balance\nSelect 5 to log out:");
            int select = int.Parse(Console.ReadLine());
            if (select == 1)
            {
                AddFood();
                ManagerMain();
            }
            else if (select == 2)
            {
                ViewAllCustomer();
                ManagerMain();
            }
            else if (select == 3)
            {
                ViewAllFood();
                ManagerMain();
            }
            else if (select == 4)
            {
                CheckBalance();
                ManagerMain();
            }
            else if (select == 5)
            {
                MainMenu mainMenu = new MainMenu();
                mainMenu.Main();
            }
            else
            {
                System.Console.WriteLine("Incorrect input, kindly try again next time:");
                ManagerMain();
            }

        }

        private void AddFood()
        {
            System.Console.WriteLine("Input the name of the food you want to enter:");
            string foodName = Console.ReadLine();
            System.Console.WriteLine("Input the food type you wanna enter: ");
            string foodType = Console.ReadLine();
            System.Console.WriteLine("Input the portion of the food: ");
            int portion = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Input the price of food:");
            double price = double.Parse(Console.ReadLine());

            var food = foodInterface.Get(foodName);
            if (food == null)
            {
                foodInterface.Create(foodName, foodType, portion, price);
                System.Console.WriteLine("Food created Successfully");
            }
            else
            {
                System.Console.WriteLine("Food already exist");
            }
        }

        private void ViewAllCustomer()
        {
            try
            {
                var allCustomer = userManager.GetAll();
                foreach (var customer in allCustomer)
                {
                    System.Console.WriteLine($"ID{customer.id}\tNAME{customer.name}\t{customer.email}\t{customer.address}\t{customer.dob}");
                }

            }
            catch (System.Exception ex)
            {

                System.Console.WriteLine(ex.Message);
                System.Console.WriteLine();
                System.Console.WriteLine();
                System.Console.WriteLine(ex.StackTrace);
            }

        }
        private void ViewAllFood()
        {
            var allFood = foodInterface.GetAll();
            foreach (var food in allFood)
            {
                System.Console.WriteLine($"FOOD ID: {food.id}\tFOOD NAME: {food.foodName}\tFOOD TYPE: {food.foodType}\tFOOD PRICE: {food.price}\tFOOD PORTION: {food.portion}");
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
    }
}