using System.Globalization;
using System.Windows.Controls;

namespace EpamTechnicalExercise.Validations
{
    public class QuantityValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value != null && int.TryParse(value.ToString(), out int i) && i > 0)
            {
                return new ValidationResult(true, null);
            }

            return new ValidationResult(false, "Value is not valid quantity.");
        }
    }
}
