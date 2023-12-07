using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FOOD.Customers.Interface;
using FOOD.Data;
using FOOD.Managers.Interface;

namespace FOOD.Managers.Implementation
{
    public class OrderManager : IOrderInterface
    {
        // IUserInterface userInterface = new UserManager();
        // IManagerInterface managerInterface = new ManagerManager();
        // ICustomerInterface customerInterface = new CustomerManager();
        IFoodInterface foodInterface = new FoodManager();
        IWalletInterface walletInterface= new WalletManager();
        List<Order> orderDb = DataBase.OrderDb;
        public bool CancelOrder(string ReferenceNumber)
        {
            var order = Get(ReferenceNumber);
            if (order != null)
            {
                orderDb.Remove(order);
                return true;
            }
            return false;
        }

        public Order Get(string ReferenceNumber)
        {
            foreach (var order in orderDb)
            {
                if (order.referenceNumber == ReferenceNumber)
                {
                    return order;
                }
            }
            return null;
        }

        public List<Order> GetAll()
        {
            return orderDb;
        }

        public Order Make(string benefactorWallet, string beneficiaryWallet, double TotalPrice, string FoodName, int foodPortion)
        {
            var customer = walletInterface.Get(benefactorWallet);
            var manager = walletInterface.Get(beneficiaryWallet);
            var foods = foodInterface.Get(FoodName);
            if (customer == null || manager == null)
            {
                System.Console.WriteLine("Neither the customer nor the manager exist!!!");
                return null;
            }
            else
            {

                if (customer.WalletAmount >= TotalPrice)
                {
                    if (foods.portion >= foodPortion && foods.foodName == FoodName)
                    {
                        customer.WalletAmount -= TotalPrice;
                        manager.WalletAmount += TotalPrice;
                        Order order = new Order(orderDb.Count+1, GenReferenceNum(), 0, benefactorWallet, beneficiaryWallet);
                        orderDb.Add(order);
                        System.Console.WriteLine("Payment successful!!!");
                        return order;
                    }
                    else
                    {
                        System.Console.WriteLine("The portion you are trying to purchase is more than the existed portion");
                        return null;
                    }
                }
                else
                {
                    System.Console.WriteLine("Insufficient balance in your wallet!!1");
                    
                    return null;
                }
            }


        }
        private string GenReferenceNum()
        {
            Random num = new Random();
            DateTime date = DateTime.Now;
            string nums = "ABOD/FD/" + num.Next(100, 100000) + date;
            return nums;
        }
    }
}