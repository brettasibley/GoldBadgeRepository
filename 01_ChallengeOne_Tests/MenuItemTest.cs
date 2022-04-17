using Xunit;

public class MenuItemTest
{
    [Fact]
    public void AddMenuItem_ShouldAddItemToMenu()
    {
        MenuItemRepository repository = new MenuItemRepository();
        var grilledCheese = new MenuItem("Grilled Cheese","Grilled cheese sandwich with a side of tomato soup","Bread, American Cheese, tomatoes, cream, butter, garlic, basil, onion",7.99m);
        var chickenFingers = new MenuItem("Chicken Fingers w/Fries","Breaded pieces of chicken tenderloins fried to perfection on a bed of french fries","Chicken tenderloins, flour, eggs, potatoes, oil",9.99m);

        repository.AddMenuItemToMenu(grilledCheese);
        repository.AddMenuItemToMenu(chickenFingers);

        var expected = 2;
        var actual = repository.GetWholeMenu().Count;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetWholeMenu_ShouldReturnFullMenu()
    {
        MenuItemRepository repository = new MenuItemRepository();
        var grilledCheese = new MenuItem("Grilled Cheese","Grilled cheese sandwich with a side of tomato soup","Bread, American Cheese, tomatoes, cream, butter, garlic, basil, onion",7.99m);
        var chickenFingers = new MenuItem("Chicken Fingers w/Fries","Breaded pieces of chicken tenderloins fried to perfection on a bed of french fries","Chicken tenderloins, flour, eggs, potatoes, oil",9.99m);

        repository.AddMenuItemToMenu(grilledCheese);
        repository.AddMenuItemToMenu(chickenFingers);

        var wholeMenu = repository.GetWholeMenu();

        Assert.Equal(2, wholeMenu.Count);
        Assert.Equal("Grilled Cheese",wholeMenu[0].MealName);
        Assert.Equal("Chicken Fingers w/Fries",wholeMenu[1].MealName);
    }

    [Fact]
    public void GetMenuItemByMealNumber_ShouldReturnMealNumber()
    {
        MenuItemRepository repository = new MenuItemRepository();
        var grilledCheese = new MenuItem("Grilled Cheese","Grilled cheese sandwich with a side of tomato soup","Bread, American Cheese, tomatoes, cream, butter, garlic, basil, onion",7.99m);

        repository.AddMenuItemToMenu(grilledCheese);

        Assert.Equal("Grilled Cheese",repository.GetMenuItemByMealNumber(grilledCheese.MealNumber).MealName);
        //Meal number should never return different meal
        Assert.Equal("Grilled Cheese",repository.GetMenuItemByMealNumber(grilledCheese.MealNumber).MealName);
    }

    [Fact]
    public void RemoveMenuItem_ShouldRemoveItemFromMenu()
    {
        MenuItemRepository repository = new MenuItemRepository();
        var grilledCheese = new MenuItem("Grilled Cheese","Grilled cheese sandwich with a side of tomato soup","Bread, American Cheese, tomatoes, cream, butter, garlic, basil, onion",7.99m);

        repository.AddMenuItemToMenu(grilledCheese);

        Assert.Equal("Grilled Cheese",repository.GetMenuItemByMealNumber(grilledCheese.MealNumber).MealName);
        repository.RemoveMenuItemFromMenu(grilledCheese.MealNumber);
        Assert.Equal(null,repository.GetMenuItemByMealNumber(grilledCheese.MealNumber));
    }

    [Fact]
    public void RemoveMenuItem_ShouldHandleInvalidMealNumber()
    {
        MenuItemRepository repository = new MenuItemRepository();
        var result = repository.RemoveMenuItemFromMenu(999);
        Assert.Equal(false, result);
    }
}