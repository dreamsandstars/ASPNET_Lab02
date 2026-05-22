namespace AspNetWeek2.Mvc.ViewModels;

public class ProductListItemViewModel
{
    public int Id { get; set; }
    public string Sku { get; set; } = "";
    public string Name { get; set; } = "";
    public string Category { get; set; } = "";
    public string Supplier { get; set; } = "";
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public int MinStock { get; set; }

    public string PriceText => $"{UnitPrice:N0} VND";
    public decimal InventoryValue => UnitPrice * Quantity;
    public string InventoryValueText => $"{InventoryValue:N0} VND";

    public string StockStatus
    {
        get
        {
            if (Quantity <= 0) return "Hết hàng";
            if (Quantity <= MinStock) return "Cần nhập thêm";
            if (Quantity >= 20) return "Tồn kho cao";
            return "Còn hàng";
        }
    }

    public string StockStatusClass
    {
        get
        {
            if (Quantity <= 0) return "badge badge-danger";
            if (Quantity <= MinStock) return "badge badge-warning";
            if (Quantity >= 20) return "badge badge-info";
            return "badge badge-success";
        }
    }
}
