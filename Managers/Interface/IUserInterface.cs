using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOOD.Managers.Interface
{
    public interface IUserInterface
    {
        public User Login(string email, string password);
        public User Get(string email);
        public List<User> GetAll();
        
    }
}