using System;
using System.Collections.Generic;
using System.Linq;

namespace EpamTechnicalExercise.Model
{
    public class Fund
    {
        public List<Stock> StockList { get; private set; }

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
            StockList.ForEach(x => x.StockWeight = x.MarketValue / TotalMarketValue * 100);
        }
    }
}
