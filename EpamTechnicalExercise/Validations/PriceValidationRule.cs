using System.Globalization;
using System.Windows.Controls;

namespace EpamTechnicalExercise.Validations
{
    public class PriceValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null && double.TryParse(value.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out double i))
                return new ValidationResult(true, null);

            return new ValidationResult(false, "Value is not valid price.");
        }
    }
}
