using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCafe_ClassLibrary
{
    public class CafeMenu
    {
        public string MealName { get; set; }
        public string Description { get; set; }
        public int MealNumber { get; set; }
        public string Ingredient { get; set; }
        public double Price { get; set; }
        public CafeMenu() { }
        public CafeMenu(string mealName, string description, int mealNumber, string ingredient, double price)
        {
            MealName = mealName;
            Description = description;
            MealNumber = mealNumber;
            Ingredient = ingredient;
            Price = price;
        }
    }
}

    

