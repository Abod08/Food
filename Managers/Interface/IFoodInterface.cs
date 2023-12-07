using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOOD.Managers.Interface
{
    public interface IFoodInterface
    {
        public Food Create(string FoodName, string FoodType, int Portion, double Price);
        public Food Get(string FoodName);
        public List<Food> GetAll();
        public bool Delete(string FoodName);
    }
}