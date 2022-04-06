using Xunit;

public class MenuItemTest
{
    [Fact]
    public void CreateAnInstanceOf_MenuItem()
    {
        int expectedMealNumber = 1;
        string expectedMealName = "Burger and Fries";
        string expectedMealDescription = "Double cheeseburger topped with the works and a side of fries";
        string expectedListOfIngredients = "Ground beef, cheddar cheese, lettuce, tomato, onion, bun";
        decimal expectedPrice = 12.99m;
        MenuItem menuItem = new MenuItem(expectedMealName,expectedMealDescription,expectedListOfIngredients,expectedPrice);
        menuItem.MealNumber = expectedMealNumber;

        Assert.Equal(expectedMealNumber, menuItem.MealNumber);
        Assert.Equal(expectedMealName, menuItem.MealName);
        Assert.Equal(expectedMealDescription, menuItem.MealDescription);
        Assert.Equal(expectedListOfIngredients, menuItem.ListOfIngredients);
        Assert.Equal(expectedPrice, menuItem.MealPrice);
    }
}