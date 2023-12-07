using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FOOD.Data;
using FOOD.Managers.Interface;

namespace FOOD.Managers.Implementation
{
    public class FoodManager : IFoodInterface
    {
        List<Food> foodDb = DataBase.FoodDb;
       
        public Food Create(string FoodName, string FoodType, int Portion, double Price)
        {
            var check = Get(FoodName);
            if (check  != null)
            {
                System.Console.WriteLine("FOOD ALREADY EXIST");
            }

            Food food = new Food(foodDb.Count+1, FoodName, FoodType, Portion, Price);
            foodDb.Add(food);
            return food;
        }

        public bool Delete(string FoodName)
        {
            var exists = Get(FoodName);
            if (exists != null)
            {
                foodDb.Remove(exists);
                return true;
            }
            return false;
            
        }

        public Food Get(string FoodName)
        {
            foreach (var x in foodDb)
            {
                if (x.foodName == FoodName)
                {
                    return x;
                }
            }
            return null;
        }

        public List<Food> GetAll()
        {
            return foodDb;
        }

        public bool Check(string FoodName)
        {
            foreach (var foodName in foodDb)
            {
                if (foodName.foodName == FoodName)
                {
                    return false;
                }
            }
            return true;
        }

       
    }
}