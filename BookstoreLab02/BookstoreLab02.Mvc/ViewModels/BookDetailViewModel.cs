namespace BookstoreLab02.Mvc.ViewModels;

public class BookDetailViewModel
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
    public double Rating { get; set; }

    public string PriceText => $"{Price:N0} VND";
    public decimal InventoryValue => Price * StockQuantity;
    public string InventoryValueText => $"{InventoryValue:N0} VND";
    public string LastRestockedText => LastRestockedAt.ToString("dd/MM/yyyy HH:mm");

    public string StockStatus
    {
        get
        {
            if (StockQuantity <= 0) return "Hết sách";
            if (StockQuantity <= MinStock) return "Cần nhập thêm";
            return "Còn sách";
        }
    }

    public string ReorderSuggestion
    {
        get
        {
            if (StockQuantity <= 0) return "Cần nhập ngay vì sách đã hết.";
            if (StockQuantity <= MinStock) return $"Nên nhập thêm. Hiện tại chỉ còn {StockQuantity} cuốn, mức tối thiểu là {MinStock}.";
            return "Số lượng sách trong kho đang ổn định.";
        }
    }

    public string StockStatusClass
    {
        get
        {
            if (StockQuantity <= 0) return "danger";
            if (StockQuantity <= MinStock) return "warning";
            return "success";
        }
    }

    public string StockBadgeClass => $"badge-{StockStatusClass}";
}
