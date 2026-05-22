using MiniBookstore.Mvc.Models;
using MiniBookstore.Mvc.ViewModels;

namespace MiniBookstore.Mvc.Services;

public class BookService
{
    private readonly List<Book> _books = new()
    {
        new Book { Id = 1, Isbn = "BK-978-01", Title = "C# Programming Advanced", Author = "John Doe", Category = "IT & Programming", Publisher = "O'Reilly", Price = 450000, StockQuantity = 12, MinStock = 5, PublishedDate = new DateTime(2023, 10, 15) },
        new Book { Id = 2, Isbn = "BK-978-02", Title = "The Clean Coder", Author = "Robert C. Martin", Category = "Software Engineering", Publisher = "Prentice Hall", Price = 520000, StockQuantity = 35, MinStock = 10, PublishedDate = new DateTime(2011, 5, 13) },
        new Book { Id = 3, Isbn = "BK-978-03", Title = "ASP.NET Core in Action", Author = "Andrew Lock", Category = "Web Development", Publisher = "Manning", Price = 600000, StockQuantity = 4, MinStock = 8, PublishedDate = new DateTime(2021, 2, 28) },
        new Book { Id = 4, Isbn = "BK-978-04", Title = "Design Patterns", Author = "Gang of Four", Category = "Software Engineering", Publisher = "Addison-Wesley", Price = 580000, StockQuantity = 0, MinStock = 6, PublishedDate = new DateTime(1994, 10, 31) },
        new Book { Id = 5, Isbn = "BK-978-05", Title = "Rich Dad Poor Dad", Author = "Robert Kiyosaki", Category = "Business & Finance", Publisher = "Plata", Price = 180000, StockQuantity = 40, MinStock = 15, PublishedDate = new DateTime(1997, 4, 1) },
        new Book { Id = 6, Isbn = "BK-978-06", Title = "Atomic Habits", Author = "James Clear", Category = "Self-Help", Publisher = "Penguin", Price = 200000, StockQuantity = 22, MinStock = 10, PublishedDate = new DateTime(2018, 10, 16) }
    };

    public List<Book> GetAll() => _books;

    public Book? GetById(int id) => _books.FirstOrDefault(b => b.Id == id);

    public BookStatsViewModel GetStats()
    {
        return new BookStatsViewModel
        {
            TotalTitles = _books.Count,
            TotalBooksInStock = _books.Sum(b => b.StockQuantity),
            TotalInventoryValue = _books.Sum(b => b.Price * b.StockQuantity),
            OutOfStockCount = _books.Count(b => b.StockQuantity <= 0),
            LowStockCount = _books.Count(b => b.StockQuantity > 0 && b.StockQuantity <= b.MinStock)
        };
    }
}
