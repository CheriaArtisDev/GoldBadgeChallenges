﻿using Badge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge_Console
{
    public class ProgramUI
    {
        private BadgeRepo _badgeRepo = new BadgeRepo();
        public void Run()
        {
            SecurityMenu();
        }

        private void SecurityMenu()
        {
            bool isRunning = true;
            while(isRunning)
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

                switch(choice)
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
            }
        }

        public void AddBadge()
        {
            bool addBadge = true;

            while(addBadge)
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

        }

        public void RemoveBadge()
        {

        }

        private void AddDoor(Badge badge, int badgeInfo)
        {
            Console.WriteLine("\n What door would you like to add? ");
            string doorInput = Console.ReadLine();

            _badgeRepo.AddDoor(badgeInfo, doorInput);

            Console.WriteLine($"\n Door {doorInput} was added to the badge.");
            Console.WriteLine($"{badgeInfo} has access to ");
            foreach(var door in badge.DoorId)
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