using System;
using KClaims_ClassLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KClaims_ConsoleApp
{
    class ClaimsUI
    {
        private ClaimsRepo _claimsRepo = new ClaimsRepo();
        private Queue<Claims> _claimsQueue = new Queue<Claims>();
        public void Run()
        {
            SeedClaims();
            ClaimsMenu();
        }
        private void ClaimsMenu()
        {
            bool menuUp = true;
            while (menuUp)
            {
                Console.WriteLine("Select an option from the menu below: \n" +
                    "1. Display All Claims in Queue\n" +
                    "2. Take Care of Next Claim in Queue\n" +
                    "3. Enter New Claim\n" +
                    "4. Exit Claims Agent Menu");
                string agentInput = Console.ReadLine();
                switch (agentInput)
                {
                    case "1":
                        DisplayClaimsQueue();
                        break;
                    case "2":
                        HandleNextClaim();
                        break;
                    case "3":
                        EnterNewClaim();
                        break;
                    case "4":
                        Console.WriteLine("The Client will now close.");
                        menuUp = false;
                        break;
                    default:
                        Console.WriteLine("Please select a valid option from the menu..");
                        break;
                }
            }
            Console.WriteLine("Press Any Key to Continue...");
            Console.ReadLine();
            Console.Clear();
        }
        private void EnterNewClaim()
        {
            Console.Clear();
            Claims newClaimElement = new Claims();

            Console.WriteLine("Enter Claim ID: ");
            string ClaimIdAsInt = Console.ReadLine();
            newClaimElement.ClaimId = int.Parse(ClaimIdAsInt);

            Console.WriteLine("Enter Claim Type Number:\n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft\n");
            string typeAsString = Console.ReadLine();
            int typeAsInt = int.Parse(typeAsString);
            newClaimElement.TypeOfClaim = (ClaimType)typeAsInt;

            Console.WriteLine("Enter a Description of the Claim: ");
            newClaimElement.Description = Console.ReadLine();

            Console.WriteLine("Amount of Damage($USD): ");
            string amountAsString = Console.ReadLine();
            newClaimElement.ClaimAmount = double.Parse(amountAsString);

            Console.WriteLine("Date of Incident: (dd/mm/yy) ");
            newClaimElement.DateOfIncidentS = Console.ReadLine();
  
            Console.WriteLine("Date the Claim Was Filed: (dd/mm/yy) ");
            newClaimElement.DateOfClaimS = Console.ReadLine();   
           
            Console.WriteLine("Valid Claim?(y/n): ");
            string isValidString = Console.ReadLine().ToLower();
            if (isValidString == "y")
            {
                newClaimElement.IsValid = true;
            }
            else
            {
                newClaimElement.IsValid = false;
            }
            _claimsRepo.EnterNewClaim(newClaimElement);
        }
        private void DisplayClaimsQueue()
        {
            Console.Clear();
            List<Claims> _claimsList = _claimsRepo.ShowAllClaims();
            foreach (Claims claimElements in _claimsList)
            {
                Console.WriteLine($"Claim ID #: {claimElements.ClaimAmount}\n" +
                    $"Type of Claim: {claimElements.TypeOfClaim}\n" +
                    $"Description: {claimElements.Description}\n" +
                    $"Amount: '$'{claimElements.ClaimAmount}\n" +
                    $"Date Of Incident: {claimElements.DateOfIncidentS}\n" +
                    $"Date Of Claim: {claimElements.DateOfClaimS}\n" +
                    $"ValidClaim: {claimElements.IsValid}\n");
            }
        }
        public void HandleNextClaim()
        {
            _claimsRepo.ViewNextInQueue();

            Console.WriteLine("Do you want to handle the next claim? y/n: ");

            string handleClaim = Console.ReadLine();

            if (handleClaim == "y")
            {
                _claimsQueue.Dequeue();
            }
            if (handleClaim == "n")
            {
                Run();
            }
            else
            {
                Console.WriteLine("Please Enter y/n.");
            }
        }
        private void SeedClaims()
        {
            Claims claimOne = new Claims(1, ClaimType.Car, "Rear-ended on Southport and Emerson.", 475.00, "08/10/20", "8/15/20", true);
            Claims claimTwo = new Claims(2, ClaimType.Home, "Hail damage to balcony, windows, and garage.", 900.00, "10/16/20", "10/30/20", true);
            Claims claimThree = new Claims(3, ClaimType.Car, "Purse stolen at a sporting event", 115.00, "07/20/20", "9/25/20", false);

            _claimsRepo.EnterNewClaim(claimOne);
            _claimsRepo.EnterNewClaim(claimTwo);
            _claimsRepo.EnterNewClaim(claimThree);
        }

    }
}
