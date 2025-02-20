using Librarian;
using Regular_Customer;
using This_Is_the_House_That_Jack_Built;

namespace Otus_Homework_11;

internal class Program
{
    private static void Main()
    {
        // RegularCustomer();
        // Librarian();
        House();
    }

    private static void RegularCustomer()
    {
        var shop = new Shop();
        var customer = new Customer("Bob", shop);
        var customer2 = new Customer("Joe", shop);

        Console.WriteLine("A - Add new product");
        Console.WriteLine("D - Remove product by ID");
        Console.WriteLine("L - Show items list");
        Console.WriteLine("X - Quit");

        while (true)
        {
            Console.Write("Enter command: ");
            var input = Console.ReadKey();
            Console.WriteLine();

            switch (input.Key)
            {
                case ConsoleKey.A:
                    shop.Add();
                    break;
                case ConsoleKey.D:
                    Console.Write("Enter product ID: ");
                    if (int.TryParse(Console.ReadLine(), out var id))
                        shop.Remove(id);
                    else
                        Console.WriteLine("Wrong ID.");
                    break;
                case ConsoleKey.L:
                    var productList = shop.GetItemList();

                    if (productList?.Count == null)
                    {
                        Console.WriteLine("No items.");
                        break;
                    }

                    foreach (var item in productList) Console.WriteLine($"ID: {item.Id}, Name: {item.Name}");
                    break;
                case ConsoleKey.X:
                    Console.WriteLine("Quitting...");
                    return;
                default:
                    Console.WriteLine("Unknown command. Try again.");
                    break;
            }
        }
    }

    private static void Librarian()
    {
        var library = new Library();
        var reader = new CuriousReader(library);

        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1 - Add book to library");
            Console.WriteLine("2 - Show books in library");
            Console.WriteLine("3 - Quit");

            Console.Write("Enter command: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Write("Enter book name: ");
                    var bookName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(bookName))
                    {
                        library.AddBook(bookName);
                        Console.WriteLine($"Book '{bookName}' added to library.");
                    }
                    else
                    {
                        Console.WriteLine("Enter correct book name.");
                    }

                    break;

                case "2":
                    var books = library.GetBookList();
                    if (books == null || books.Length == 0)
                        Console.WriteLine("Book list is empty.");
                    else
                        foreach (var book in books)
                            Console.WriteLine(book);

                    break;

                case "3":
                    Console.WriteLine("Quitting...");
                    return;

                default:
                    Console.WriteLine("Unknown command. Try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    private static void House()
    {
        var part1 = new Part1();
        var part2 = new Part2();
        var part3 = new Part3();
        var part4 = new Part4();
        var part5 = new Part5();
        var part6 = new Part6();
        var part7 = new Part7();
        var part8 = new Part8();
        var part9 = new Part9();
        var part10 = new Part10();
        var part11 = new Part11();

        part1.AddPart();
        part2.AddPart(part1.Poem);
        part3.AddPart(part2.Poem);
        part4.AddPart(part3.Poem);
        part5.AddPart(part4.Poem);
        part6.AddPart(part5.Poem);
        part7.AddPart(part6.Poem);
        part8.AddPart(part7.Poem);
        part9.AddPart(part8.Poem);
        part10.AddPart(part9.Poem);
        part11.AddPart(part10.Poem);

        var parts = new List<Part>
        {
            part1,
            part2,
            part3,
            part4,
            part5,
            part6,
            part7,
            part8,
            part9,
            part10,
            part11
        };

        var partName = "Part";
        var partNumber = 1;

        foreach (var part in parts)
        {
            Console.WriteLine($"{partName} {partNumber++}:");
            Console.WriteLine();
            Console.WriteLine(part.GetPoemAsString());
            Console.WriteLine();
        }

        Console.WriteLine("Test part 3:");
        Console.WriteLine(part3.GetPoemAsString());

        Console.ReadKey();
    }
}