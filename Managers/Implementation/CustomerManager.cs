using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FOOD.Customers.Interface;
using FOOD.Data;
using FOOD.Enums;
using FOOD.Managers.Interface;
using FOOD.Model;

namespace FOOD.Managers.Implementation
{
    public class CustomerManager : ICustomerInterface
    {
        IUserInterface userInterface = new UserManager();
        IWalletInterface walletInterface = new WalletManager();
        List<Wallet> walletDb = DataBase.WalletDb;
        List<Customer> customerDb = DataBase.CustomerDb;
        List<User> userDb = DataBase.UserDb;
        public Customer Get(string Email)
        {
            foreach (var customer in customerDb)
            {
                if (customer.userEmail == Email)
                {
                    return customer;
                }
            }
            return null;
        }

        public List<Customer> GetAll()
        {
            return customerDb;
        }

        public Customer Register(string Name, string Email, string Password, string PhoneNumber, string Address, Gender Gender, DateTime Dob, double walletAmount)
        {
            var existed = Check(Email);
            if (existed)
            {
                var user = new User(userDb.Count + 1, Name, Email, Password, PhoneNumber, Address, Gender, Dob, "Customer");
                userDb.Add(user);

                var customer = new Customer(customerDb.Count + 1, Email, GenCustomerNum(), 0);
                customerDb.Add(customer);

                Wallet wallet = new Wallet(WalletId(), 0, Name, GenerateReferenceNumb(), Email);
                walletDb.Add(wallet);
               
                return customer;
            }
            System.Console.WriteLine("User already existed");
            return null;
        }

        private bool Check(string email)
        {
            foreach (var customer in customerDb)
            {
                if (customer.userEmail == email)
                {
                    return false;
                }
            }
            return true;
        }

        private string GenCustomerNum()
        {
            Random num = new Random();
            var gen = "CUS/" + num.Next(01, 1000);
            return gen;
        }

        private string WalletId()
        {
            Random num = new Random();
            string nums = "ABOD/WLT/" + num.Next(100, 100000);
            return nums;
        }

        private string GenerateReferenceNumb()
        {
            string refs = "Trans/"+ Guid.NewGuid().ToString().Substring(0,9)+DateTime.Now;
            return refs;
        }
    }
}