using EpamTechnicalExercise.Model.StockModel;
using System.Collections.Generic;

namespace EpamTechnicalExercise.Model.FundModel
{
    public interface IFund
    {
        /// <summary>
        /// List of all stocks in Fund
        /// </summary>
        List<Stock> StockList { get; }

        /// <summary>
        /// List of totals from StockList
        /// </summary>
        List<StockTotals> StockTotalsList { get; }

        /// <summary>
        /// Add stock to Fund
        /// </summary>
        void AddStock(int quantity, double price, StockType stockType);
    }
}
