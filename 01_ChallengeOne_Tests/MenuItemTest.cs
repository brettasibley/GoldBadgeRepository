using Xunit;

public class MenuItemTest
{
    [Fact]
    public void CreateAnInstanceOf_MenuItem()
    {
        MenuItem menuItem = new MenuItem(1,"Burger and Fries","Double cheeseburger topped with the works and a side of fries","Ground beef, cheddar cheese, lettuce, tomato, onion, bun",12.99);
        menuItem.MealNumber=1;

        int expectedMenuItemMealNumber = 1;
        int actualMenuItemMealNumber = menuItem.MealNumber;

        Assert.Equal(expectedMenuItemMealNumber,actualMenuItemMealNumber);
    }
}