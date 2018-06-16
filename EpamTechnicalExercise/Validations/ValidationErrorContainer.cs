using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Data;

namespace EpamTechnicalExercise.Validations
{
    public static class ValidationErrorContainer
    {
        private static Dictionary<string, List<ValidationRule>> _validationErrors = new Dictionary<string, List<ValidationRule>>();
        public static Dictionary<string, List<ValidationRule>> ValidationErrors => _validationErrors;

        public static bool HasErrors
        {
            get { return _validationErrors.Count > 0; }
        }

        public static void AddError(ValidationError validationError)
        {
            var errorKey = GetErrorKeyFromBindingExpression((validationError.BindingInError as BindingExpression));

            if (!_validationErrors.ContainsKey(errorKey))
            {
                _validationErrors[errorKey] = new List<ValidationRule>();
            }

            _validationErrors[errorKey].Add(validationError.RuleInError);
        }

        public static void RemoveError(ValidationError validationError)
        {
            var errorKey = GetErrorKeyFromBindingExpression((validationError.BindingInError as BindingExpression));

            if (_validationErrors.ContainsKey(errorKey))
            {
                _validationErrors[errorKey].Remove(validationError.RuleInError);
            }

            if(_validationErrors[errorKey].Count == 0)
            {
                _validationErrors.Remove(errorKey);
            }
        }

        private static string GetErrorKeyFromBindingExpression(BindingExpression bindingExpression)
        {
            return String.Format("{0}.{1}", bindingExpression.ResolvedSource, bindingExpression.ResolvedSourcePropertyName);
        }
    }
}
