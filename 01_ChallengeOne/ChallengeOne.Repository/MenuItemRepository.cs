public class MenuItemRepository
{
    private readonly List<MenuItem> _menuItemDatabase = new List<MenuItem>();
    private int _count;
    public bool AddMenuItemToMenu(MenuItem menuItem)
    {
        if (menuItem != null)
        {
            _count++;
            menuItem.MealNumber = _count;
            _menuItemDatabase.Add(menuItem);
            return true;
        }
        else
        {
            return false;
        }
    }
    public List<MenuItem> GetWholeMenu()
    {
        return _menuItemDatabase;
    }

    public MenuItem GetMenuItemByMealNumber(int mealNumber)
    {
        foreach (var menuItem in _menuItemDatabase)
        {
            if (menuItem.MealNumber == mealNumber)
            {
                return menuItem;
            }
        }
        return null;
    }
    public bool RemoveMenuItemFromMenu(int mealNumber)
    {
        var menuItem = GetMenuItemByMealNumber(mealNumber);
        if (menuItem != null)
        {
            _menuItemDatabase.Remove(menuItem);
            return true;
        }
        else
        {
            return false;
        }
    }
}
