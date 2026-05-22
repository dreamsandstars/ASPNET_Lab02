using BookstoreLab02.Mvc.Models;
using BookstoreLab02.Mvc.Services;
using BookstoreLab02.Mvc.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreLab02.Mvc.Controllers;

public class BooksController : Controller
{
    private readonly BookService _bookService;

    public BooksController(BookService bookService) { _bookService = bookService; }

    public IActionResult Index(string search = "") 
    {
        ViewBag.Search = search;
        var books = _bookService.GetAll(search).Select(ToListItemViewModel).ToList();
        return View(books);
    }

    public IActionResult Detail(int id)
    {
        var book = _bookService.GetById(id);
        if (book == null) return NotFound($"Không tìm thấy tựa sách nào có id = {id}");
        return View(ToDetailViewModel(book));
    }

    public IActionResult Stats() => View(_bookService.GetStats());
    public IActionResult Welcome() => Content("Chào mừng đến với cửa hàng sách của chúng tôi!");
    [HttpGet("BooksJson")]
    [HttpGet("Books/BookJson")]
    public IActionResult BookJson() => Json(_bookService.GetAll().Select(b => new { b.Id, b.Isbn, b.Title, b.Category, b.Price, b.StockQuantity }));
    public IActionResult GoToList() => RedirectToAction(nameof(Index));
    public IActionResult Force404() => NotFound("Trang không tồn tại.");

    private static BookListItemViewModel ToListItemViewModel(Book b) => new BookListItemViewModel
    {
        Id = b.Id, Isbn = b.Isbn, Title = b.Title, Category = b.Category,
        Publisher = b.Publisher, Price = b.Price, StockQuantity = b.StockQuantity, MinStock = b.MinStock,
        Rating = b.Rating
    };

    private static BookDetailViewModel ToDetailViewModel(Book b) => new BookDetailViewModel
    {
        Id = b.Id, Isbn = b.Isbn, Title = b.Title, Category = b.Category,
        Publisher = b.Publisher, Price = b.Price, StockQuantity = b.StockQuantity,
        MinStock = b.MinStock, LastRestockedAt = b.LastRestockedAt,
        Rating = b.Rating
    };
}
