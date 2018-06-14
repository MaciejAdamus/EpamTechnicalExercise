using System;
using System.Collections.Generic;
using System.Linq;

namespace EpamTechnicalExercise.Model
{
    public class Fund
    {
        public List<Stock> stockList;

        public double TotalMarketValue => stockList.Sum(x => x.MarketValue);

        public Fund()
        {
            stockList = new List<Stock>();
        }

        public int GetStockCount<T>()
        {
            return stockList.Count(x => x.GetType() == typeof(T));
        }

        public string GetNextStockName<T>()
        {
            return String.Format("{0}{1}", typeof(T).Name, GetStockCount<T>() + 1);
        }

        public void AddEquity(int quantity, double price)
        {
            stockList.Add(new Equity()
            {
                Quantity = quantity,
                Price = price,
                StockName = GetNextStockName<Equity>()
            });

            UpdateStockWeight();
        }

        public void AddBond(int quantity, double price)
        {
            stockList.Add(new Bond()
            {
                Quantity = quantity,
                Price = price,
                StockName = GetNextStockName<Bond>()
            });

            UpdateStockWeight();
        }

        private void UpdateStockWeight()
        {
            stockList.ForEach(x => x.StockWeight = x.MarketValue / TotalMarketValue * 100);
        }
    }
}
