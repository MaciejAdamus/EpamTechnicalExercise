using System;

namespace EpamTechnicalExercise.Model.StockModel
{
    public static class StockFactory
    {
        public static Stock GetStock(int quantity, double price, string name, StockType stockType)
        {
            Stock stock = (Stock)Activator.CreateInstance(StockTypes.GetStockTypeFromString(stockType.ToString()));
            stock.Quantity = quantity;
            stock.Price = price;
            stock.StockName = name;

            return stock;
        }
    }
}
