using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FOOD.Data;
using FOOD.Managers.Interface;

namespace FOOD.Managers.Implementation
{
    public class UserManager : IUserInterface
    {
        List<User> userDb = DataBase.UserDb;
        public User Get(string email)
        {
            foreach (var user in userDb)
            {
                if (user.email == email)
                {
                    return user;
                }
            }
            return null;
        }

        public List<User> GetAll()
        {
            return userDb;
        }

        public User Login(string email, string password)
        {
            foreach (var user in userDb)
            {
                if (user.email == email && user.password == password)
                {
                    return user;
                }
            }
            return null;
        }
    }
}