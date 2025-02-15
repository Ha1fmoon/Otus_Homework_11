using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Regular_Customer;

public class Shop : IDisposable
{
    public event Action<string, Item?>? OnCatalogChanged;
    private readonly ObservableCollection<Item> _items;

    public Shop()
    {
        _items = new ObservableCollection<Item>();
        _items.CollectionChanged += CollectionChanged;
    }

    public void Add()
    {
        var newItem = new Item($"Product [{DateTime.Now}]");
        _items.Add(newItem);
    }

    public void Remove(int id)
    {
        var item = TryGetById(id);
        if (item != null) _items.Remove(item);
    }

    public ObservableCollection<Item>? GetItemList()
    {
        return _items.Count != 0 ? _items : null;
    }

    private Item? TryGetById(int id)
    {
        return _items.FirstOrDefault(x => x.Id == id);
    }

    private void CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        switch (e.Action)
        {
            case NotifyCollectionChangedAction.Add:
                if (e.NewItems?[0] == null) break;
                OnCatalogChanged?.Invoke("Item was added", e.NewItems?[0] as Item);
                break;
            case NotifyCollectionChangedAction.Remove:
                if (e.OldItems?[0] == null) break;
                OnCatalogChanged?.Invoke("Item was removed", e.OldItems?[0] as Item);
                break;
        }
    }

    public void Dispose()
    {
        _items.CollectionChanged -= CollectionChanged;
    }
}