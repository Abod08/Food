using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FOOD.Data;
using FOOD.Enums;
using FOOD.Managers.Interface;
using FOOD.Model;

namespace FOOD.Managers.Implementation
{
    public class ManagerManager : IManagerInterface
    {
        List<Wallet> walletDb = DataBase.WalletDb;
        List<User> userDb = DataBase.UserDb;
        List<Manager> managerDb = DataBase.ManagerDb;
        public Manager Get(string email)
        {
            foreach (var manager in managerDb)
            {
                if (manager.userEmail == email)
                {
                    return manager;
                }
            }
            return null;
        }

        public List<Manager> GetAll()
        {
            return managerDb;
        }

        public Manager Register(string Name, string Email, string Password, string PhoneNumber, string Address, Gender Gender, DateTime Dob, string walletId, double walletAmount)
        {
            var exist = Check(Email);
            if (exist)
            {
                var user = new User(userDb.Count + 1, Name, Email, Password, PhoneNumber, Address, Gender, Dob, "Manager");
                userDb.Add(user);

                Wallet wallet = new Wallet(WalletId(), walletAmount, Name, GenerateReferenceNumb(), Email);
                walletDb.Add(wallet);

                var manager = new Manager(managerDb.Count + 1, Email, GenStaffTag());
                managerDb.Add(manager);
                return manager;

            }
            System.Console.WriteLine("E-mail already existed");
            return null;

        }


        public bool Sack(string staffTag)
        {
            var manager = Get(staffTag);
            if (manager != null)
            {
                managerDb.Remove(manager);
                return true;
            }
            return false;
        }

        private bool Check(string email)
        {
            foreach (var manager in managerDb)
            {
                if (manager.userEmail == email)
                {
                    return false;
                }
            }
            return true;
        }

        private string GenStaffTag()
        {
            Random num = new Random();
            var gen = "MN/" + num.Next(01, 100);
            return gen;
        }

        private string WalletId()
        {
            string nums = "ABOD/WLT/" + new Random().Next(100, 100000) + DateTime.Now;
            return nums;
        }

        private string GenerateReferenceNumb()
        {
            string refs = "Trans/" + Guid.NewGuid().ToString().Substring(0, 9) + DateTime.Now;
            return refs;
        }
    }
}