namespace Regular_Customer;

public class Item
{
    private static int _id;
    public int Id { get; private set; }
    public string Name { get; private set; }

    public Item(string name)
    {
        Name = name;
        Id = ++_id;
    }
}