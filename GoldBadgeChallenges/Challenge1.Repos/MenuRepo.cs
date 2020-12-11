using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1.Repos
{
    public class MenuRepo
    {
        private readonly List<Menu> _mealDirectory = new List<Menu>();


        // Create
        public void AddMealToList(Menu food)
        {
            _mealDirectory.Add(food); //Fields have underscores. Properties don't
        }

        // Read
        public List<Menu> GetMealList()
        {
            return _mealDirectory;
        }

        // Update
        public bool UpdateExistingMeal(string originalID, Menu newID)
        {
            //Find
            Menu oldID = GetMealByID(originalID);

            //Update
            if (oldID != null)
            {
                oldID.MealName = newID.MealName;
                oldID.MealIDNumber = newID.MealIDNumber;
                oldID.MealDescription = newID.MealDescription;
                oldID.ListOfIngredients = newID.ListOfIngredients;
                oldID.MealPrice = newID.MealPrice;

                return true;
            }
            else
            {
                return false;
            }
        }

        // Delete
        public bool RemoveMealFromList(string iD)
        {
            Menu meal = GetMealByID(iD);

            if (meal == null)
            {
                return false;
            }

            int initialCount = _mealDirectory.Count;
            _mealDirectory.Remove(meal);

            if (initialCount > _mealDirectory.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Helper (Get Meal by ID)
        public Menu GetMealByID(string iD)
        {
            foreach (Menu meal in _mealDirectory)
            {
                if (meal.MealIDNumber == iD)
                {
                    return meal;
                }
            }

            return null;
        }
    }
}
