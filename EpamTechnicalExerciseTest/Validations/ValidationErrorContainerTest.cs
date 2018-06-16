using EpamTechnicalExercise.Validations;
using EpamTechnicalExerciseTest.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Controls;
using System.Windows.Data;

namespace EpamTechnicalExerciseTest.Validations
{
    [TestClass]
    public class ValidationErrorContainerTest
    {
        private ValidationError _error;
        private FakeValidationRule _validationRule;

        [TestInitialize]
        public void TestInitalize()
        {
            FakeObject fakeObject = new FakeObject();
            FakeControl fakeControl = new FakeControl();
            Binding myBinding = new Binding("FakeProperty");
            myBinding.Source = fakeObject;
            fakeControl.SetBinding(FakeControl.FakeDependencyProperty, myBinding);

            BindingExpression expression = BindingOperations.GetBindingExpression(fakeControl, FakeControl.FakeDependencyProperty);

            _validationRule = new FakeValidationRule();
            _error = new ValidationError(_validationRule, expression);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            ValidationErrorContainer.ValidationErrors.Clear();
        }

        [TestMethod]
        public void ShouldCorrectlyAddValidationError()
        {
            ValidationErrorContainer.AddError(_error);

            var keyName = String.Format("{0}.FakeProperty", typeof(FakeObject).FullName);

            Assert.AreEqual(1, ValidationErrorContainer.ValidationErrors.Count);
            Assert.IsTrue(ValidationErrorContainer.ValidationErrors.ContainsKey(keyName));
            Assert.AreEqual(1, ValidationErrorContainer.ValidationErrors[keyName].Count);
            Assert.AreEqual(_validationRule, ValidationErrorContainer.ValidationErrors[keyName][0]);
        }

        [TestMethod]
        public void ShouldCorrectlyRemoveValidationError()
        {
            ValidationErrorContainer.AddError(_error);
            ValidationErrorContainer.RemoveError(_error);

            Assert.AreEqual(0, ValidationErrorContainer.ValidationErrors.Count);
        }

    }

    
}
