using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FOOD.Enums;

namespace FOOD.Customers.Interface
{
    public interface ICustomerInterface
    {
        public Customer Register(string Name, string Email, string Password, string PhoneNumber, string Address, Gender Gender, DateTime Dob, double walletAmount);
        public Customer Get(string Email);
        public List<Customer> GetAll();
        
    }
}