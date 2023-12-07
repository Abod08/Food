using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodOrdering.Model;

namespace FOOD.Model
{
    public class Wallet
    {

        // public string WalletId = Guid.NewGuid().ToString().Substring(0,5);
        public string WalletId;
        public double WalletAmount;
        public string WalletName;
        public string WalletReference;
        // public string WalletBalance;
        public string UserEmail;


        public Wallet(string walletId, double walletAmount, string walletName, string walletReference, /*string walletBalance,*/ string userEmail)
        {
            WalletId = walletId;
            WalletAmount = walletAmount;
            WalletName = walletName;
            WalletReference = walletReference;
            // WalletBalance = walletBalance; 
            UserEmail = userEmail;
        }

    }
}
