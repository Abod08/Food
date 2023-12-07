using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOOD
{
    public class Order
    {
        public int id;
        public string referenceNumber;
        public double totalPrice;
        public string benefactorWallet;
        public string beneficiaryWallet;
        


        public Order(int Id, string ReferenceNumber, double TotalPrice, string BenefactorWallet, string BeneficiaryWallet)
        {
            id = Id;
            referenceNumber = ReferenceNumber;
            totalPrice = TotalPrice;
            benefactorWallet = BenefactorWallet;
            beneficiaryWallet = BeneficiaryWallet;
        }
    }
}