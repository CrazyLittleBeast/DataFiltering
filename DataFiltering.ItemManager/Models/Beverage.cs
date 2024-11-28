namespace DataFiltering.ItemManager.Models
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
        public bool IsValid(out string validationMessage)
        {
            if (string.IsNullOrWhiteSpace(ProductName))
            {
                validationMessage = "No name, No Product";
                return false;
            }

            if (Price <= 0)
            {
                validationMessage = "No Freebies.";
                return false;
            }

            if (StockQuantity < 1)
            {
                validationMessage = "Should have atleast 1";
                return false;
            }

            if (VolumeInLiters <= 0)
            {
                validationMessage = "We dont sell empty bottle";
                return false;
            }

            validationMessage = string.Empty;
            return true;
        }
        public override decimal CalculateFinalPrice()
        {
            return IsAlcoholic ? Price * alcoholTax : Price;
        }
    }
}
