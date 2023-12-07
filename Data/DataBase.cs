using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FOOD.Menu;
using FOOD.Model;
using FoodOrdering.Model.Entity;

namespace FOOD.Data
{
    public class DataBase
    {
        public static List<User> UserDb = new List<User>()
        {
        new User(1, "Abdullah", "ab", "12", "0807", "Abk", Enums.Gender.Male, DateTime.Parse("11/11/2022"), "SuperAdmin")

        };
        public static List<Customer> CustomerDb = new List<Customer>();
        public static List<Order> OrderDb = new List<Order>();
        public static List<Food> FoodDb = new List<Food>()
        {
            new Food(1, "Amala", "Swallow", 200, 500),
        };
        public static List<Manager> ManagerDb = new List<Manager>();
        public static List<Wallet> WalletDb = new List<Wallet>()
        {
            new Wallet("ABOD/WLT/001", 0, "Abdullah", "Reference/"+Guid.NewGuid().ToString().Substring(0,5), "ab")
        };
        public static List<Deposit> DepositDb = new List<Deposit>();

    }
}