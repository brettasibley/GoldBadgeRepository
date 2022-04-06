using Xunit;

public class MenuItemTest
{
    [Fact]
    public void CreateAnInstanceOf_MenuItem()
    {
        MenuItem menuItem = new MenuItem("Burger and Fries","Double cheeseburger topped with the works and a side of fries","Ground beef, cheddar cheese, lettuce, tomato, onion, bun",12.99m);
        menuItem.MealNumber=1;

        int expectedMealNumber = 1;
        int actualMealNumber = menuItem.MealNumber;

        Assert.Equal(expectedMealNumber,actualMealNumber);
    }
}