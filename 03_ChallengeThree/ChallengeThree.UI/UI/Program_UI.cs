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
        while (isRunning)
        {
            Console.Clear();
            System.Console.WriteLine("Welcome to the Komodo Insurance Badging System");
            System.Console.WriteLine("Please make a selection\n" +
            "1. Create New Badge\n" +
            "2. Update Doors on Existing Badge\n" +
            "3. Delete All Doors from Existing Badge\n" +
            "4. View All Badges Including Doors They Have Access To\n" +
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
        Console.Clear();

        Dictionary<int, Badge> Badges = _bRepo.GetAllBadges();

        if (Badges.Count > 0)
        {
            foreach (KeyValuePair<int, Badge> KV in Badges)
            {
                Badge badge = KV.Value;
                DisplayBadgeInfo(badge);
            }
        }
        else
        {
            System.Console.WriteLine("There are no badges");
        }
        PressAnyKeyToContinue();
    }

    private void DisplayBadgeInfo(Badge badge)
    {
        System.Console.WriteLine($"Badge ID: {badge.ID}\n" +
        $"Doors: {string.Join(", ", badge.Doors)}\n" +
        "------------------------------------------------------\n");
        // foreach (string door in badge.Doors)
        // {
        //     System.Console.Write(door + ",");
        // }
    }

    private void DeleteAllDoors()
    {

    }

    private void UpdateDoors()
    {
        Console.Clear();
        System.Console.WriteLine("Please make a selection");
        System.Console.WriteLine("1. Add Door\n2. Remove Door\n");
        var userInput = Console.ReadLine();
        switch(userInput)
        {
            case "1":
            AddDoor();
            break;
            case "2":
            RemoveDoor();
            break;
            default:
            break;
        }

        PressAnyKeyToContinue();
    }

    private void AddDoor()
    {
        Console.Clear();
        System.Console.WriteLine("Please enter a badge number");
        var userInput = int.Parse(Console.ReadLine());
        System.Console.WriteLine("Please enter a door name");
        var userInputDoorName = Console.ReadLine();
        var success = _bRepo.AddDoorToBadge(userInput, userInputDoorName);
        if(success)
        System.Console.WriteLine("SUCCESS");
        else
        System.Console.WriteLine("FAILURE");
        PressAnyKeyToContinue();
    }

    private void RemoveDoor()
    {
        Console.Clear();
        System.Console.WriteLine("Please enter a badge number");
        var userInput = int.Parse(Console.ReadLine());
        System.Console.WriteLine("Please enter a door name");
        var userInputDoorName = Console.ReadLine();
        var success = _bRepo.RemoveDoorFromBadge(userInput, userInputDoorName);
        if(success)
        System.Console.WriteLine("SUCCESS");
        else
        System.Console.WriteLine("FAILURE");
        PressAnyKeyToContinue();
    }

    private void CreateNewBadge()
    {
        Console.Clear();
        var newBadge = new Badge();
        System.Console.WriteLine("=== New Badge Form ===");
        bool hasListedAllDoors = false;
        while(!hasListedAllDoors)
        {
            System.Console.WriteLine("Would you like to add a new door? Y/N?");
            var userInput = Console.ReadLine();
            if(userInput == "Y".ToLower())
            {
            System.Console.WriteLine("Please enter a door name");
                var userInputDoorName = Console.ReadLine();
                newBadge.Doors.Add(userInputDoorName);
                continue;
            }
            else
            {
                hasListedAllDoors = true;
            }
            
        }
        if(_bRepo.CreateNewBadge(newBadge))
        System.Console.WriteLine("SUCCESS");
        else
        System.Console.WriteLine("FAILURE");
        PressAnyKeyToContinue();

    }

    private void SeedData()
    {
        Badge badgeA = new Badge(new List<string> { "A1", "A2" });
        _bRepo.CreateNewBadge(badgeA);
    }
}