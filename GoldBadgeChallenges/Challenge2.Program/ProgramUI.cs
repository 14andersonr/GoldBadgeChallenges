using Challenge2.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2.Program
{
    class ProgramUI
    {
        private readonly ClaimRepo _ClaimRepo = new ClaimRepo();
        public void Run()
        {
            SeedClaimList();
            UIMenu();
        }

        private void UIMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {

                Console.WriteLine("Select a menu option:\n" +
                    "1. See All Claims\n" +
                    "2. Take Care of Next Claim\n" +
                    "3. Enter A New Claim\n\n\n" +
                    "4. View Claims by ID\n" +
                    "5. Update an Existing Claim\n\n" +
                    "6. Exit");

                // Get the user's input
                string input = Console.ReadLine();

                //Evaluate the user's input and act accordingly
                switch (input)
                {
                    case "3":
                        //Create
                        AddNewClaim();
                        break;
                    case "1":
                        //View All
                        DisplayAllClaims();
                        break;
                    case "4":
                        //View by ID
                        DisplayClaimByID();
                        break;
                    case "5":
                        //Update Existing
                        UpdateExistingClaim();
                        break;
                    case "2":
                        //Delete Existing
                        DeleteExistingClaim();
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

        private void AddNewClaim()
        {
            Console.Clear();
            //Build a new object
            Claim newClaim = new Claim();

            //ID Number
            Console.WriteLine("Enter the unique ID of the Claim:");
            newClaim.ClaimID = Console.ReadLine();

            //Type
            Console.WriteLine("Enter the Claim Type number:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft");

            string typeAsString = Console.ReadLine();
            int typeAsInt = int.Parse(typeAsString);
            newClaim.ClaimType = (ClaimType)typeAsInt;

            //Description
            Console.WriteLine("Enter the description of the Claim:");
            newClaim.Description = Console.ReadLine();

            //Amount
            Console.WriteLine("Add the claim amount (ex: 2000.00):");
            string claimAmount = Console.ReadLine();
            double claimAmountDouble = Convert.ToDouble(claimAmount);
            newClaim.ClaimAmount = claimAmountDouble;

            //Date of Incident
            Console.WriteLine("Enter the date of the incident for the Claim (DD-MM-YYYY):");
            string incidentDate = Console.ReadLine();
            DateTime incidentDateTime = Convert.ToDateTime(incidentDate);
            newClaim.DateOfIncident = incidentDateTime;


            //Date of Claim
            Console.WriteLine("Enter the date of the Claim (DD-MM-YYYY):");
            string claimDate = Console.ReadLine();
            DateTime claimDateTime = Convert.ToDateTime(claimDate);
            newClaim.DateOfClaim = claimDateTime;


            //Valid
            DateTime claim = claimDateTime;
            DateTime incident = incidentDateTime;
            int isValid = claim.Day - incident.Day;
            if (isValid < 30)
            {
                newClaim.IsValid = true;
            }
            else
            {
                newClaim.IsValid = false;
            }


            _ClaimRepo.AddClaimToQueue(newClaim);
        }

        private void DisplayAllClaims()
        {
            Console.Clear();
            Claim claim = _ClaimRepo.GetNextClaim();
            DisplayClaims(claim);

        }

        private void NextClaim()
        {
            Claim claim = _ClaimRepo.GetNextClaim();
            if (claim != null)
            {
                DisplayClaims(claim);
              
            }
        }

        private void DisplayClaims(Claim claim)
        {
            Console.WriteLine($"{claim.ClaimID,-10}{claim.ClaimType,-10}{claim.Description,-10}{claim.ClaimAmount,-10}{claim.DateOfIncident, -10}{claim.DateOfClaim,-10}{claim.IsValid,-10}");
        }


        private void DisplayNextInQueue()
        {
            Console.Clear();
            Console.WriteLine("Do you want to deal with the next claim?");
            string input = Console.ReadLine();
            switch(input)
            {
                case "y":
                    NextClaim();
                    break;
                case "n":
                    UIMenu();
                    break;
            }
        }


        private void DisplayClaimByID()
        {
            Console.Clear();

            Console.WriteLine("Enter the unique ID of the Claim you'd like to see:");

            string iD = Console.ReadLine();

            Claim claim = _ClaimRepo.GetClaimByID(iD);

            if (claim != null)
            {
                Console.WriteLine($"Claim ID: {claim.ClaimID},\n" +
                    $" Claim Type: {claim.ClaimType}\n" +
                    $" Claim Description: {claim.Description}\n" +
                    $" Claim Amount: {claim.ClaimAmount}\n" +
                    $" Date of Incident: {claim.DateOfIncident}\n" +
                    $" Date of Claim: {claim.DateOfClaim}\n" +
                    $" Is the claim valid? : {claim.IsValid}");
            }
            else
            {
                Console.WriteLine("No Claim by that ID.");
            } 
        }

        public void UpdateExistingClaim()
        {
            Console.Clear();

            DisplayAllClaims();

            Console.WriteLine("\nEnter the unique ID of the Claim you'd like to update:");

            //Get that Name
            string oldID = Console.ReadLine();

            //Build a new object
            Claim newClaim = new Claim();

                //ID Number
                Console.WriteLine("Enter the unique ID of the Claim:");
                newClaim.ClaimID = Console.ReadLine();

                //Type
                Console.WriteLine("Enter the Claim Type number:\n" +
                    "1. Car\n" +
                    "2. Home\n" +
                    "3. Theft");

                string typeAsString = Console.ReadLine();
                int typeAsInt = int.Parse(typeAsString);
                newClaim.ClaimType = (ClaimType)typeAsInt;

                //Description
                Console.WriteLine("Enter the description of the Claim:");
                newClaim.Description = Console.ReadLine();

                //Amount
                Console.WriteLine("Add the claim amount (ex: 2000.00):");
                string claimAmount = Console.ReadLine();
                double claimAmountDouble = Convert.ToDouble(claimAmount);
                newClaim.ClaimAmount = claimAmountDouble;

                //Date of Incident
                Console.WriteLine("Enter the date of the incident for the Claim (DD-MM-YYYY):");
                string incidentDate = Console.ReadLine();
                DateTime incidentDateTime = Convert.ToDateTime(incidentDate);
                newClaim.DateOfIncident = incidentDateTime;


                //Date of Claim
                Console.WriteLine("Enter the date of the Claim (DD-MM-YYYY):");
                string claimDate = Console.ReadLine();
                DateTime claimDateTime = Convert.ToDateTime(claimDate);
                newClaim.DateOfClaim = claimDateTime;


                //Valid
                DateTime claim = claimDateTime;
                DateTime incident = incidentDateTime;
                int isValid = claim.Day - incident.Day;
                if (isValid < 30)
                {
                    newClaim.IsValid = true;
                }
                else
                {
                    newClaim.IsValid = false;
                }

                //Verify update worked
                bool updateWorked = _ClaimRepo.UpdateExistingClaim(oldID, newClaim);

            if (updateWorked)
            {
                Console.WriteLine("Claim succesfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update the Claim.");
            }

        }

        private void DeleteExistingClaim()
        {
            DisplayAllClaims();

            Console.WriteLine("\nEnter the unique ID of the Claim you'd like to handle");

            string input = Console.ReadLine();

            //Call the Delete Method
            bool wasDeleted = _ClaimRepo.RemoveClaimFromQueue(input);

            if (wasDeleted)
            {
                Console.WriteLine("The Claim was successfully handled.");
            }
            else
            {
                Console.WriteLine("The Claim could not be handled.");
            }


        }

        //Seed Method
        private void SeedClaimList()
        {
            Claim one = new Claim("1", ClaimType.Car, "Car accident on 465", 400.00, DateTime.Parse("2018-04-25"), DateTime.Parse("2018-04-27"), true);
            Claim two = new Claim("2", ClaimType.Home, "House fire in kitchen", 4000.00, DateTime.Parse("2018-04-11"), DateTime.Parse("2018-04-12"), true);
            Claim three = new Claim("3", ClaimType.Theft, "Stolen pancakes", 4.00, DateTime.Parse("2018-04-27"), DateTime.Parse("2018-06-01"), false);

            _ClaimRepo.AddClaimToQueue(one);
            _ClaimRepo.AddClaimToQueue(two);
            _ClaimRepo.AddClaimToQueue(three);

        }
    }
}
