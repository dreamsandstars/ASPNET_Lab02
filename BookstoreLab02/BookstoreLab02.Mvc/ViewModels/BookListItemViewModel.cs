namespace BookstoreLab02.Mvc.ViewModels;

public class BookListItemViewModel
{
    public int Id { get; set; }
    public string Isbn { get; set; } = "";
    public string Title { get; set; } = "";
    public string Category { get; set; } = "";
    public string Publisher { get; set; } = "";
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public int MinStock { get; set; }
    public double Rating { get; set; }

    public string PriceText => $"{Price:N0} VND";
    public decimal InventoryValue => Price * StockQuantity;
    public string InventoryValueText => $"{InventoryValue:N0} VND";

    public string StockStatus
    {
        get
        {
            if (StockQuantity >= 50) return "Tồn sách nhiều";
            if (StockQuantity <= 0) return "Hết sách";
            if (StockQuantity <= MinStock) return "Cần nhập thêm";
            return "Còn sách";
        }
    }

    public string StockStatusClass
    {
        get
        {
            if (StockQuantity >= 50) return "badge badge-info";
            if (StockQuantity <= 0) return "badge badge-danger";
            if (StockQuantity <= MinStock) return "badge badge-warning";
            return "badge badge-success";
        }
    }
}
