namespace Regular_Customer;

public interface ICustomerObserver
{
    public void OnItemChanged(string message, Item? item);
}