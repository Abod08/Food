using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FOOD.Model;

namespace FOOD.Managers.Interface
{
    public interface IWalletInterface
    {
        // public Wallet Create(string walletId, double walletAmount, string walletName, string walletReference);
        // public Wallet Create(double walletAmount, string walletName);
        public Wallet Get(string walletId);
        public Wallet GetBalance(string walletId, string userEmail);
        public Wallet GetByName(string userEmail);
        public List<Wallet> GetAll();
        // public bool FundWallet(string email, double amount);
        public bool Delete(string walletId);
    }
}