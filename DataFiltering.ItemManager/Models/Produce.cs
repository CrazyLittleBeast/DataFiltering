namespace DataFiltering.ItemManager.Models
{
    public class Produce : GroceryItemBase
    {
        public decimal WeightInKg { get; set; }

        public override decimal CalculateFinalPrice()
        {
            return Price * WeightInKg;
        }
    }
}
