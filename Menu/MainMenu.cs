using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FOOD.Customers.Interface;
using FOOD.Enums;
using FOOD.Managers.Implementation;
using FOOD.Managers.Interface;

namespace FOOD.Menu
{
    public class MainMenu
    {
        IUserInterface userInterface = new UserManager();
        ICustomerInterface customerInterface = new CustomerManager();
        IWalletInterface walletInterface = new WalletManager();
        CustomerMenu customerMenu = new CustomerMenu();
        ManagerMenu manager = new ManagerMenu();

        public void Main()
        {
            System.Console.WriteLine("~~~WELCOME TO ABOD RESTURANT~~~\nPress 1 to Sign Up as a Customer\nPress 2 to Sign In");
            int press = int.Parse(System.Console.ReadLine());
            if (press == 1)
            {
                SignUp();
            }
            else if (press == 2)
            {
                SignIn();
            }
            else
            {
                System.Console.WriteLine("Wrong input, try again later.");
                Main();
            }
        }
        private void SignUp()
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

            var register = customerInterface.Register(fullName, email, password, phoneNumber, address, (Gender)gender, dob, 0);
            var walletId = walletInterface.GetByName(email).WalletId;

            if (register != null)
            {
                System.Console.WriteLine("Registeration successful.\nKindly go to the menu to login!!!");
                System.Console.WriteLine($"Your wallet id is {walletId}");
                Main();
            }
            else
            {
                System.Console.WriteLine("Unable to register!!!\nKindly change your email!!!");
                SignUp();
            }
        }

        private void SignIn()
        {
            System.Console.WriteLine("Enter your email: ");
            string email = Console.ReadLine();
            System.Console.WriteLine("Enter your Password");
            string password = Console.ReadLine();
            var user = userInterface.Login(email, password);
            try
            {
                if (user != null)
                {
                    System.Console.WriteLine("Login successfully");
                    // customerMenu.customerMain();
                    if (user.role == "SuperAdmin")
                    {
                        SuperAdmin superAdmin = new SuperAdmin();
                        superAdmin.Admin();
                    }
                    else if (user.role == "Customer")
                    {
                        CustomerMenu customer = new CustomerMenu();
                        customer.customerMain();
                    }
                    else
                    {
                        ManagerMenu managerMenu = new ManagerMenu();
                        managerMenu.ManagerMain();
                    }
                }
                else
                {
                    System.Console.WriteLine("Account not found");
                    SignIn();
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}