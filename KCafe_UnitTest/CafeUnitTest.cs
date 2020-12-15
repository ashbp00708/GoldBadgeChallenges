using KCafe_ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KCafe_UnitTest
{
    [TestClass]
    public class CafeUnitTest
    {
        private CafeRepo _cafeRepo;
        private CafeMenu _cafeMenu;
       

        [TestInitialize]
        public void CafeMealArranged()
        {
            _cafeRepo = new CafeRepo();
            _cafeMenu = new CafeMenu("BLT", "BLT sandwich on wheat bread, served with house chips and a medium beverage.", 1, "bacon, tomato, lettuce, mayo, wheat bread, homemade potato chips", 7.99);
            _cafeRepo.AddToCafeMenu(_cafeMenu);

        }

        [TestMethod]
        public void AddToCafeMenu_MenuItemNotNull()
        {
            CafeMenu menuItem = new CafeMenu();
            menuItem.MealName = "Roast Beef Sandwich";
            CafeRepo repo = new CafeRepo();

            repo.AddToCafeMenu(menuItem);
            CafeMenu menuItemByMealName = repo.SearchMealByName("Roast Beef Sandwich");
            Assert.IsNotNull(menuItemByMealName);
        }
        [TestMethod]
        public void ShowFullCafeMenu()
        {
            List<CafeMenu> _listOfMenuItems = _cafeRepo.ShowFullCafeMenu();
            Assert.IsTrue(_listOfMenuItems.Contains() > 0, "Show all menu items");
            Assert.AreEqual()
            
            }
        }
        [TestMethod]
        public void UpdatecafeMenuMeal_MenuMealTrue()
        {
            CafeMenu menuItem = new CafeMenu("Club Sandwich", "Deli Club sandwhich on sourdough bread, served with house chips and a medium beverage.", 2, "ham, turkey, bacon, honeymustard, lettuce, sourdough bread, homemade potato chips", 8.99);
            bool updatedSuccessfully = _cafeRepo.UpdateCafeMenuMeal("Club Sandwich", menuItem);
            Assert.IsTrue(updatedSuccessfully);
            
        }
        public void RemoveMealFromMenu_MenuMealTrue()
        {
            bool deletedSuccessfully = _cafeMenu.RemoveMealFromMenu(_cafeMenu.MealName);
            Assert.IsTrue(deletedSuccessfully);
        }
        public void SearchMealByName_NameNotNull()
        {
            

            
        }


            
               
            

            
            


        
        
    }
}
