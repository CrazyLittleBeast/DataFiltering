namespace DataFiltering.SearchBox.Model
{
    public class Beverage : GroceryItemBase
    {
        private decimal alcoholTax = 1.2m;


        public Beverage()
        {
        }

        public Beverage(string productName, decimal price, int stockQuantity, float volumeInLiters, bool isAlcoholic)
        {
            ProductName = productName;
            Price = price;
            StockQuantity = stockQuantity;
            VolumeInLiters = volumeInLiters;
            IsAlcoholic = isAlcoholic;
        }

        public float VolumeInLiters { get; set; }
        public bool IsAlcoholic { get; set; }

        public override decimal CalculateFinalPrice()
        {
            return IsAlcoholic ? Price * alcoholTax : Price;
        }
    }
}
