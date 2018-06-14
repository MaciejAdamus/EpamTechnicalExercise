using EpamTechnicalExercise.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTechnicalExerciseTest.Model
{
    [TestClass]
    public class FundTest
    {
        [TestMethod]
        public void ShouldCorrectlyReturnEquityCount()
        {
            Fund fund = new Fund();
            fund.stockList.Add(new Equity());
            fund.stockList.Add(new Equity());
            fund.stockList.Add(new Bond());
            fund.stockList.Add(new Equity());

            Assert.AreEqual(3, fund.GetStockCount<Equity>());
        }

        [TestMethod]
        public void ShouldCorrectlyReturnNextStockName()
        {
            Fund fund = new Fund();
            fund.stockList.Add(new Equity());
            fund.stockList.Add(new Equity());
            fund.stockList.Add(new Bond());
            fund.stockList.Add(new Equity());

            Assert.AreEqual("Equity4", fund.GetNextStockName<Equity>());
            Assert.AreEqual("Bond2", fund.GetNextStockName<Bond>());
        }

        [TestMethod]
        public void ShouldReturnCorrectTotalMarketValue()
        {
            Fund fund = new Fund();
            fund.AddEquity(1, 100);
            fund.AddEquity(2, 200);
            fund.AddBond(3, 300);

            Assert.AreEqual(1400, fund.TotalMarketValue);
        }

        [TestMethod]
        public void ShouldCorrectlyUpdateStockWeight()
        {
            Fund fund = new Fund();
            fund.AddEquity(1, 100);
            Assert.AreEqual(100, fund.stockList[0].StockWeight);

            fund.AddEquity(2, 200);
            Assert.AreEqual(20, fund.stockList[0].StockWeight);
            Assert.AreEqual(80, fund.stockList[1].StockWeight);

            fund.AddBond(3, 300);
            Assert.AreEqual(100d/1400d * 100, fund.stockList[0].StockWeight);
            Assert.AreEqual(400d/1400d * 100, fund.stockList[1].StockWeight);
            Assert.AreEqual(900d/1400d * 100, fund.stockList[2].StockWeight);
        }
    }
}
