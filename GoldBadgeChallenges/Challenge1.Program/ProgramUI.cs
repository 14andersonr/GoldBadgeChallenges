using Challenge1.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1.Program
{
    public class ProgramUI
    {
        private readonly MenuRepo _MenuRepo = new MenuRepo();
        public void Run()
        {
            SeedMealList();
            UIMenu();
        }

        private void UIMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {

                Console.WriteLine("Select a menu option:\n" +
                    "1. Add a new Meal\n" +
                    "2. View All Meals\n" +
                    "3. View Meals by Unique ID\n" +
                    "4. Update Existing Meal\n" +
                    "5. Delete Existing Meal\n\n" +
                    "6. Exit");

                // Get the user's input
                string input = Console.ReadLine();

                //Evaluate the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        //Create
                        AddNewMeal();
                        break;
                    case "2":
                        //View All
                        DisplayMenu();
                        break;
                    case "3":
                        //View by ID
                        DisplayMealsByID();
                        break;
                    case "4":
                        //Update Existing
                        UpdateExistingMeal();
                        break;
                    case "5":
                        //Delete Existing
                        DeleteExistingMeal();
                        break;
                    case "6":
                        //Exit
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void AddNewMeal()
        {
            Console.Clear();
            //Build a new object
            Menu newMeal = new Menu();

            //Name
            Console.WriteLine("Enter the name of the Meal:");
            newMeal.MealName = Console.ReadLine();

            //ID Number
            Console.WriteLine("Enter the unique ID number for the Meal:");
            newMeal.MealIDNumber = Console.ReadLine();

            //Description
            Console.WriteLine("Describe the meal.");
            newMeal.MealIDNumber = Console.ReadLine();

            //List of Ingredients
            Console.WriteLine("Add the ingredients for the meal separated by commas.");
            newMeal.MealIDNumber = Console.ReadLine();

            //Price
            Console.WriteLine("What is the price of the meal?");
            string mealPrice = Console.ReadLine();
            double mealPriceDouble = Convert.ToDouble(mealPrice);
            newMeal.MealPrice = mealPriceDouble;

            _MenuRepo.AddMealToList(newMeal);
        }

        private void DisplayMenu()
        {
            Console.Clear();

            List<Menu> mealDirectory = _MenuRepo.GetMealList();

            foreach (Menu meal in mealDirectory)
            {
                Console.WriteLine($"Meal Name: {meal.MealName},\n" +
                    $" Meal ID Number: {meal.MealIDNumber}\n" +
                    $" Meal Description: {meal.MealDescription}\n" +
                    $" Meal Ingredients: {meal.ListOfIngredients}\n" +
                    $" Meal Price: {meal.MealPrice}");
            }
        }

        private void DisplayMealsByID()
        {
            Console.Clear();

            Console.WriteLine("Enter the unique ID of the Meal you'd like to see:");

            string iD = Console.ReadLine();

            Menu meal = _MenuRepo.GetMealByID(iD);

            if (meal != null)
            {
                Console.WriteLine($"Meal Name: {meal.MealName},\n" +
                    $" Meal ID Number: {meal.MealIDNumber}\n" +
                    $" Meal Description: {meal.MealDescription}\n" +
                    $" Meal Ingredients: {meal.ListOfIngredients}\n" +
                    $" Meal Price: {meal.MealPrice}");
            }
            else
            {
                Console.WriteLine("No Meal by that ID.");
            }
        }

        private void UpdateExistingMeal()
        {
            Console.Clear();

            DisplayMenu();

            Console.WriteLine("\nEnter the unique ID of the Meal you'd like to update:");

            //Get that Name
            string oldID = Console.ReadLine();

            //Build a new object
            Menu newMeal = new Menu();

            //Name
            Console.WriteLine("Enter the name of the Meal:");
            newMeal.MealName = Console.ReadLine();

            //ID Number
            Console.WriteLine("Enter the unique ID number for the Meal:");
            newMeal.MealIDNumber = Console.ReadLine();

            //Description
            Console.WriteLine("Describe the meal.");
            newMeal.MealIDNumber = Console.ReadLine();

            //List of Ingredients
            Console.WriteLine("Add the ingredients for the meal separated by commas.");
            newMeal.MealIDNumber = Console.ReadLine();

            //Price
            Console.WriteLine("What is the price of the meal?");
            string mealPrice = Console.ReadLine();
            double mealPriceDouble = Convert.ToDouble(mealPrice);
            newMeal.MealPrice = mealPriceDouble;

            //Verify update worked
            bool updateWorked = _MenuRepo.UpdateExistingMeal(oldID, newMeal);

            if (updateWorked)
            {
                Console.WriteLine("Meal succesfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update the Meal.");
            }

        }

        private void DeleteExistingMeal()
        {
            DisplayMenu();

            Console.WriteLine("\nEnter the unique ID of the Meal you'd like to remove");

            string input = Console.ReadLine();

            //Call the Delete Method
            bool wasDeleted = _MenuRepo.RemoveMealFromList(input);

            if (wasDeleted)
            {
                Console.WriteLine("The Meal was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The Meal could not be deleted.");
            }


        }

        //Seed Method
        private void SeedMealList()
        {
            Menu spaghetti = new Menu("The Spag Bol", "1", "A classic spaghetti with red sauce.", "1 Spaghetti, 1 Bologniase", 12.99);
            Menu pizza = new Menu("The Big Round One", "2", "A classic pizza with red sauce.", "1 Dough, 1 Cheese, Lots of Veggies", 15.99);
            Menu chickenAlfredo = new Menu("Chicky Alf", "3", "A classic penne with alfredo sauce and chicken.", "1 Penne, 1 Alfredo, 1 Chicken", 13.99);

            _MenuRepo.AddMealToList(spaghetti);
            _MenuRepo.AddMealToList(pizza);
            _MenuRepo.AddMealToList(chickenAlfredo);

        }
    }

}
