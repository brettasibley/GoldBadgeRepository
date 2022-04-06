using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Program_UI
{
    private readonly MenuItemRepository _mRepo = new MenuItemRepository();
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
            System.Console.WriteLine("=== Welcome to Komodo Cafe ===");
            System.Console.WriteLine("Please Make a Selection: \n"+
            "1. Add New Menu Item\n"+
            "2. View Whole Menu\n"+
            "3. View Menu Item by Meal Number\n"+
            "4. Remove Item from Menu\n"+
            "5. Close Application\n");

            var userInput = Console.ReadLine();

            switch(userInput)
            {
                case "1":
                AddMenuItemToMenu();
                break;
                case "2":
                ViewWholeMenu();
                break;
                case "3":
                ViewMenuItemByMealNumber();
                break;
                case "4":
                RemoveMenuItemFromMenu();
                break;
                case "5":
                isRunning = CloseApplication();
                break;
            }
        }
    }

    private bool CloseApplication()
    {
        System.Console.WriteLine("Thanks for using Komodo Cafe\n"+
        "Press any key to continue");
        Console.ReadKey();
        return false;
    }

    private void RemoveMenuItemFromMenu()
    {
        Console.Clear();
        System.Console.WriteLine("=== Menu Item Removal Page ===");

        var menuItems = _mRepo.GetWholeMenu();
        foreach(MenuItem menuItem in menuItems)
        {
            DisplayListOfMenuItems(menuItem);
        }

        try
        {
            System.Console.WriteLine("Please select a Meal by Meal Number");
            var userInputSelectedMeal = int.Parse(Console.ReadLine());
            bool isSuccessful = _mRepo.RemoveMenuItemFromMenu(userInputSelectedMeal);
            if(isSuccessful)
            {
                System.Console.WriteLine("Meal was successfully deleted");
            }
            else
            {
                System.Console.WriteLine("Meal failed to be deleted");
            }
        }
        catch
        {
            System.Console.WriteLine("Sorry, invalid selection");
        }
        PressAnyKeyToContinue();
    }

    private void DisplayListOfMenuItems(MenuItem menuItem)
    {
        System.Console.WriteLine($"Meal Number: {menuItem.MealNumber}\n Meal Name: {menuItem.MealName}\n"+
        "--------------------------------------------------------------\n");
    }

    private void ViewMenuItemByMealNumber()
    {
        Console.Clear();
        System.Console.WriteLine("=== Menu Item Detail Menu ===\n");
        System.Console.WriteLine("Please enter a Menu Item Meal Number: \n");
        var userInputMealNumber = int.Parse(Console.ReadLine());

        var menuItem = _mRepo.GetMenuItemByMealNumber(userInputMealNumber);

        if(menuItem != null)
        {
            DisplayMenuItemInfo(menuItem);
        }
        else
        {
            System.Console.WriteLine($"The Menu Item with Meal Number: {userInputMealNumber} does not exist");
        }
        PressAnyKeyToContinue();
    }

    private void ViewWholeMenu()
    {
        Console.Clear();

        List<MenuItem> menuItemsInDb = _mRepo.GetWholeMenu();

        if(menuItemsInDb.Count > 0)
        {
            foreach(MenuItem menuItem in menuItemsInDb)
            {
                DisplayMenuItemInfo(menuItem);
            }
        }
        else
        {
            System.Console.WriteLine("There are no menu items");
        }
        
        PressAnyKeyToContinue();
    }

    private void DisplayMenuItemInfo(MenuItem menuItem)
    {
        System.Console.WriteLine($"Meal Number: {menuItem.MealNumber}\n"+
        $"Meal Name: {menuItem.MealName}\n"+
        $"Meal Description: {menuItem.MealDescription}\n"+
        $"List of Ingredients: {menuItem.ListOfIngredients}\n"+
        $"Price of Meal: {menuItem.MealPrice}\n"+
        "------------------------------------------------------\n");
    }

    private void AddMenuItemToMenu()
    {
        Console.Clear();
        var newMenuItem = new MenuItem();
        System.Console.WriteLine("=== New Item Menu ===\n");

        System.Console.WriteLine("Please enter a meal name");
        newMenuItem.MealName = Console.ReadLine();

        System.Console.WriteLine("Please enter a description of the meal");
        newMenuItem.MealDescription = Console.ReadLine();

        System.Console.WriteLine("Please enter a list of ingredients included in the meal");
        newMenuItem.ListOfIngredients = Console.ReadLine();

        System.Console.WriteLine("Please enter a price for the meal");
        newMenuItem.MealPrice = decimal.Parse(Console.ReadLine());

        bool isSuccessful = _mRepo.AddMenuItemToMenu(newMenuItem);
        if(isSuccessful)
        {
            System.Console.WriteLine($"{newMenuItem.MealName} was added to the Menu!");
        }
        else
        {
            System.Console.WriteLine("Menu item failed to be added to the menu");
        }

        PressAnyKeyToContinue();
    }

    private void PressAnyKeyToContinue()
    {
        System.Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }

    private void SeedData()
    {
        var grilledCheese = new MenuItem("Grilled Cheese","Grilled cheese sandwich with a side of tomato soup","Bread, American Cheese, tomatoes, cream, butter, garlic, basil, onion",7.99m);
        var chickenFingers = new MenuItem("Chicken Fingers w/Fries","Breaded pieces of chicken tenderloins fried to perfection on a bed of french fries","Chicken tenderloins, flour, eggs, potatoes, oil",9.99m);
        var caesarSalad = new MenuItem("Caesar Salad w/Croutons","Fresh Romaine lettuce tossed in a creamy caesar dressing topped with croutons","Romaine lettuce, croutons, Caesar dressing",6.99m);
        var cheeseBurger = new MenuItem("Cheeseburger In Paradise","Double cheeseburger topped with the works with a side of onion rings","Ground beef, brioche bun, cheddar cheese, lettuce, onion, tomato",12.99m);

        _mRepo.AddMenuItemToMenu(grilledCheese);
        _mRepo.AddMenuItemToMenu(chickenFingers);
        _mRepo.AddMenuItemToMenu(caesarSalad);
        _mRepo.AddMenuItemToMenu(cheeseBurger);
    }
}