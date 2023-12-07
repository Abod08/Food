using System;
using System.Collections.Generic;
using FOOD.Menu;

namespace FOOD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // SuperAdmin superadmin = new SuperAdmin();
            // superadmin.Admin();
            
            // List<User> users = Data.DataBase.UserDb;
            // var user = new User(users.Count+1, "Abdullah", "abdul@gmail.com", "12345", "0807", "Abk", Enums.Gender.Male, DateTime.Parse("11/11/2022"), "SuperAdmin");
            // users.Add(user);
            MainMenu m = new();
            m.Main();

        }
    }
}
