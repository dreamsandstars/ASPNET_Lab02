namespace MiniBookstore.Mvc.ViewModels;

public class BookDetailViewModel
{
    public int Id { get; set; }
    public string Isbn { get; set; } = "";
    public string Title { get; set; } = "";
    public string Author { get; set; } = "";
    public string Category { get; set; } = "";
    public string Publisher { get; set; } = "";
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public int MinStock { get; set; }
    public DateTime PublishedDate { get; set; }

    public string PriceText => $"{Price:N0} đ";
    public decimal InventoryValue => Price * StockQuantity;
    public string InventoryValueText => $"{InventoryValue:N0} đ";
    public string PublishedDateText => PublishedDate.ToString("dd/MM/yyyy");

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

    public string ReorderSuggestion
    {
        get
        {
            if (StockQuantity <= 0) return "Sách đã hết, hãy liên hệ nhà xuất bản sớm.";
            if (StockQuantity <= MinStock) return $"Chỉ còn {StockQuantity} quyển. Nên tái bản hoặc nhập lô mới.";
            return "Số lượng trong kho đang ở mức an toàn.";
        }
    }
}
