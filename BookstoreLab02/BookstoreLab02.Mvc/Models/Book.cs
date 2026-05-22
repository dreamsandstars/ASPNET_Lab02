namespace BookstoreLab02.Mvc.Models;

public class Book
{
    public int Id { get; set; }
    public string Isbn { get; set; } = "";
    public string Title { get; set; } = "";
    public string Category { get; set; } = "";
    public string Publisher { get; set; } = "";
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public int MinStock { get; set; }
    public DateTime LastRestockedAt { get; set; }
    public double Rating { get; set; } // New: 1.0 to 5.0
}
