namespace DataFiltering.Shared.Interface
{
    public interface IGroceryItem
    {
        string ProductName { get; set; }
        decimal Price { get; set; }
        int StockQuantity { get; set; }
    }
}
