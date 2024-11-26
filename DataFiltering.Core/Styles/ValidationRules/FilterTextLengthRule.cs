using System.Globalization;
using System.Windows.Controls;

namespace DataFiltering.Shared.Styles.ValidationRules
{
    public class FilterTextLengthRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is string text && text.Length > 20)
            {
                return new ValidationResult(false, "Filter Text exceeding limit of 20 characters");
            }

            return ValidationResult.ValidResult;
        }
    }
}
