using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FOOD.Data;
using FOOD.Managers.Interface;
using FOOD.Model;

namespace FOOD.Managers.Implementation
{
    public class WalletManager : IWalletInterface
    {
        List<Wallet> walletDb = DataBase.WalletDb;

        public bool Delete(string walletId)
        {
            foreach (var wallet in walletDb)
            {
                if (wallet.WalletId == walletId)
                {
                    walletDb.Remove(wallet);
                    return true;
                }
            }
            return false;
        }

        public Wallet Get(string walletRef)
        {
            foreach (var wallet in walletDb)
            {
                if (wallet.WalletId == walletRef)
                {
                    return wallet;
                }
            }
            return null;
        }

        public List<Wallet> GetAll()
        {
            return walletDb;
        }

        private string WalletId()
        {
            string nums = "ABOD/WLT/" + Guid.NewGuid().ToString().Substring(0, 5);
            return nums;
        }

        private string GenerateReferenceNumb()
        {
            string refs = "Trans/" + Guid.NewGuid().ToString().Substring(0, 9) + DateTime.Now;
            return refs;
        }

        public Wallet GetByName(string userEmail)
        {
            foreach (var wallet in walletDb)
            {
                if (wallet.UserEmail == userEmail)
                {
                    return wallet;
                }
            }
            return null;
        }

        public Wallet GetBalance(string walletId, string mail)
        {
            foreach (var item in walletDb)
            {
                if (item.WalletId == walletId && item.UserEmail == mail)
                {
                    Console.WriteLine($"Your wallet balance is {item.WalletAmount}");
                }
            }
            return null;
        }
    }
}