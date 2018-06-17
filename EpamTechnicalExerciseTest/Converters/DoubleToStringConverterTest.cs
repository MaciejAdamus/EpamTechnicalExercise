using EpamTechnicalExercise.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;
using System.Windows;

namespace EpamTechnicalExerciseTest.Converters
{
    [TestClass]
    public class DoubleToStringConverterTest
    {
        private DoubleToStringConverter _converter;

        [TestInitialize]
        public void TestInitialize()
        {
            _converter = new DoubleToStringConverter();
        }

        [TestMethod]
        public void ShouldReturnUnsetValueIfConvertingNull()
        {
            var result = _converter.Convert(null, typeof(string), null, CultureInfo.InvariantCulture);
            Assert.AreEqual(DependencyProperty.UnsetValue, result);
        }

        [TestMethod]
        public void ShouldReturnStringValueIfConvertingDouble()
        {
            var result = _converter.Convert(2.01d, typeof(string), null, CultureInfo.InvariantCulture);
            Assert.AreEqual("2,01", result);
        }

        [TestMethod]
        public void ShouldReturnUnsetValueIfConvertingBackNull()
        {
            var result = _converter.ConvertBack(null, typeof(string), null, CultureInfo.InvariantCulture);
            Assert.AreEqual(DependencyProperty.UnsetValue, result);
        }

        [TestMethod]
        public void ShouldReturnUnsetValueIfConvertingBackIncorrectDoubleString()
        {
            var result = _converter.ConvertBack("2.s", typeof(string), null, CultureInfo.InvariantCulture);
            Assert.AreEqual(DependencyProperty.UnsetValue, result);
        }

        [TestMethod]
        public void ShouldReturnDoubleValueIfConvertingBackCorrectDoubleString()
        {
            var result = _converter.ConvertBack("2,01", typeof(string), null, CultureInfo.InvariantCulture);
            Assert.AreEqual(2.01d, result);
        }
    }
}
