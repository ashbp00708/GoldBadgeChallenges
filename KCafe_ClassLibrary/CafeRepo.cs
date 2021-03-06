﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCafe_ClassLibrary
{    
    public class CafeRepo
    { 
        public List<CafeMenu> _listOfMenuItems = new List<CafeMenu>();      
        public void AddToCafeMenu(CafeMenu menuItem)
        {
            _listOfMenuItems.Add(menuItem);
        }
        public List<CafeMenu> ShowFullCafeMenu()
        {
            return _listOfMenuItems;
        }
        public bool UpdateCafeMenuMeal(string oldMealName, CafeMenu newMenuItem)
        {
           
            CafeMenu oldMenuItem = SearchMealByName(oldMealName);
            if(oldMenuItem !=null)
            {
                oldMenuItem.MealName = newMenuItem.MealName;
                oldMenuItem.Description = newMenuItem.Description;
                oldMenuItem.MealNumber = newMenuItem.MealNumber;
                oldMenuItem.Ingredient = newMenuItem.Ingredient;
                oldMenuItem.Price = newMenuItem.Price;
                return true;
            }
            else
            {
                return false;
            }
        }
         public bool RemoveMealFromMenu(int mealNumber)
        {
            CafeMenu menuItem = SearchMealNumber(mealNumber);
            if(menuItem ==null)
            {
                return false;
            }
            int initialCount = _listOfMenuItems.Count;
            _listOfMenuItems.Remove(menuItem);  

            if(initialCount > _listOfMenuItems.Count)
            {
                return true;
            } 
            else
            {
                return false;
            }
        }
        public CafeMenu SearchMealByName(string mealName)
        {
            foreach (CafeMenu menuItem in _listOfMenuItems)
            {
                if (menuItem.MealName == mealName)
                {
                    return menuItem;
                }
            }
            return null;
        }
        public CafeMenu SearchMealNumber(int mealNumber)
        {
            foreach (CafeMenu menuItem in _listOfMenuItems)
            {
                if (menuItem.MealNumber == mealNumber)
                {
                    return menuItem;
                }
            }
            return null;
        }
    }
}

