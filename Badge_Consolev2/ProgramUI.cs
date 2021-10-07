using Badge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge_Consolev2
{
    public class ProgramUI
    {
        private BadgeRepo _badgeRepo = new BadgeRepo();
        public void Run()
        {
            SeeData();
            SecurityMenu();
        }

        private void SecurityMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();

                Console.WriteLine("Welcome to the Komodo Security Bage Menu\n\n" +
                    "Please choose a number below:\n" +
                    "1. Create a badge\n" +
                    "2. Edit a badge\n" +
                    "3. Display all badges\n" +
                    "4. Remove a door from a badge\n" +
                    "5. Exit Menu\n"
                    );

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        UpdateBadge();
                        break;
                    case "3":
                        DisplayAllBadges();
                        break;
                    case "4":
                        RemoveBadge();
                        break;
                    case "5":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("\n Please enter a valid choice (1-5): ");
                        break;
                }
                PressAnyKey();
            }
        }

        public void AddBadge()
        {
            bool addBadge = true;

            while (addBadge)
            {
                Console.Clear();

                var createBadge = new Badge();

                Console.WriteLine("Please enter the badge number: ");
                int inputBadgeId = createBadge.BadgeId;

                List<String> doorAccess = new List<string>();

                Console.WriteLine("\n Please enter the list of doors each separated by a comma (A9, D3, E5): ");
                string doorList = Console.ReadLine();
                doorAccess = doorList.Split(',').ToList();

                _badgeRepo.CreateNewBadge(createBadge);
                Console.WriteLine("Badge added successfully.");
            }
            PressAnyKey();
        }

        public void DisplayAllBadges()
        {
            Console.Clear();
            DisplayAllBadges();
            PressAnyKey();
        }

        public void UpdateBadge()
        {
            bool updateBadge = true;

            while (updateBadge)
            {
                Console.Clear();
                DisplayAllBadges();

                var hasBadges = _badgeRepo.DisplayAllBadges();
                if (hasBadges.Count == 0)
                {
                    updateBadge = false;
                }
                else
                {
                    int inputBadge = Convert.ToInt32(Console.ReadLine());
                    var existingBadge = _badgeRepo.FindBadgeById(inputBadge);

                    if (existingBadge == null)
                    {
                        Console.WriteLine("Badge not found.");
                        PressAnyKey();
                        return;
                    }
                    Console.WriteLine($"\n Badge {inputBadge} has access to ");
                    foreach (var door in existingBadge.DoorId)
                    {
                        Console.Write($"{door}");
                    }

                    Console.WriteLine("\n\n Please choose an option below: \n" +
                        "1. Add a door \n" +
                        "2. Remove a door \n");

                    string chooseOption = Console.ReadLine();
                    switch (chooseOption)
                    {
                        case "1":
                            AddDoor(existingBadge, inputBadge);
                            break;
                        case "2":
                            RemoveDoor(existingBadge, inputBadge);
                            break;
                        default:
                            Console.WriteLine("Please enter 1 or 2.");
                            break;
                    }
                    Console.WriteLine("\n\n Would you like to update another badge? (y/n): ");
                    string reply = Console.ReadLine().ToLower();
                    if (reply == "y")
                    {
                        updateBadge = true;
                    }
                    else
                    {
                        updateBadge = false;
                    }
                }
            }
            PressAnyKey();
        }

        public void RemoveBadge()
        {
            bool removeBadge = true;
            while (removeBadge)
            {
                Console.Clear();
                DisplayAllBadges();

                var hasBadges = _badgeRepo.DisplayAllBadges();
                if (hasBadges.Count == 0)
                {
                    removeBadge = false;
                }
                else
                {
                    Console.WriteLine("\n\n Which badge would you like to remove? ");
                    int inputBadge = Convert.ToInt32(Console.ReadLine());
                    var existingBadge = _badgeRepo.FindBadgeById(inputBadge);

                    if (existingBadge == null)
                    {
                        Console.WriteLine("Badge not found.");
                        PressAnyKey();
                        return;
                    }
                    Console.WriteLine("Are you sure you want to remove this badge? (y/n): ");
                    string reply = Console.ReadLine().ToLower();
                    if (reply == "y")
                    {
                        Console.Clear();
                        _badgeRepo.RemoveDoorById(inputBadge);
                        Console.WriteLine("The badge you entered has been removed. \n");
                    }
                    else if (reply == "n")
                    {
                        Console.WriteLine($"\n Badge {inputBadge} has not been removed.");
                        return;
                    }
                    else
                    {
                        return;
                    }
                    Console.WriteLine("\n\n Would you like to remove another badge? (y/n): ");
                    string user = Console.ReadLine().ToLower();
                    if (user == "y")
                    {
                        removeBadge = true;
                    }
                    else
                    {
                        removeBadge = false;
                    }
                }
            }
            PressAnyKey();
        }

        private void AddDoor(Badge badge, int badgeInfo)
        {
            Console.WriteLine("\n What door would you like to add? ");
            string doorInput = Console.ReadLine();

            _badgeRepo.AddDoor(badgeInfo, doorInput);

            Console.WriteLine($"\n Door {doorInput} was added to the badge.");
            Console.WriteLine($"{badgeInfo} has access to ");
            foreach (var door in badge.DoorId)
            {
                Console.Write($"{door}");
            }
            PressAnyKey();
        }

        private void RemoveDoor(Badge badge, int badgeInfo)
        {
            Console.WriteLine("\n What door would you like to remove? ");
            string doorInput = Console.ReadLine();

            _badgeRepo.RemoveDoorFromBadge(badgeInfo, doorInput);

            Console.WriteLine($"\n Door {doorInput} was removed from the badge.");
            Console.WriteLine($"{badgeInfo} has access to ");
            foreach (var door in badge.DoorId)
            {
                Console.Write($"{door}");
            }
            PressAnyKey();
        }

        public void PressAnyKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}

