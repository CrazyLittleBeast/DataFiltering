using System.Globalization;
using System.Windows.Controls;

namespace DataFiltering.Shared.Styles.ValidationRules
{
    public class StockQuantityValidationRules : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is string stockInput)
            {
                if (string.IsNullOrEmpty(stockInput))
                    return new ValidationResult(false, "Cannot have something we dont have");

                if (!int.TryParse(stockInput, out int quantity))
                    return new ValidationResult(false, "That's an invalid quantity format");

                if (quantity < 1)
                    return new ValidationResult(false, "Cannot have something we dont have");

                if (quantity > 500)
                    return new ValidationResult(false, "We might need to expand the warehouse for that");

                return ValidationResult.ValidResult;
            }
            return new ValidationResult(false, "Invalid Input!");
        }
    }
}
