using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOOD
{
    public class Food
    {
        public int id;
        public string foodName;
        public string foodType;
        public int portion;
        public double price;
        
        public Food(int Id, string FoodName, string FoodType, int Portion, double Price)
        {
            id = Id;
            foodName = FoodName;
            foodType = FoodType;
            portion = Portion;
            price = Price;
        }
    }
}