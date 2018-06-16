using EpamTechnicalExercise.Validations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace EpamTechnicalExerciseTest.Validations
{
    [TestClass]
    public class PriceValidationRuleTest
    {
        private PriceValidationRule _priceValidationRule;

        [TestInitialize]
        public void TestInitalize()
        {
            _priceValidationRule = new PriceValidationRule();
        }

        [TestMethod]
        public void ValidationResultShouldNotBeValidIfPriceIsNull()
        {
            var result = _priceValidationRule.Validate(null, CultureInfo.InvariantCulture);
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void ValidationResultShouldNotBeValidIfPriceHaveCharacters()
        {
            var result = _priceValidationRule.Validate("123abc", CultureInfo.InvariantCulture);
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void ValidationResultShouldBeValidIfPriceIsCorrectNumber()
        {
            var result = _priceValidationRule.Validate("123", CultureInfo.InvariantCulture);
            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void ValidationResultShouldBeValidIfPriceIsCorrectFloatingPointNumber()
        {
            var result = _priceValidationRule.Validate("123.321", CultureInfo.InvariantCulture);
            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void ValidationResultShouldBeValidIfPriceIsNegative()
        {
            var result = _priceValidationRule.Validate("-44.55", CultureInfo.InvariantCulture);
            Assert.IsTrue(result.IsValid);
        }
    }
}
