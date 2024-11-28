using System.Globalization;
using System.Windows.Controls;

namespace DataFiltering.Shared.Styles.ValidationRules
{
    public class PriceValidationRules : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is string priceInput)
            {
                if (string.IsNullOrEmpty(priceInput))
                    return new ValidationResult(false, "Need to have a price, no freebies today");

                if (!decimal.TryParse(priceInput, out var price))
                    return new ValidationResult(false, "Invalid Price format. typo?");

                if (price > 2000)
                    return new ValidationResult(false, "Oh that's very expensive for our store");

                return ValidationResult.ValidResult;
            }

            return new ValidationResult(false, "That's not a valid price.");
        }
    }
}
