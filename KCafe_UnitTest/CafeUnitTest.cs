using KCafe_ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KCafe_UnitTest
{
    [TestClass]
    public class CafeUnitTest
    {
        private CafeRepo _cafeRepo = new CafeRepo();
        private CafeMenu _cafeMenu = new CafeMenu();
        [TestInitialize]
        public void CafeMealArranged()
        {
            _cafeRepo = new CafeRepo();
            _cafeMenu = new CafeMenu("BLT", "BLT sandwich on wheat bread, served with house chips and a medium beverage.", 1, "bacon, tomato, lettuce, mayo, wheat bread, homemade potato chips", 7.99);
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
        [DataTestMethod]
        [DataRow("BLT", true)]
        public void UpdatecafeMenuMeal_IsTrue(string oldMealName, bool updateSuccess)
        {
            CafeMenu newMenuItem = new CafeMenu("Club Sandwich", "Deli Club sandwhich on sourdough bread, served with house chips and a medium beverage.", 2, "ham, turkey, bacon, honeymustard, lettuce, sourdough bread, homemade potato chips", 8.99);
            bool updated = _cafeRepo.UpdateCafeMenuMeal(oldMealName, newMenuItem);
            Assert.IsTrue(updateSuccess);
        }
        [TestMethod]
        public void RemoveMealFromMenu_SearchMealByNumber()
        {
            _cafeRepo.RemoveMealFromMenu(1);
            int expected = 0;
            int actual = _cafeRepo.ShowFullCafeMenu().Count;
            Assert.AreEqual(expected, actual);

        }



    }
}