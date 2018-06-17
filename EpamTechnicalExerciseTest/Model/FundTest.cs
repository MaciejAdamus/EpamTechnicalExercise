using EpamTechnicalExercise.Model.StockModel;
using EpamTechnicalExercise.Model.FundModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace EpamTechnicalExerciseTest.Model
{
    [TestClass]
    public class FundTest
    {
        private Fund _fund;

        [TestInitialize]
        public void TestInitialize()
        {
            _fund = new Fund();
        }

        [TestMethod]
        public void ShouldCorrectlyReturnEquityCount()
        {
            _fund.StockList.Add(new Equity());
            _fund.StockList.Add(new Equity());
            _fund.StockList.Add(new Bond());
            _fund.StockList.Add(new Equity());

            Assert.AreEqual(3, _fund.GetStockCount(StockType.Equity));
        }

        [TestMethod]
        public void ShouldCorrectlyReturnNextStockName()
        {
            _fund.StockList.Add(new Equity());
            _fund.StockList.Add(new Equity());
            _fund.StockList.Add(new Bond());
            _fund.StockList.Add(new Equity());

            Assert.AreEqual("Equity4", _fund.GetNextStockName(StockType.Equity));
            Assert.AreEqual("Bond2", _fund.GetNextStockName(StockType.Bond));
        }

        [TestMethod]
        public void ShouldReturnCorrectTotalMarketValue()
        {
            _fund.AddStock(1, 100, StockType.Equity);
            _fund.AddStock(2, 200, StockType.Equity);
            _fund.AddStock(3, 300, StockType.Bond);

            Assert.AreEqual(1400, _fund.TotalMarketValue);
        }

        [TestMethod]
        public void ShouldCorrectlyUpdateStockWeight()
        {
            _fund.AddStock(1, 100, StockType.Equity);
            Assert.AreEqual(1, _fund.StockList[0].StockWeight);

            _fund.AddStock(2, 200, StockType.Equity);
            Assert.AreEqual(0.2, _fund.StockList[0].StockWeight);
            Assert.AreEqual(0.8, _fund.StockList[1].StockWeight);

            _fund.AddStock(3, 300, StockType.Bond);
            Assert.AreEqual(100d/1400d, _fund.StockList[0].StockWeight);
            Assert.AreEqual(400d/1400d, _fund.StockList[1].StockWeight);
            Assert.AreEqual(900d/1400d, _fund.StockList[2].StockWeight);
        }

        [TestMethod]
        public void TotalsCollectionShouldHaveAllStockTypesAndAllOnLastPosition()
        {
            var stockTypesArray = Enum.GetValues(typeof(StockType));
            var expectedCount = stockTypesArray.Length + 1;

            Assert.AreEqual(expectedCount, _fund.StockTotalsList.Count);
            foreach (var stockType in stockTypesArray)
            {
                Assert.IsTrue(_fund.StockTotalsList.Any(stock => stock.StockType == stockType.ToString()));
            }
            Assert.AreEqual("All", _fund.StockTotalsList.Last().StockType);
        }

        [TestMethod]
        public void TotalsCollectionShouldHaveCorrectTotals()
        {
            _fund.AddStock(10, 100, StockType.Equity);
            _fund.AddStock(20, 200, StockType.Bond);
            _fund.AddStock(30, 300, StockType.Bond);

            Assert.AreEqual(1, _fund.StockTotalsList.Where(total => total.StockType == "Equity").First().TotalNumber);
            Assert.AreEqual(2, _fund.StockTotalsList.Where(total => total.StockType == "Bond").First().TotalNumber);
            Assert.AreEqual(3, _fund.StockTotalsList.Where(total => total.StockType == "All").First().TotalNumber);

            Assert.AreEqual(1000d / 14000d, _fund.StockTotalsList.Where(total => total.StockType == "Equity").First().TotalStockWeight);
            Assert.AreEqual(13000d / 14000d, _fund.StockTotalsList.Where(total => total.StockType == "Bond").First().TotalStockWeight);
            Assert.AreEqual(1, _fund.StockTotalsList.Where(total => total.StockType == "All").First().TotalStockWeight);

            Assert.AreEqual(1000, _fund.StockTotalsList.Where(total => total.StockType == "Equity").First().TotalMarketValue);
            Assert.AreEqual(13000, _fund.StockTotalsList.Where(total => total.StockType == "Bond").First().TotalMarketValue);
            Assert.AreEqual(14000, _fund.StockTotalsList.Where(total => total.StockType == "All").First().TotalMarketValue);
        }
    }
}
