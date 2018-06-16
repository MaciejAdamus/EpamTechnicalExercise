using EpamTechnicalExercise.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EpamTechnicalExerciseTest.Model
{
    [TestClass]
    public class StockFactoryTest
    {
        [TestMethod]
        public void ShouldCorrectlyCreateEquityObject()
        {
            int quantity = 1;
            double price = 2.5;
            string name = "Equity1";

            var stock = StockFactory.GetStock(quantity, price, name, StockType.Equity);

            Assert.AreEqual(typeof(Equity), stock.GetType());
            Assert.AreEqual(quantity, stock.Quantity);
            Assert.AreEqual(price, stock.Price);
            Assert.AreEqual(name, stock.StockName);
        }

        [TestMethod]
        public void ShouldCorrectlyCreateBondObject()
        {
            int quantity = 1;
            double price = 2.5;
            string name = "Bond2";

            var stock = StockFactory.GetStock(quantity, price, name, StockType.Bond);

            Assert.AreEqual(typeof(Bond), stock.GetType());
            Assert.AreEqual(quantity, stock.Quantity);
            Assert.AreEqual(price, stock.Price);
            Assert.AreEqual(name, stock.StockName);
        }
    }
}
