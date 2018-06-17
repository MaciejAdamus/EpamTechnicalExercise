using EpamTechnicalExercise.Converters;
using EpamTechnicalExercise.Model.StockModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace EpamTechnicalExerciseTest.Converters
{
    [TestClass]
    public class StockNameColorConverterTest
    {
        private StockNameColorConverter _converter;
        private Bond _bond;

        [TestInitialize]
        public void TestInitialize()
        {
            _converter = new StockNameColorConverter();
            _bond = new Bond();
        }

        [TestMethod]
        public void ShouldReturnRedBrushIfStockMarketValueIsNegative()
        {
            _bond.Price = -10;
            _bond.Quantity = 1;

            var result = _converter.Convert(_bond, typeof(Brush), null, CultureInfo.InvariantCulture);

            Assert.AreEqual(Brushes.Red, result);
        }

        [TestMethod]
        public void ShouldReturnRedBrushIfTransactionCostIsAboveTolerance()
        {
            _bond.Quantity = 1;
            _bond.Price = (_bond.TransactionCostTolerance + 1) / _bond.TransactionCostPct;

            var result = _converter.Convert(_bond, typeof(Brush), null, CultureInfo.InvariantCulture);

            Assert.AreEqual(Brushes.Red, result);
        }

        [TestMethod]
        public void ShouldReturnDependencyPropertyUnsetValueIfTransactionCostIsBelowTolerance()
        {
            _bond.Quantity = 1;
            _bond.Price = 1;

            var result = _converter.Convert(_bond, typeof(Brush), null, CultureInfo.InvariantCulture);

            Assert.AreEqual(DependencyProperty.UnsetValue, result);
        }

        [TestMethod]
        public void ShouldReturnDependencyPropertyUnsetValueIfValueIsNull()
        {
            var result = _converter.Convert(null, typeof(Brush), null, CultureInfo.InvariantCulture);

            Assert.AreEqual(DependencyProperty.UnsetValue, result);
        }
    }
}
