using System;
using System.Collections.Generic;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public int Copies { get; set; }

    public Book(string title, string author, string isbn, int copies)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        Copies = copies;
    }
}

public class Reader
{
    public string Name { get; set; }
    public int ReaderId { get; set; }

    public Reader(string name, int readerId)
    {
        Name = name;
        ReaderId = readerId;
    }
}

public class Library
{
    private List<Book> books = new List<Book>();
    private List<Reader> readers = new List<Reader>();

    public void AddBook(Book book)
    {
        books.Add(book);
        Console.WriteLine($"Книга '{book.Title}' добавлена в библиотеку.");
    }

    public void RemoveBook(string isbn)
    {
        var book = books.Find(b => b.ISBN == isbn);
        if (book != null)
        {
            books.Remove(book);
            Console.WriteLine($"Книга '{book.Title}' удалена из библиотеки.");
        }
        else
        {
            Console.WriteLine("Книга не найдена.");
        }
    }

    public void RegisterReader(Reader reader)
    {
        readers.Add(reader);
        Console.WriteLine($"Читатель '{reader.Name}' зарегистрирован.");
    }

    public void LendBook(string isbn, int readerId)
    {
        var book = books.Find(b => b.ISBN == isbn);
        var reader = readers.Find(r => r.ReaderId == readerId);

        if (book == null)
        {
            Console.WriteLine("Книга не найдена.");
        }
        else if (book.Copies > 0)
        {
            book.Copies--;
            Console.WriteLine($"Книга '{book.Title}' выдана читателю '{reader.Name}'.");
        }
        else
        {
            Console.WriteLine("Книга недоступна.");
        }
    }

    public void ReturnBook(string isbn)
    {
        var book = books.Find(b => b.ISBN == isbn);
        if (book != null)
        {
            book.Copies++;
            Console.WriteLine($"Книга '{book.Title}' возвращена в библиотеку.");
        }
        else
        {
            Console.WriteLine("Книга не найдена.");
        }
    }
}

class Program
{
    static void Main()
    {
        var library = new Library();

        var book1 = new Book("1984", "Дети Капитана Гранте", "1234567890", 3);
        var book2 = new Book("Гордость и предубеждение", "Джейн Остин", "0987654321", 2);

        library.AddBook(book1);
        library.AddBook(book2);

        var reader1 = new Reader("Иван Иванов", 1);
        var reader2 = new Reader("Анна Петрова", 2);

        library.RegisterReader(reader1);
        library.RegisterReader(reader2);

        library.LendBook("1234567890", 1); 
        library.LendBook("1234567890", 2); 
        library.LendBook("1234567890", 2); 

        library.ReturnBook("1234567890"); 
        library.LendBook("1234567890", 2); 
    }
}
