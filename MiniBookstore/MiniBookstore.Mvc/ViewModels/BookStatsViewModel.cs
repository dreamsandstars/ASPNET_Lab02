namespace MiniBookstore.Mvc.ViewModels;

public class BookStatsViewModel
{
    public int TotalTitles { get; set; }
    public int TotalBooksInStock { get; set; }
    public decimal TotalInventoryValue { get; set; }
    public int OutOfStockCount { get; set; }
    public int LowStockCount { get; set; }

    public string TotalInventoryValueText => $"{TotalInventoryValue:N0} đ";
}
