using Challenge3.Repos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Challenge3.UnitTest
{
    [TestClass]
    public class Challenge3_RepoTests
    {  //Up here we are Arranging permanently throughout the sheet.
        private BadgeRepo _badgeDirectory;
        private Badge _badge;


        [TestInitialize]
        public void Arrange()
        {
            List<string> listyList = new List<string>();
            listyList.Add("A1");
            listyList.Add("B2");
            _badgeDirectory = new BadgeRepo();
            _badge = new Badge(1, listyList);

            _badgeDirectory.AddBadgeToDict(_badge);
        }
        //Add Method
        [TestMethod]
        public void AddToDict_ShouldGetNotNull()
        {
            //Arrange --> Setting up the Playing Field
            List<string> listyList = new List<string>();
            listyList.Add("A1");
            listyList.Add("B2");
            Badge badge = new Badge(1, listyList);
            BadgeRepo repo = new BadgeRepo();


            //Act --> Get/run the code we want to test
            repo.AddBadgeToDict(badge);
            Badge badgeFromDirectory = repo.GetBadgeByDictionaryKey(1);

            //Assert --> Use the assert class to verify the expected outcome.
            Assert.IsNotNull(badgeFromDirectory);
        }

        //Update
        [TestMethod]
        public void UpdateExistingBadge_ShouldReturnTrue()
        {
            //Arrange
            //TestInitialize
            List<string> listyList = new List<string>();
            listyList.Add("A1");
            listyList.Add("B2");
            Badge newBadge = new Badge(1, listyList);

            //Act
            bool updateResult = _badgeDirectory.UpdateExistingBadge(1, newBadge);

            //Assert
            Assert.IsTrue(updateResult);
        }

        [DataTestMethod]
        [DataRow(1, true)]
        [DataRow(2, false)]
        public void UpdateExistingBadge_ShouldMatchGivenBool(int originalName, bool shouldUpdate)
        {
            //Arrange
            //TestInitialize
            List<string> listyList = new List<string>();
            listyList.Add("A1");
            listyList.Add("B2");
            Badge newBadge = new Badge(1, listyList);

            //Act
            bool updateResult = _badgeDirectory.UpdateExistingBadge(originalName, newBadge);

            //Assert
            Assert.AreEqual(shouldUpdate, updateResult);
        }

        [TestMethod]
        public void DeleteBadge_ShouldReturnTrue()
        {
            //Arrange

            //Act
            bool deleteResult = _badgeDirectory.RemoveBadgeFromDict(_badge.BadgeID);

            //Assert
            Assert.IsTrue(deleteResult);
        }
    }
}
