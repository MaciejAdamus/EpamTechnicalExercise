using System.Windows.Controls;
using System.Windows.Data;

namespace EpamTechnicalExerciseTest.Fakes
{
    public class FakeValidationError : ValidationError
    {
        public FakeValidationError() : base(new FakeValidationRule(), GetFakeBindingExpression())
        {
        }

        public FakeValidationError(ValidationRule validationRule) : base(validationRule, GetFakeBindingExpression())
        {

        }

        private static BindingExpression GetFakeBindingExpression()
        {
            FakeObject fakeObject = new FakeObject();
            FakeControl fakeControl = new FakeControl();
            Binding myBinding = new Binding("FakeProperty");
            myBinding.Source = fakeObject;
            fakeControl.SetBinding(FakeControl.FakeDependencyProperty, myBinding);

            BindingExpression expression = BindingOperations.GetBindingExpression(fakeControl, FakeControl.FakeDependencyProperty);

            return expression;
        }
    }
}
