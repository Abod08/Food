using System;
using System.Collections.Generic;
using FOOD.Data;
using FOOD.Managers.Implementation;
using FOOD.Managers.Interface;
using FoodOrdering.Manager.Interface;
using FoodOrdering.Model.Entity;

namespace FoodOrdering.Manager.Implementation
{
    public class DepositManager : IDepositInterface
    {
        IWalletInterface walletInterface = new WalletManager();
        List<Deposit> depositDb = DataBase.DepositDb;

        public Deposit AddMoney(string walletId, double amount)
        {
            var wallet = walletInterface.Get(walletId);
            if (wallet == null)
            {
                return null;
            }
            else if (amount > 0)
            {
                wallet.WalletAmount += amount;
            }
            Deposit deposit = new(depositDb.Count + 1, walletId, amount, GenerateReference());
            depositDb.Add(deposit);
            return deposit; 
        }

        public Deposit Get(string referenceNumber)
        {
            foreach (var deposit in depositDb)
            {
                if (deposit.ReferenceNumber == referenceNumber)
                {
                    return deposit;
                }
            }
            return null;
        }

        public Deposit GetAll()
        {
            foreach (var deposit in depositDb)
            {
                return deposit;
            }
            return null;
        }
        private string GenerateReference()
        {
            Random num = new Random();
            return "ABF/GRN" + num.Next(1000, 9999).ToString();
        }
    }
}