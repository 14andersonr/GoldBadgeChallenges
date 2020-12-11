using Challenge2.Repos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Challenge2.UnitTest
{
    [TestClass]
    public class Challenge2_RepoTests
    { //Up here we are Arranging permanently throughout the sheet.
        private ClaimRepo _claimDirectory;
        private Claim _claim;

        [TestInitialize]
        public void Arrange()
        {
            _claimDirectory = new ClaimRepo();
            _claim = new Claim("1", ClaimType.Car, "Car accident on 465", 400.00, DateTime.Parse("2018-04-25"), DateTime.Parse("2018-04-27"), true);

            _claimDirectory.AddClaimToQueue(_claim);
        }
        //Add Method
        [TestMethod]
        public void AddToMenu_ShouldGetNotNull()
        {
            //Arrange --> Setting up the Playing Field
            Claim claim = new Claim("1", ClaimType.Car, "Car accident on 465", 400.00, DateTime.Parse("2018-04-25"), DateTime.Parse("2018-04-27"), true);
            ClaimRepo repo = new ClaimRepo();


            //Act --> Get/run the code we want to test
            repo.AddClaimToQueue(claim);
            Claim claimFromDirectory = repo.GetClaimByID("1");

            //Assert --> Use the assert class to verify the expected outcome.
            Assert.IsNotNull(claimFromDirectory);
        }

        //Update
        [TestMethod]
        public void UpdateExistingClaim_ShouldReturnTrue()
        {
            //Arrange
            //TestInitialize
            Claim newMeal = new Claim("1", ClaimType.Car, "Car accident on 465", 400.00, DateTime.Parse("2018-04-25"), DateTime.Parse("2018-04-27"), true);

            //Act
            bool updateResult = _claimDirectory.UpdateExistingClaim("1", newMeal);

            //Assert
            Assert.IsTrue(updateResult);
        }

        [DataTestMethod]
        [DataRow("1", true)]
        [DataRow("2", false)]
        public void UpdateExistingClaim_ShouldMatchGivenBool(string originalName, bool shouldUpdate)
        {
            //Arrange
            //TestInitialize
            Claim newMeal = new Claim("1", ClaimType.Car, "Car accident on 465", 400.00, DateTime.Parse("2018-04-25"), DateTime.Parse("2018-04-27"), true);

            //Act
            bool updateResult = _claimDirectory.UpdateExistingClaim(originalName, newMeal);

            //Assert
            Assert.AreEqual(shouldUpdate, updateResult);
        }

        [TestMethod]
        public void DeleteMeal_ShouldReturnTrue()
        {
            //Arrange

            //Act
            bool deleteResult = _claimDirectory.RemoveClaimFromQueue(_claim.ClaimID);

            //Assert
            Assert.IsTrue(deleteResult);
        }
    }
}
