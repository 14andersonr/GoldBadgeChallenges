using Challenge1.Repos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Challenge1.UnitTest
{
    [TestClass]
    public class Challenge1_RepoTests
    {

        //Up here we are Arranging permanently throughout the sheet.
        private MenuRepo _mealDirectory;
        private Menu _menu;

        [TestInitialize]
        public void Arrange()
        {
            _mealDirectory = new MenuRepo();
            _menu = new Menu("The Spag Bol", "1", "A classic spaghetti with red sauce.", "1 Spaghetti, 1 Bologniase", 12.99);

            _mealDirectory.AddMealToList(_menu);
        }
        //Add Method
        [TestMethod]
        public void AddToMenu_ShouldGetNotNull()
        {
            //Arrange --> Setting up the Playing Field
            Menu meal = new Menu("The Spag Bol", "1", "A classic spaghetti with red sauce.", "1 Spaghetti, 1 Bologniase", 12.99);
            MenuRepo repo = new MenuRepo();


            //Act --> Get/run the code we want to test
            repo.AddMealToList(meal);
            Menu mealFromDirectory = repo.GetMealByID("1");

            //Assert --> Use the assert class to verify the expected outcome.
            Assert.IsNotNull(mealFromDirectory);
        }

        //Update
        [TestMethod]
        public void UpdateExistingMeal_ShouldReturnTrue()
        {
            //Arrange
            //TestInitialize
            Menu newMeal = new Menu("The Spag Bol", "1", "A classic spaghetti with red sauce.", "1 Spaghetti, 1 Bologniase", 12.99);

            //Act
            bool updateResult = _mealDirectory.UpdateExistingMeal("1", newMeal);

            //Assert
            Assert.IsTrue(updateResult);
        }

        [DataTestMethod]
        [DataRow("1", true)]
        [DataRow("2", false)]
        public void UpdateExistingMeal_ShouldMatchGivenBool(string originalName, bool shouldUpdate)
        {
            //Arrange
            //TestInitialize
            Menu newMeal = new Menu("The Spag Bol", "1", "A classic spaghetti with red sauce.", "1 Spaghetti, 1 Bologniase", 12.99);

            //Act
            bool updateResult = _mealDirectory.UpdateExistingMeal(originalName, newMeal);

            //Assert
            Assert.AreEqual(shouldUpdate, updateResult);
        }

        [TestMethod]
        public void DeleteMeal_ShouldReturnTrue()
        {
            //Arrange

            //Act
            bool deleteResult = _mealDirectory.RemoveMealFromList(_menu.MealIDNumber);

            //Assert
            Assert.IsTrue(deleteResult);
        }
    }
}
