using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu_Repository
{
    public class MenuRepo
    {
        private readonly List<Menu> _menuItems = new List<Menu>();


        // Add Menu Items
        public bool Add(Menu menuItem)
        {
            int startingCount = _menuItems.Count;
            _menuItems.Add(menuItem);

            bool wasAdded = (_menuItems.Count > startingCount) ? true : false;
            return wasAdded;
        }

        // Get all menu items
        public List<Menu> GetAllMeals()
        {
            return _menuItems;
        }

        // Get Menu Item by Number
        public Menu GetItemByNumber(int mealNumber)
        {
            // items in the collection start at 0 but the menu item numbers start at 1
            foreach(Menu contents in _menuItems)
            {
                if(contents.MealNumber == mealNumber)
                {
                    return contents;
                }
            }
            return null;
        }

        // Remove Menu Items
        public bool RemoveItem(Menu existingMealNumber)
        {
            bool result = _menuItems.Remove(existingMealNumber);
            return result;
        }
    }
}
