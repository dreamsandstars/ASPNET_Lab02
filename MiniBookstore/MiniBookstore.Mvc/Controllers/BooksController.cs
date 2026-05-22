using Microsoft.AspNetCore.Mvc;
using MiniBookstore.Mvc.Models;
using MiniBookstore.Mvc.Services;
using MiniBookstore.Mvc.ViewModels;

namespace MiniBookstore.Mvc.Controllers;

public class BooksController : Controller
{
    private readonly BookService _bookService;

    public BooksController(BookService bookService)
    {
        _bookService = bookService;
    }

    public IActionResult Index()
    {
        var books = _bookService.GetAll().Select(ToListItemViewModel).ToList();
        return View(books);
    }

    public IActionResult Detail(int id)
    {
        var book = _bookService.GetById(id);
        if (book == null) return NotFound($"Không tìm thấy đầu sách với Mã ID = {id}");
        
        return View(ToDetailViewModel(book));
    }

    public IActionResult Stats()
    {
        return View(_bookService.GetStats());
    }

    public IActionResult Welcome()
    {
        return Content("Chào mừng bạn đến với hệ thống Quản lý Kho sách Mini Bookstore!");
    }

    public IActionResult BookJson()
    {
        var data = _bookService.GetAll().Select(b => new { b.Isbn, b.Title, b.Author, b.StockQuantity });
        return Json(data);
    }

    public IActionResult GoToList()
    {
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Force404()
    {
        return NotFound("Tính năng đang phát triển, tạm thời không khả dụng.");
    }

    private static BookListItemViewModel ToListItemViewModel(Book book)
    {
        return new BookListItemViewModel
        {
            Id = book.Id,
            Isbn = book.Isbn,
            Title = book.Title,
            Author = book.Author,
            Category = book.Category,
            Price = book.Price,
            StockQuantity = book.StockQuantity,
            MinStock = book.MinStock
        };
    }

    private static BookDetailViewModel ToDetailViewModel(Book book)
    {
        return new BookDetailViewModel
        {
            Id = book.Id,
            Isbn = book.Isbn,
            Title = book.Title,
            Author = book.Author,
            Category = book.Category,
            Publisher = book.Publisher,
            Price = book.Price,
            StockQuantity = book.StockQuantity,
            MinStock = book.MinStock,
            PublishedDate = book.PublishedDate
        };
    }
}
