using System.Globalization;
using System.Windows.Controls;

namespace DataFiltering.Shared.Styles.ValidationRules
{
    public class ProductVolumeValidationRules : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is string volumeInput)
            {
                if (string.IsNullOrWhiteSpace(volumeInput))
                    return new ValidationResult(false, "That's an empty bottle mate!");

                if (!decimal.TryParse(volumeInput, out var volume))
                    return new ValidationResult(false, "Volume must be a valid number.");

                if (volume < 0.1m)
                    return new ValidationResult(false, $"Volume cannot be less than 0.1.");

                if (volume > 5)
                    return new ValidationResult(false, $"We dont sell in kegs.");

                return ValidationResult.ValidResult;
            }

            return new ValidationResult(false, "Not a valid volume.");
        }
    }
}
