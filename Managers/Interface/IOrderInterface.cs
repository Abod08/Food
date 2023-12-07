using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOOD.Managers.Interface
{
    public interface IOrderInterface
    {
        public Order Make(string benefactorWallet, string beneficiaryWallet, double amount, string foodName, int foodPortion);
        public Order Get(string ReferenceNumber);
        public List<Order> GetAll();
        public bool CancelOrder(string ReferenceNumber);
    }
}