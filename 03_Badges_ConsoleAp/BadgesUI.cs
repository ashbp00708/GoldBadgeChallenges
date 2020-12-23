using _03_Badges_ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_ConsoleApp
{
    class BadgesUI
    {
        private BadgesRepo _badgesRepo = new BadgesRepo();

        public void Run()
        {
            BadgeMenu();
        }
        private void BadgeMenu()
        {
            bool keepMenuUp = true;
            while (keepMenuUp)
            {
                Console.WriteLine("Welcome Security Admin. Select an option to continue:\n" +
                    "1. Create a new badge.\n" +
                    "2. Update door access of an existing badge.\n" +
                    "3. Delete door access from an existing badge.\n" +
                    "4. View all badge ID's and corresponding door access.\n" +
                    "5. Exit Security Menu");
                string adminInput = Console.ReadLine();
                switch (adminInput)
                {
                    case "1":
                        CreateNewBadge();
                        break;
                    case "2":
                        UpdateBadgeAccess();
                        break;
                    case "3":
                        DeleteDoorFromBadge();
                        break;
                    case "4":
                        ListAllBadges();
                        break;
                    case "5":
                        Console.WriteLine("Now Exiting Admin Security Menu...");
                        keepMenuUp = false;
                        break;
                    default:
                        Console.WriteLine("Please select valid number option.");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void CreateNewBadge()
        {
            Console.Clear();
            Badges newBadge = new Badges();
            Console.WriteLine("Enter the badge ID number associated with the new badge: ");
            string badgeIDAsString = Console.ReadLine();
            newBadge.BadgeID = int.Parse(badgeIDAsString);
            Console.WriteLine("What door needs to be accessed with the new badge (include multiple if necessary)?");
            newBadge.DoorNames = Console.ReadLine();

            _badgesRepo.CreateNewBadge(newBadge.BadgeID, newBadge);
        }
        private void UpdateBadgeAccess()
        {
            Console.Clear();
            Console.WriteLine("\n" + "Enter the ID of the badge you would like to update: ");
            string iDNumberString = Console.ReadLine();
            int userInput = int.Parse(iDNumberString);

            Console.WriteLine("Current badge data: " + _badgesRepo.SearchBadgeID(userInput) + ".");
            Console.WriteLine("Which door would you like to grant access to?: ");
        }

        private void ListAllBadges()
        {
            Console.Clear();

            IReadOnlyDictionary<int, Badges> keyValuePairs = _badgesRepo.ListAllBadges();

            foreach (object key in keyValuePairs)
            {
                Console.WriteLine("Badge ID: {int claimId}");
              }
            foreach(object value in keyValuePairs)
            {
                Console.WriteLine("Badge Value: {Badges doorAccess}");
            }
        }
           private void DeleteDoorFromBadge()
        {
            ListAllBadges();
            Console.WriteLine("Enter the ID of the Badge you wish to delete door access from: ");
            string inputAsString = Console.ReadLine();
            int userInput = int.Parse(inputAsString);
            bool accessDeleted = _badgesRepo.DeleteDoorFromBadge(userInput);

            if(accessDeleted)
            {
                Console.WriteLine("The Access was removed from the badge");
            }
            else
            {
                Console.WriteLine("The acces was unable to be removed from the badge.");
            }
        }
      
    }
}


