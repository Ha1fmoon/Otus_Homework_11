using System.Collections.Concurrent;

namespace Librarian;

public class CuriousReader : IDisposable
{
    private ConcurrentDictionary<string, bool> _booksToRead;
    private Library _library;
    private CancellationTokenSource _cancellationSource;

    public CuriousReader(Library library)
    {
        _booksToRead = new ConcurrentDictionary<string, bool>();
        _library = library;
        _library.OnBookAdded += AddBookToReadList;
        _library.OnBookRemoved += RemoveBookFromReadList;
        _cancellationSource = new CancellationTokenSource();
        
        Task.Run(() => ReadBooksAsync(_cancellationSource.Token));
    }
    
    private async Task ReadBooksAsync(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            await Task.Delay(1000, token);

            if (_booksToRead.IsEmpty) continue;

            foreach (var book in _booksToRead)
            {
                _library.ReadBook(book.Key);
            }
        }
    }

    private void AddBookToReadList(string bookName)
    {
        _booksToRead.TryAdd(bookName, true);
    }

    private void RemoveBookFromReadList(string bookName)
    {
        _booksToRead.TryRemove(bookName, out var removedBookStatus);
    }

    public void Dispose()
    {
        _library.OnBookAdded -= AddBookToReadList;
        _library.OnBookRemoved -= RemoveBookFromReadList;
        
        _cancellationSource.Cancel();
    }
}