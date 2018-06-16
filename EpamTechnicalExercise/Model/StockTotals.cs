namespace EpamTechnicalExercise.Model
{
    public class StockTotals
    {
        /// <summary>
        /// Stock type 
        /// </summary>
        public string StockType { get; set; }

        /// <summary>
        /// Total number of assets
        /// </summary>
        public int TotalNumber { get; set; }

        /// <summary>
        /// Total stock weight
        /// </summary>
        public double TotalStockWeight { get; set; }

        /// <summary>
        /// Total market value
        /// </summary>
        public double TotalMarketValue { get; set; }
    }
}
