public class MenuItem
{
    public MenuItem (){}

    public MenuItem (string mealName, string mealDescription, string listOfIngredients, decimal mealPrice)
    {
        MealName = mealName;
        MealDescription = mealDescription;
        ListOfIngredients = listOfIngredients;
        MealPrice = mealPrice;
    }

    public int MealNumber { get; set; }
    public string MealName { get; set; }
    public string MealDescription { get; set; }
    public string ListOfIngredients { get; set; }
    public decimal MealPrice { get; set; }
}
