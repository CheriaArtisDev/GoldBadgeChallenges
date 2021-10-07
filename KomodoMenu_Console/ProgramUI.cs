using Menu_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoMenu_Console
{
    public class ProgramUI
    {
        private MenuRepo _menuRepo = new MenuRepo();

        public void Run()
        {
            AddDefaultMenuMeals();
            CafeMenu();
        }

        private void AddDefaultMenuMeals()
        {
            _menuRepo.Add(new Menu()
            {
                MealNumber = 1,
                MealName = "Fish Taco Combo",
                Description = "Fish on Hoagie Bun, medium fries, and medium soft drink",
                Ingredients = "Alaskan Codfish, mayonaise, Hoagie bun, fresh cut french fries, and medium soft drink",
                Price = 9.99m
            });

            _menuRepo.Add(new Menu()
            {
                MealNumber = 2,
                MealName = "Chicken Quesadilla Combo",
                Description = "One Chicken Quesadilla, an order of Cinnamon Twists, and a medium soft drink",
                Ingredients = "Diced chicken breasts grilled with a Mexican cheese blend between two flour " +
                "tortillas, fried cinnamon bread and a medium soft drink",
                Price = 8.79m
            });

            _menuRepo.Add(new Menu()
            {
                MealNumber = 3,
                MealName = "Brunch for Two",
                Description = "2 pastry items and 2 frappacino coffee drinks",
                Ingredients = "Mix and match your choice of muffins, lemon cake, or " +
                "banana nut bread with a medium mocha, chocolate chip or carmel frappacino iced drink",
                Price = 12.99m
            });

        }

        private void CafeMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Please select from an option below:\n" +
                    "1. Create Menu Item\n" +
                    "2. Display All Menu Items\n" +
                    "3. Delete Menu Item\n" +
                    "4. Exit Menu options");

                string response = Console.ReadLine();
                switch (response)
                {
                    case "1":
                        AddMeal();
                        break;
                    case "2":
                        DisplayAllMeals();
                        break;
                    case "3":
                        DeleteMeal();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option number.");
                        break;
                }
            }
        }

        public void DisplayAllMeals()
        {
            Console.Clear();
            List<Menu> menuList = _menuRepo.GetAllMeals();
            foreach (Menu content in menuList)
            {
                DisplayMeal(content);
            }
            Console.WriteLine("Press any key to continue: ");
            Console.ReadKey();
        }

        private void AddMeal()
        {
            Console.Clear();
            Menu menuItem = new Menu();

            // Get Meal Number
            Console.WriteLine("Please enter a number for the new meal: ");
            menuItem.MealNumber = Convert.ToInt32(Console.ReadLine());
            // Get Meal Name 
            Console.WriteLine("Please enter the name of the new meal you would like to add the the Cafe Menu: ");
            menuItem.MealName = Console.ReadLine();
            // Get Meal Description
            Console.WriteLine("Please enter the description of the meal you want to add to the Cafe Menu: ");
            menuItem.Description = Console.ReadLine();
            // Get Meal Ingredients
            Console.WriteLine("Please enter the ingredients of the new meal: ");
            menuItem.Ingredients = Console.ReadLine();
            // Get Meal Price
            Console.WriteLine("Please enter the price of the new meal: ");
            menuItem.Price = GetPrice();

            _menuRepo.Add(menuItem);
        }
        public void DeleteMeal()
        {
            Console.Clear();
            List<Menu> menuList = _menuRepo.GetAllMeals();

            int index = 1;

            foreach (Menu content in menuList)
            {
                Console.WriteLine($"{index}. {content.MealName}");
                index++;
            }

            Console.WriteLine("Please enter the number you want to remove: ");
            int targetTitleId = int.Parse(Console.ReadLine());
            int targetIndex = targetTitleId - 1;

            if (targetIndex >= 0 && targetIndex < menuList.Count)
            {
                Menu targetContent = menuList[targetIndex];

                if (_menuRepo.RemoveItem(targetContent))
                {
                    Console.WriteLine($"{targetContent.MealName} was successfully deleted");
                }
                else
                {
                    Console.WriteLine("Oh no, something went wrong!");
                }
            }
            else
            {
                Console.WriteLine("That is not a valid selection.");
            }
            Console.WriteLine("Press any key to continue: ");
            Console.ReadKey();

        }

        public decimal GetPrice()
        {
            string response = Console.ReadLine();
            if (decimal.TryParse(response, out decimal count))
            {
                return count;
            }
            else
            {
                return 0.00m;
            }
        }

        private void DisplayMeal(Menu content)
        {
            Console.WriteLine($"Meal #{content.MealNumber}\n" +
                $"Meal Name: {content.MealName}\n" +
                $"Description: {content.Description}\n" +
                $"Ingredients: {content.Ingredients}\n" +
                $"Price: {content.Price}");
        }
    }
}
