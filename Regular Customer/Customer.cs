namespace Regular_Customer;

public class Customer : ICustomerObserver, IDisposable
{
    private string _name;
    private readonly Shop _shop;

    public Customer(string name, Shop shop)
    {
        _name = name;
        _shop = shop;
        _shop.OnCatalogChanged += OnItemChanged;
    }

    public void OnItemChanged(string message, Item? item)
    {
        Console.WriteLine($"Customer {_name} get new message: '{message} {item?.Name}'");
    }

    public void Dispose()
    {
        _shop.OnCatalogChanged -= OnItemChanged;
    }
}