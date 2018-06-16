using EpamTechnicalExercise.Validations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace EpamTechnicalExerciseTest.Validations
{
    [TestClass]
    public class QuantityValidationRuleTest
    {
        private QuantityValidationRule _quantityValidationRule;

        [TestInitialize]
        public void TestInitalize()
        {
            _quantityValidationRule = new QuantityValidationRule();
        }

        [TestMethod]
        public void ValidationResultShouldNotBeValidIfQuantityIsNull()
        {
            var result = _quantityValidationRule.Validate(null, CultureInfo.InvariantCulture);
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void ValidationResultShouldNotBeValidIfQuantityHaveCharacters()
        {
            var result = _quantityValidationRule.Validate("32a", CultureInfo.InvariantCulture);
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void ValidationResultShouldNotBeValidIfQuantityIsFloatingPointNumber()
        {
            var result = _quantityValidationRule.Validate("32.2", CultureInfo.InvariantCulture);
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void ValidationResultShouldNotBeValidIfQuantityIsNegativeValue()
        {
            var result = _quantityValidationRule.Validate("-3", CultureInfo.InvariantCulture);
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void ValidationResultShouldNotBeValidIfQuantityIsCorrectPositiveNumber()
        {
            var result = _quantityValidationRule.Validate("455", CultureInfo.InvariantCulture);
            Assert.IsTrue(result.IsValid);
        }
    }
}
