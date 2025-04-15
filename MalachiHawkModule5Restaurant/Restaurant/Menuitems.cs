using System.Collections.Generic;

public static class MenuItems
{
    public static List<MenuItem> GetMenuItems()
    {
        return new List<MenuItem>
        {
            new MenuItem("Apples", 4.99, "Fruit Trays", false, new List<string> { "None" }),
            new MenuItem("Grapes", 5.49, "Fruit Trays", false, new List<string> { "None" }),
            new MenuItem("Pineapple", 5.99, "Fruit Trays", false, new List<string> { "None" }),
            new MenuItem("Blue Cheese", 14.99, "Cheese Trays", false, new List<string> { "Dairy" }),
            new MenuItem("Cheddar Cheese", 12.99, "Cheese Trays", false, new List<string> { "Dairy" }),
            new MenuItem("Gouda Cheese", 13.99, "Cheese Trays", false, new List<string> { "Dairy" }),
            new MenuItem("Mini Cakes", 8.99, "Morning Sweets", true, new List<string> { "Gluten", "Eggs", "Dairy" }),
            new MenuItem("Donuts", 6.99, "Morning Sweets", true, new List<string> { "Gluten", "Eggs", "Dairy" }),
            new MenuItem("Chocolate", 7.99, "Morning Sweets", true, new List<string> { "Dairy" }),
            new MenuItem("Sliders", 10.99, "Lunch", false, new List<string> { "Gluten", "Dairy" }),
            new MenuItem("Chicken", 9.99, "Dinner", false, new List<string> { "Gluten" }),
            new MenuItem("Steak", 11.99, "Dinner", false, new List<string> { "None" }),
            new MenuItem("Croissant", 8.99, "Dinner", false, new List<string> { "Gluten", "Dairy" }),
            new MenuItem("Pepsi", 2.99, "Drinks", false, new List<string> { "None" }),
            new MenuItem("Fruit Smoothie", 4.99, "Drinks", true, new List<string> { "None" }),
            new MenuItem("Tea", 1.99, "Drinks", false, new List<string> { "None" }),
            new MenuItem("Water", 0.99, "Drinks", false, new List<string> { "None" }),
            new MenuItem("Coffee", 2.49, "Drinks", false, new List<string> { "None" })
        };
    }
}