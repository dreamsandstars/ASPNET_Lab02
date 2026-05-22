using BookstoreLab02.Mvc.Models;
using BookstoreLab02.Mvc.ViewModels;

namespace BookstoreLab02.Mvc.Services;

public class BookService
{
    private readonly List<Book> _books = new()
    {
        new Book { Id = 1, Isbn = "BA-1001", Title = "Dế Mèn Phiêu Lưu Ký", Category = "Thiếu nhi", Publisher = "NXB Kim Đồng", Price = 45000, StockQuantity = 60, MinStock = 10, LastRestockedAt = new DateTime(2025, 1, 10), Rating = 4.8 },
        new Book { Id = 2, Isbn = "BA-1002", Title = "Đắc Nhân Tâm", Category = "Kỹ năng sống", Publisher = "NXB Tổng Hợp", Price = 88000, StockQuantity = 5, MinStock = 15, LastRestockedAt = new DateTime(2025, 2, 12), Rating = 4.5 },
        new Book { Id = 3, Isbn = "BA-1003", Title = "Clean Code in C#", Category = "IT", Publisher = "NXB Trẻ", Price = 250000, StockQuantity = 0, MinStock = 5, LastRestockedAt = new DateTime(2024, 12, 1), Rating = 5.0 },
        new Book { Id = 4, Isbn = "BA-1004", Title = "Lược Sự Loài Người", Category = "Khoa học - Lịch sử", Publisher = "Nhã Nam", Price = 180000, StockQuantity = 12, MinStock = 10, LastRestockedAt = new DateTime(2025, 3, 5), Rating = 4.7 },
        new Book { Id = 5, Isbn = "BA-1005", Title = "Nhà Giả Kim", Category = "Văn học", Publisher = "Nhã Nam", Price = 120000, StockQuantity = 3, MinStock = 10, LastRestockedAt = new DateTime(2025, 4, 1), Rating = 4.9 }
    };

    public List<Book> GetAll(string search = "") 
    {
        if (string.IsNullOrEmpty(search)) return _books;
        return _books.Where(b => b.Title.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();
    }
    
    public Book? GetById(int id) => _books.FirstOrDefault(b => b.Id == id);
    
    public BookStatsViewModel GetStats()
    {
        var totalTitles = _books.Count;
        var totalCopies = _books.Sum(b => b.StockQuantity);
        var totalValue = _books.Sum(b => b.Price * b.StockQuantity);
        
        var categoryStats = _books.GroupBy(b => b.Category)
                                  .Select(g => new CategoryStat
                                  {
                                      CategoryName = g.Key,
                                      Count = g.Count(),
                                      TotalValue = g.Sum(b => b.Price * b.StockQuantity)
                                  }).ToList();
        
        return new BookStatsViewModel
        {
            TotalTitles = totalTitles,
            TotalCopies = totalCopies,
            TotalInventoryValue = totalValue,
            OutOfStockCount = _books.Count(b => b.StockQuantity <= 0),
            NeedReorderCount = _books.Count(b => b.StockQuantity > 0 && b.StockQuantity <= b.MinStock),
            InStockCount = _books.Count(b => b.StockQuantity > b.MinStock),
            MaxInventoryValue = _books.Any() ? _books.Max(b => b.Price * b.StockQuantity) : 0,
            AverageInventoryValue = totalTitles > 0 ? totalValue / totalTitles : 0,
            AverageQuantity = totalTitles > 0 ? (double)totalCopies / totalTitles : 0,
            CategoryBreakdown = categoryStats
        };
    }
}
