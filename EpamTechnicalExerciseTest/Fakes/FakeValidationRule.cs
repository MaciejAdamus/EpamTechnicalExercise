using System.Globalization;
using System.Windows.Controls;

namespace EpamTechnicalExerciseTest.Fakes
{
    public class FakeValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return new ValidationResult(true, null);
        }
    }
}
