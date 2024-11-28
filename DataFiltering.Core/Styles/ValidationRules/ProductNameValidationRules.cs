using System.Globalization;
using System.Windows.Controls;

namespace DataFiltering.Shared.Styles.ValidationRules
{
    public class ProductNameValidationRules : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {

            if (value is not string productName)
                return new ValidationResult(false, "Wow dont know how you did that but that's not allowed");

            if (string.IsNullOrWhiteSpace(productName))
                return new ValidationResult(false, "Product name cannot be empty.");

            if (productName.Length > 30)
                return new ValidationResult(false, "Wow that's a very long product name, exceeds the limit of 30");

            return ValidationResult.ValidResult;
        }
    }
}
