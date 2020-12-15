using KCafe_ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenges
{
    class CafeUI
    {
        private CafeRepo _cafeRepo = new CafeRepo();
        private CafeMenu _cafeMenu = new CafeMenu();
        private List<CafeMenu> _listOfMenuItems = new List<CafeMenu>();
        private List<string> _listOfIngredients = new List<string>();
        public void Run()
        {
            SeedMenuMeals();
            CafeMenu();

        }
        private void CafeMenu()
        {
            bool stillUsingMenu = true;
            while (stillUsingMenu) 
            {
                Console.WriteLine("Select the appropriate option from the menu below:\n" +
                    "1. Add New Meal to Cafe Menu\n" +
                    "2. View Current Meals on Cafe Menu\n" +
                    "3. Change Existing Meal on Cafe Menu\n" +
                    "4. Delete Meal from Cafe Menu\n" +
                    "5. Exit Cafe Menu Client");

                string userSelection = Console.ReadLine();

                switch (userSelection)
                {
                    case "1":
                        AddToCafeMenu();
                        break;
                    case "2":
                        ShowFullCafeMenu();
                        break;
                    case "3":
                        UpdateCafeMenuMeal();
                        break;
                    case "4":
                        RemoveMealFromMenu();
                        break;
                    case "5":
                        Console.WriteLine("Exiting Client...");
                        stillUsingMenu = false;
                        break;
                    default:
                        Console.WriteLine("Please Select a Valid, Numerical Option from the Menu.");
                        break;

                }
                Console.WriteLine("Press Any Key to Continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void AddToCafeMenu()
        {
            Console.Clear();
            CafeMenu newMenuItem = new CafeMenu();
            Console.WriteLine("Enter a name for the new meal: ");
            newMenuItem.MealName = Console.ReadLine();
            Console.WriteLine("Enter a description for the new meal: ");
            newMenuItem.Description = Console.ReadLine();
            Console.WriteLine("Assign a combo number to the new meal: ");
            string MealNumberString = Console.ReadLine();
            newMenuItem.MealNumber = int.Parse(MealNumberString);
            Console.WriteLine("Enter the ingredients included in the new meal items: ");
            newMenuItem.Ingredient = Console.ReadLine();
            Console.WriteLine("Enter a price of the new meal: ");
            string PriceString = Console.ReadLine();
            newMenuItem.Price = double.Parse(PriceString);
            _cafeRepo.AddToCafeMenu(newMenuItem);
        }
        
         
        
        private void ShowFullCafeMenu()
        {
            Console.Clear();
            List<CafeMenu> _listOfMenuItems = _cafeRepo.ShowFullCafeMenu();
            foreach (CafeMenu menuItem in _listOfMenuItems)
            {
                Console.WriteLine($"MealName:{menuItem.MealName}\n" +
                    $"Description: {menuItem.Description}\n" +
                    $"MealNumber: {menuItem.MealNumber}\n" +
                    $"Price: {menuItem.Price}");
            }

        }
        private void UpdateCafeMenuMeal()
        {
            ShowFullCafeMenu();
            Console.WriteLine("\n" + "Search the name of the meal you would like to update.");
            string oldMealName = Console.ReadLine();
            CafeMenu newMenuItem = new CafeMenu();
            Console.WriteLine("Enter the updated name for the meal: ");
            newMenuItem.MealName = Console.ReadLine();
            Console.WriteLine("Enter the updated description of the meal: ");
            newMenuItem.Description = Console.ReadLine();
            Console.WriteLine("Enter the updated combo number for the meal: ");
            string NewMealNumberString = Console.ReadLine();
            newMenuItem.MealNumber = int.Parse(NewMealNumberString);
            Console.WriteLine("Enter the new ingredients included in the meal menu items: ");
            newMenuItem.Ingredient = Console.ReadLine();
            Console.WriteLine("Enter the new price of the meal: ");
            string NewPriceString = Console.ReadLine();
            newMenuItem.Price = double.Parse(NewPriceString);

            bool updateSuccessful = _cafeRepo.UpdateCafeMenuMeal(oldMealName, newMenuItem);
            if (updateSuccessful)
            {
                Console.WriteLine("Cafe menu item has been successfully updated.");
            }
            else
            {
                Console.WriteLine("Opps! The system could not successfully update the Cafe Menu.");
            }
        }
        private void RemoveMealFromMenu()
        {
            ShowFullCafeMenu();
            Console.WriteLine("\n"+
                "Search the name of the meal you would like to remove from the Cafe Menu: ");
            string userInput = Console.ReadLine();

            bool deletedSuccessfully = _cafeRepo.RemoveMealFromMenu(userInput);
            if(deletedSuccessfully)
            {
                Console.WriteLine("The meal was successfully removed from the Cafe Menu.");
            }
            else
            {
                Console.WriteLine("Opps! The system could not sucessfully remove the meal from the Cafe Menu.");
            }
        }
      
       
        private void SeedMenuMeals()
        {
            CafeMenu BLT = new CafeMenu("BLT", "BLT sandwich on wheat bread, served with house chips and a medium beverage.", 1, "bacon, tomato, lettuce, mayo, wheat bread, homemade potato chips", 7.99);
            CafeMenu Club = new CafeMenu("Club Sandwich", "Deli Club sandwhich on sourdough bread, served with house chips and a medium beverage.", 2, "ham, turkey, bacon, honeymustard, lettuce, sourdough bread, homemade potato chips", 8.99);
            CafeMenu Turkey = new CafeMenu("Turkey Avocado", "Roasted Turkey Avocodo sandwich on wheat bread, served with house chips and a medium beverage.", 3, "turkey, avocado, mayo, lettuce, tomato, wheat bread, homemade potato chips", 8.99);
            CafeMenu VeggieClub = new CafeMenu("Veggie Club", "Veggie sandwich on french bread, served with house chips and a medium beverage", 4, "lettuce, tomato, spinach, green peppers, banana peppers, honeymustard, french white bread, homemade potato chips", 7.99);
            CafeMenu ChickenClub = new CafeMenu("Chicken Club", "Roasted Chicken and bacon on a toasted brioche bun, served with house chips and a medium beverage", 5, "roasted chicken breast, bacon, lettuce, tomato, ranch, brioche bun, homemade potato chips", 9.99);

            _cafeRepo.AddToCafeMenu(BLT);
            _cafeRepo.AddToCafeMenu(Club);
            _cafeRepo.AddToCafeMenu(Turkey);
            _cafeRepo.AddToCafeMenu(VeggieClub);
            _cafeRepo.AddToCafeMenu(ChickenClub);
            
        }




    }
}
