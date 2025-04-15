internal class Program
{
    private static void Main(string[] args)
    {
        Menu menu = new Menu();

        foreach (var item in MenuItems.GetMenuItems())
        {
            menu.AddMenuItem(item);
        }

        Console.WriteLine("Do you have any allergies? Type the allergen to filter the menu or type 'None' if you have no allergens:");
        string allergen = Console.ReadLine();

        if (!allergen.Equals("None", StringComparison.OrdinalIgnoreCase))
        {
            menu.FilterMenuByAllergen(allergen);
        }

        menu.DisplayMenu();

        Console.WriteLine("\nHello Welcome to O'rderves! Please Enter the amount of money you'd like to spend on our menu!:");
        double wallet = double.Parse(Console.ReadLine());

        while (true)
        {
            Console.WriteLine("\nEnter the name of the item you want to buy (or type 'I'm all good' to exit):");
            string itemName = Console.ReadLine();

            if (itemName.Equals("I'm all good", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Thank you for visiting! Enjoy your meal!");
                break;
            }

            menu.BuyItem(itemName, ref wallet);

            if (wallet <= 0)
            {
                Console.WriteLine("You have no more money left. Thank you for visiting!");
                break;
            }
        }
    }
}

public class MenuItem
{
    public string Description { get; set; }
    public double Price { get; set; }
    public string Category { get; set; }
    public bool IsNew { get; set; }
    public List<string> Allergens { get; set; }

    public MenuItem(string description, double price, string category, bool isNew, List<string> allergens)
    {
        Description = description;
        Price = price;
        Category = category;
        IsNew = isNew;
        Allergens = allergens;
    }

    public override string ToString()
    {
        string allergensText = Allergens.Count > 0 ? $" (Allergens: {string.Join(", ", Allergens)})" : "";
        return $"{Description} - ${Price} ({Category}) {(IsNew ? "[NEW]" : "")}{allergensText}";
    }
}

public class Menu
{
    private List<MenuItem> Items { get; set; }
    public DateTime LastUpdated { get; private set; }

    public Menu()
    {
        Items = new List<MenuItem>();
        LastUpdated = DateTime.Now;
    }

    public void AddMenuItem(MenuItem item)
    {
        Items.Add(item);
        LastUpdated = DateTime.Now;
    }

    public void DisplayMenu()
    {
        Console.WriteLine("Menu:");
        foreach (var item in Items)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine($"\nLast Updated: {LastUpdated}");
    }

    public void FilterMenuByAllergen(string allergen)
    {
        Items.RemoveAll(item => item.Allergens.Contains(allergen, StringComparer.OrdinalIgnoreCase));
        Console.WriteLine($"\nFiltered out items containing the allergen: {allergen}");
    }

    public void BuyItem(string itemName, ref double wallet)
    {
        MenuItem item = Items.Find(i => i.Description.Equals(itemName, StringComparison.OrdinalIgnoreCase));

        if (item == null)
        {
            Console.WriteLine("Item not found on the menu.");
            return;
        }

        if (wallet >= item.Price)
        {
            wallet -= item.Price;
            Console.WriteLine($"You bought {item.Description} for ${item.Price}. Remaining wallet balance: ${wallet:F2}");
        }
        else
        {
            Console.WriteLine($"You don't have enough money to buy {item.Description}. You need ${item.Price - wallet:F2} more.");
        }
    }
}
