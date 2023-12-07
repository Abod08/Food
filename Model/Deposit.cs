namespace FoodOrdering.Model.Entity
{
    public class Deposit : Baseiden
    {
        public string WalletId;
        public double Amount;
        public string ReferenceNumber;

          public Deposit(int id, string walletId, double amount, string referenceNumber) : base(id)
          {
               WalletId = walletId;
               Amount = amount;
               ReferenceNumber = referenceNumber;
          }
    }
}