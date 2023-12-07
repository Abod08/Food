using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FOOD.Enums;
using FoodOrdering.Model;

namespace FOOD
{
    public class User
    {
        public int id;
        public string name;
        public string email;
        public string password;
        public string phoneNumber;
        public string address;
        
        public Gender gender;
        public DateTime dob;
        public string role;
        
        public User(int Id, string Name, string Email,string Password, string PhoneNumber, string Address, Gender Gender, DateTime Dob, string Role) 
        {
            id = Id;
            name = Name;
            email = Email;
            password = Password;
            phoneNumber = PhoneNumber;
            address = Address;
            gender = Gender;
            dob = Dob;
            role = Role;
        }
    }
}