using System;
using System.Collections.Generic;
using System.Linq;
using EpamTechnicalExercise.Model.StockModel;

namespace EpamTechnicalExercise.Model.FundModel
{
    public class Fund : IFund
    {
        public List<Stock> StockList { get; }
        public List<StockTotals> StockTotalsList { get { return GetTotals(); } }

        public double TotalMarketValue => StockList.Sum(x => x.MarketValue);

        public Fund()
        {
            StockList = new List<Stock>();
        }

        public int GetStockCount(StockType stockType)
        {
            return StockList.Count(x => x.StockType == stockType);
        }

        public string GetNextStockName(StockType stockType)
        {
            return String.Format("{0}{1}", stockType, GetStockCount(stockType) + 1);
        }

        public void AddStock(int quantity, double price, StockType stockType)
        {
            StockList.Add(StockFactory.GetStock(quantity, price, GetNextStockName(stockType), stockType));

            UpdateStockWeight();
        }

        private void UpdateStockWeight()
        {
            StockList.ForEach(x => x.StockWeight = x.MarketValue / TotalMarketValue);
        }

        private List<StockTotals> GetTotals()
        {
            List<StockTotals> result = new List<StockTotals>();

            foreach (StockType stockType in Enum.GetValues(typeof(StockType)))
            {
                result.Add(new StockTotals()
                {
                    StockType = stockType.ToString(),
                    TotalMarketValue = StockList.Where(x => x.StockType == stockType).Sum(x => x.MarketValue),
                    TotalStockWeight = StockList.Where(x => x.StockType == stockType).Sum(x => x.StockWeight),
                    TotalNumber = StockList.Count(x => x.StockType == stockType)
                });
            }

            result.Add(new StockTotals()
            {
                StockType = "All",
                TotalMarketValue = StockList.Sum(x => x.MarketValue),
                TotalStockWeight = StockList.Sum(x => x.StockWeight),
                TotalNumber = StockList.Count
            });

            return result;
        }
    }
}
