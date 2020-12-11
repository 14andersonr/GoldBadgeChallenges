using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1.Repos
{
    public class Menu
    {
        public string MealName { get; set; }
        public string MealIDNumber { get; set; }
        public string MealDescription { get; set; }
        public string ListOfIngredients { get; set; }
        public double MealPrice { get; set; }

        public Menu() { }
        public Menu(string mealName, string mealIDNumber, string mealDescription, string listOfIngredients, double mealPrice)
        {
            MealName = mealName;
            MealIDNumber = mealIDNumber;
            MealDescription  = mealDescription;
            ListOfIngredients = listOfIngredients;
            MealPrice = mealPrice;
        }
    }
}
