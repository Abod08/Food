using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FOOD.Enums;
using FOOD.Managers.Implementation;
using FOOD.Managers.Interface;
using FoodOrdering.Manager.Implementation;
using FoodOrdering.Manager.Interface;

namespace FOOD.Menu
{


    public class SuperAdmin
    {
        IWalletInterface walletInterface = new WalletManager();
        IUserInterface userManger = new UserManager();
        IManagerInterface manager = new ManagerManager();
        IDepositInterface depositInterface = new DepositManager();
        MainMenu main = new MainMenu();

        public void Admin()
        {
            System.Console.WriteLine("Select 1 to view all staff\nSelect 2 to view all customers\nSelect 3 to register a staff\nSelect 4 to deposit into your wallet\nSelect 5 to view available balancen\nSelect 6 to log out");
            int select = int.Parse(Console.ReadLine());
            if (select == 1)
            {
                ViewAllStaff();
            }
            else if (select == 2)
            {
                ViewAllCustomer();
            }
            else if (select == 3)
            {
                AddStaff();
            }
            else if (select == 4)
            {
                Deposit();
                Admin();
            }
            else if (select == 5)
            {
                CheckBalance();
                Admin();
                
            }
            else if(select == 6)
            {
                main.Main();
            }
            else
            {
                System.Console.WriteLine("Incorrect input\nKindly input correct detail");
                main.Main();
            }
        }
        private void ViewAllStaff()
        {
            try
            {
                var viewStaff = userManger.GetAll();
                foreach (var staff in viewStaff)
                {
                    if (staff.role.ToUpper() == "Manager")
                    {
                        System.Console.WriteLine($"ID: {staff.id}\tName: {staff.name}\tPassword: {staff.password}");
                    }
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

        private void ViewAllCustomer()
        {
            try
            {
                var allCustomer = userManger.GetAll();
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
        private void AddStaff()
        {
            System.Console.WriteLine("Enter your name: ");
            string fullName = Console.ReadLine();
            System.Console.WriteLine("Enter your Address: ");
            string address = Console.ReadLine();
            System.Console.WriteLine("Enter your email: ");
            string email = Console.ReadLine();
            System.Console.WriteLine("Enter your Phone number");
            string phoneNumber = Console.ReadLine();
            System.Console.WriteLine("Enter your Password");
            string password = Console.ReadLine();
            System.Console.WriteLine("Press 1 if you're a male\nPress 2 if you're a female");
            int gender = int.Parse(System.Console.ReadLine());
            System.Console.WriteLine("Enter your Date of Birth");
            DateTime dob = DateTime.Parse(System.Console.ReadLine());
            string beneficiaryWallet = "ABOD/WLT/001";
            double amount = 0;

            var tag = manager.Get(email);
            if (tag == null)
            {
                var staff = manager.Register(fullName, email, password, phoneNumber, address, (Gender)gender, dob, beneficiaryWallet, amount);
                if (gender == 1)
                {
                    System.Console.WriteLine($"Mr. {fullName} you've successfully registered");
                    System.Console.WriteLine($"Your tag number is : {staff.staffTag}");
                }
                else if (gender == 2)
                {
                    System.Console.WriteLine($"Miss/Mrs. {fullName} you've successfully registered");
                    System.Console.WriteLine($"Your tag number is : {staff.staffTag}");
                }
                Admin();
            }
            else
            {
                System.Console.WriteLine("Staff already exist");
                Admin();
            }
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
    }
}