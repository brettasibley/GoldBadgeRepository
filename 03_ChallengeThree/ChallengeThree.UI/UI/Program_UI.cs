using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class Program_UI
    {
        private readonly BadgeRepository _bRepo = new BadgeRepository();
        public void Run()
        {
            SeedData();
            RunApplication();
        }

    private void RunApplication()
    {
        bool isRunning = true;
        while(isRunning)
        {
            Console.Clear();
            System.Console.WriteLine("Welcome to the Komodo Insurance Badging System");
            System.Console.WriteLine("Please make a selection\n"+
            "1. Create New Badge\n"+
            "2. Update Doors on Existing Badge\n"+
            "3. Delete All Doors from Existing Badge\n"+
            "4. View All Badges Including Doors They Have Access To\n"+
            "5. Close Application\n");

            var userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    CreateNewBadge();
                    break;
                case "2":
                    UpdateDoors();
                    break;
                case "3":
                    DeleteAllDoors();
                    break;
                case "4":
                    ViewAllBadgesAndDoors();
                    break;
                case "5":
                    isRunning = CloseApplication();
                    break;
                default:
                    System.Console.WriteLine("Invalid Selection");
                    PressAnyKeyToContinue();
                    break;
            }
        }
    }

    private void PressAnyKeyToContinue()
    {
        System.Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }

    private bool CloseApplication()
    {
        Console.Clear();
        PressAnyKeyToContinue();
        return false;
    }

    private void ViewAllBadgesAndDoors()
    {
        
    }

    private void DeleteAllDoors()
    {
        
    }

    private void UpdateDoors()
    {
        
    }

    private void CreateNewBadge()
    {
        Console.Clear();
        var newBadge = new Badge();
        System.Console.WriteLine("=== New Badge Form ===");
        
    }

    private void SeedData()
    {
        
    }
}