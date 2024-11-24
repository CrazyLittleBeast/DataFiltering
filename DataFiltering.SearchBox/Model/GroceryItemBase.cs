using DataFiltering.Shared.Interface;

namespace DataFiltering.SearchBox.Model
{
    public abstract class GroceryItemBase : IGroceryItem
    {
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        public abstract decimal CalculateFinalPrice();
        public virtual void Restock(int quantity)
        {
            StockQuantity += quantity;
        }
    }
}
