using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOOD
{
    public class Customer
    {
        public int id;
        public string userEmail;
        public string TagNumber;
        public double wallet;

        public Customer(int Id, string UserEmail, string tagNumber, double Wallet)
        {
            id = Id;
            userEmail = UserEmail;
            TagNumber = tagNumber;
            wallet = Wallet;
        }
    }
}