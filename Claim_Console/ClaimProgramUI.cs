using Claim_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Claim = Claim_Repository.Claim;

namespace Claim_Console
{
    public class ClaimProgramUI
    {
        private ClaimRepo _claimRepo = new ClaimRepo();
      
        public void Run()
        {
            SeedClaims();

            RunMenu();
        }

        private void SeedClaims()
        {
            Claim car = new Claim(1457, "Car", "Head on collision", 1237.77m, new DateTime(2020, 05, 15), new DateTime(2020, 05, 15), true);
            Claim home = new Claim(3569, "Home", "Basement flood", 18237.77m, new DateTime(2020, 08, 15), new DateTime(2021, 05, 15), false);
            Claim theft = new Claim(1457, "Theft", "Computer stollen", 2237.77m, new DateTime(2018, 02, 15), new DateTime(2018, 03, 1), true);

            _claimRepo.AddClaimToDirectory(car);
            _claimRepo.AddClaimToDirectory(home);
            _claimRepo.AddClaimToDirectory(theft);
        }

        private void RunMenu()
        {
            //Create a menu with options matching up to my Repository

            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();

                Console.WriteLine
                    (
                        "Welcome to Komodo Insurance Claims\n\n" +
                        "Enter the number of your selection:\n" +
                        "1. Create new claim\n" +
                        "2. Show all claims\n" +
                        "3. Take care of next claim\n" +
                        "4. Exit"
                    );

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        //Create new
                        CreateNewClaim();
                        break;
                    case "2":
                        //Show all 
                        ShowAllClaims();
                        break;
                    case "3":
                        //Take care of claim
                        TakeCareOfClaim();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 4.\n" +
                            "Press any key to continue");
                        Console.ReadKey();
                        break;

                }
            }
        }

        private void CreateNewClaim()
        {
            Console.Clear();

            Claim claim = new Claim();

            Console.WriteLine("Please enter a Claim ID: ");
            claim.ClaimNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please enter the Claim Type (Car, Home, Theft): ");
            claim.ClaimType = Console.ReadLine();

            Console.WriteLine("Please enter the Claim Description: ");
            claim.Description = Console.ReadLine();

            Console.WriteLine("Please enter the Claim Amount: ");
            claim.Amount = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Please enter the Date of Incident: ");
            claim.DateOfIncident = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Please enter the Date of Claim: ");
            claim.DateOfClaim = Convert.ToDateTime(Console.ReadLine());

            _claimRepo.AddClaimToDirectory(claim);
        }

        private void ShowAllClaims()
        {
            Console.Clear();

            List<Claim> listOfClaims = _claimRepo.GetClaims();

            foreach(Claim claim in listOfClaims)
            {
                DisplayClaim(claim);
            }
            PressAnyKey();
        }

        private void PressAnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void DisplayClaim(Claim claim)
        {
           
            int index = 1;

            Console.WriteLine($"{"Claim ID", -10}{"Type", -15}{"Description", -25}{"Amount", -15}{"Date of Incident", -20}{"Date of Claim", -20}{"Valid Claim", -15} \n\n");
            Console.WriteLine($"{index, -10}. {claim.ClaimNumber, -15}" +
                    $"{claim.ClaimType, -15}{claim.Description, -25}{claim.Amount, -15}" +
                    $"{claim.DateOfIncident, -20}{claim.DateOfClaim, -20}{claim.IsValid, -15}");
        }

        private void TakeCareOfClaim()
        {
         

            List<Claim> claimList = _claimRepo.GetClaims();

            int index = 1;

            Console.WriteLine("Claim ID\t\tType\t\tDescription\t\tAmount\t\t" +
                "Date of Incident\t\tDate of Claim\t\tValid Claim"); Console.WriteLine($"{"Claim ID",-10}{"Type",-15}{"Description",-25}{"Amount",-15}{"Date of Incident",-20}{"Date of Claim",-20}{"Valid Claim",-15} \n\n");

            foreach (Claim claim in claimList)
            {
                Console.WriteLine($"{index,-10}. {claim.ClaimNumber,-15}" +
                    $"{claim.ClaimType,-15}{claim.Description,-25}{claim.Amount,-15}" +
                    $"{claim.DateOfIncident,-20}{claim.DateOfClaim,-20}{claim.IsValid,-15}");
                index++;
            }

            Console.WriteLine("Do you want to deal with this claim now (y/n)? ");
       
            bool canRun = true;

            while (canRun)
            {
                string response = Console.ReadLine();
                if (response.ToLower() == "y")
                {
                    _claimRepo.DeleteClaim(claimList[0]);
                    Console.WriteLine("The claim has been dealt with.\n" +
                        "Would you like to deal with another claim now (y/n)?");
                    Console.ReadKey();
                }
                else
                {
                    canRun = false;
                    PressAnyKey();
                }

            }

        }

    }
}
