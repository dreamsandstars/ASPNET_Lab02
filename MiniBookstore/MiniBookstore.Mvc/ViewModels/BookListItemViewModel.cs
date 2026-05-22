namespace MiniBookstore.Mvc.ViewModels;

public class BookListItemViewModel
{
    public int Id { get; set; }
    public string Isbn { get; set; } = "";
    public string Title { get; set; } = "";
    public string Author { get; set; } = "";
    public string Category { get; set; } = "";
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public int MinStock { get; set; }

    public string PriceText => $"{Price:N0} đ";

    public string StockStatus
    {
        get
        {
            if (StockQuantity <= 0) return "Hết sách";
            if (StockQuantity <= MinStock) return "Sắp hết";
            if (StockQuantity >= 30) return "Sẵn nhiều";
            return "Còn hàng";
        }
    }

    public string StockStatusClass
    {
        get
        {
            if (StockQuantity <= 0) return "app-badge badge-danger";
            if (StockQuantity <= MinStock) return "app-badge badge-warning";
            if (StockQuantity >= 30) return "app-badge badge-info";
            return "app-badge badge-success";
        }
    }
}
