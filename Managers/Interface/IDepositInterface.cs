using FoodOrdering.Model.Entity;

namespace FoodOrdering.Manager.Interface
{
    public interface IDepositInterface
    {
         public Deposit AddMoney(string walletId, double amount);
         public Deposit Get(string referenceNumber);
         public Deposit GetAll();
    }
}