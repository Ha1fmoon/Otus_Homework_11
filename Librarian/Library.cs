using System.Collections.Concurrent;

namespace Librarian;

public class Library
{
    public event Action<string>? OnBookAdded;
    public event Action<string>? OnBookRemoved;
    private readonly ConcurrentDictionary<string, int> _bookCollection;

    public Library()
    {
        _bookCollection = new ConcurrentDictionary<string, int>();
    }

    public void AddBook(string bookName)
    {
        if (_bookCollection.ContainsKey(bookName)) return;

        var result = _bookCollection.TryAdd(bookName, 0);

        if (result) OnBookAdded?.Invoke(bookName);
    }

    public void ReadBook(string bookName)
    {
        _bookCollection[bookName] += 1;

        if (_bookCollection[bookName] < 100) return;

        var result = _bookCollection.TryRemove(bookName, out var removedBook);

        if (result) OnBookRemoved?.Invoke(bookName);
    }

    public string[]? GetBookList()
    {
        if (_bookCollection.IsEmpty) return null;

        var result = new string[_bookCollection.Count];

        var index = 0;

        foreach (var book in _bookCollection)
        {
            result[index] = $"{book.Key} - {book.Value}%";
            index++;
        }

        return result;
    }
}