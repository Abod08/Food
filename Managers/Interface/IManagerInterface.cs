using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FOOD.Enums;

namespace FOOD.Managers.Interface
{
    public interface IManagerInterface
    {
        public Manager Register(string Name, string Email, string Password, string PhoneNumber, string Address, Gender Gender, DateTime Dob, string walletId, double walletAmount);
        public Manager Get(string staffTag);
        public List<Manager> GetAll();
        public bool Sack(string staffTag);
    }
}