using Challenge3.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge3.Program
{
    public class ProgramUI
    {
        private readonly BadgeRepo _BadgeRepo = new BadgeRepo();
        public void Run()
        {
            SeedBadgeList();
            UIMenu();
        }

        private void UIMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {

                Console.WriteLine("Hello Security Admin, What would you like to do?:\n" +
                    "1. Add a Badge\n" +
                    "2. List All Badges\n" +
                    "3. View Badges by Unique ID\n" +
                    "4. Edit an Existing Badge\n" +
                    "5. Delete an Existing Badge\n\n" +
                    "6. Exit");

                // Get the user's input
                string input = Console.ReadLine();

                //Evaluate the user's input and act accordingly
                switch (input)
                {
                    case "1":
                        //Create
                        AddNewBadge();
                        break;
                    case "2":
                        //View All
                        DisplayAllBadges();
                        break;
                    case "3":
                        //View by ID
                        DisplayBadgeByID();
                        break;
                    case "4":
                        //Update Existing
                        UpdateExistingBadge();
                        break;
                    case "5":
                        //Delete Existing
                        DeleteExistingBadge();
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

        private void AddNewBadge()
        {
            Console.Clear();
            //Build a new object
            List<string> stringList = new List<string>();

            //ID Number
            Console.WriteLine("Enter the unique ID number for the Badge:");
            string badgeString = Console.ReadLine();
            int badgeInt = Convert.ToInt32(badgeString);

            //List of Doors
            bool keepAsking = true;

            while (keepAsking == true)
            {
                Console.WriteLine("Add the door that the badge has access to:");
                string newDoor = Console.ReadLine();
                stringList.Add(newDoor);
                Console.WriteLine("Any other doors(y/n)?");
                string yesNo = Console.ReadLine().ToLower();
                if (yesNo == "y")
                {
                    keepAsking = true;
                }
                else if (yesNo == "n")
                {
                    keepAsking = false;
                }
                else
                {
                    Console.WriteLine("Please input a valid response.");
                }
            }
            Badge newBadge = new Badge(badgeInt, stringList);
            _BadgeRepo.AddBadgeToDict(newBadge);
        }

        private void DisplayAllBadges()
        {
            Console.Clear();

            Dictionary<int,Badge> badgeDirectory = _BadgeRepo.GetBadgeList();
            

            foreach (var badge in badgeDirectory)
            {
                DisplayBadgeInfo(badge.Value);
            }
        }

        private void DisplayBadgeInfo(Badge badge)
        {
            Console.WriteLine($" Badge ID Number: {badge.BadgeID}\n");
            foreach (var door in badge.DoorNames)
            {
                Console.WriteLine(door);
            }
        }
        private void DisplayBadgeByID()
        {
            Console.Clear();

            Console.WriteLine("Enter the unique ID of the Badge you'd like to see:");

            string iD = Console.ReadLine();
            int iDInt = Convert.ToInt32(iD);

            Badge badge = _BadgeRepo.GetBadgeByDictionaryKey(iDInt);

            if (badge != null)
            {
                Console.WriteLine($" Badge ID Number: {badge.BadgeID}\n" +
                    $" Door Access: {badge.DoorNames}");
            }
            else
            {
                Console.WriteLine("No Badge by that ID.");
            }
        }

        private void UpdateExistingBadge()
        {
            Console.Clear();

            DisplayAllBadges();

            Console.WriteLine("\nEnter the unique ID of the Badge you'd like to update:");

            //Get that Name
            string oldID = Console.ReadLine();
            int oldIDInt = Convert.ToInt32(oldID);


            //Build a new object
            List<string> stringList = new List<string>();

            //ID Number
            Console.WriteLine("Enter the unique ID number for the Badge:");
            string badgeString = Console.ReadLine();
            int badgeInt = Convert.ToInt32(badgeString);

            //List of Doors
            bool keepAsking = true;

            while (keepAsking == true)
            {
                Console.WriteLine("Add the door that the badge has access to:");
                string newDoor = Console.ReadLine();
                stringList.Add(newDoor);
                Console.WriteLine("Any other doors(y/n)?");
                string yesNo = Console.ReadLine().ToLower();
                if (yesNo == "y")
                {
                    keepAsking = true;
                }
                else if (yesNo == "n")
                {
                    keepAsking = false;
                }
                else
                {
                    Console.WriteLine("Please input a valid response.");
                }
            }
            Badge newBadge = new Badge(badgeInt, stringList);

            //Verify update worked
            bool updateWorked = _BadgeRepo.UpdateExistingBadge(oldIDInt, newBadge);

            if (updateWorked)
            {
                Console.WriteLine("Badge succesfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update the Badge.");
            }

        }

        private void DeleteExistingBadge()
        {
            DisplayAllBadges();

            Console.WriteLine("\nEnter the unique ID of the Badge you'd like to remove");

            string input = Console.ReadLine();
            int inputInt = Convert.ToInt32(input);

            //Call the Delete Method
            bool wasDeleted = _BadgeRepo.RemoveBadgeFromDict(inputInt);

            if (wasDeleted)
            {
                Console.WriteLine("The Badge was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The Badge could not be deleted.");
            }


        }

        //Seed Method
        private void SeedBadgeList()
        {
            List<string> listyList = new List<string>();
            listyList.Add("A1");
            listyList.Add("B2");
            
            Badge one = new Badge(1, listyList);
            Badge two = new Badge(2, listyList);
            Badge three = new Badge(3, listyList);

            _BadgeRepo.AddBadgeToDict(one);
            _BadgeRepo.AddBadgeToDict(two);
            _BadgeRepo.AddBadgeToDict(three);

        }
    }
}
