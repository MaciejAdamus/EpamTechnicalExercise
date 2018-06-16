namespace EpamTechnicalExercise.Model
{
    public abstract class Stock
    {
        /// <summary>
        /// Stock Type
        /// </summary>
        public StockType StockType { get; protected set; }

        /// <summary>
        /// Stock Name
        /// </summary>
        public string StockName { get; set; }

        /// <summary>
        /// Price that stock was bought
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Quantity of bought stock
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Market Value - calculated from Price * Quantity
        /// </summary>
        public double MarketValue
        {
            get { return Price * Quantity;  }
        }

        /// <summary>
        /// Transaction Cost Percentage
        /// </summary>
        public abstract double TransactionCostPct { get; }

        /// <summary>
        /// Transaction Cost Tolerance for highlight check
        /// </summary>
        public abstract double TransactionCostTolerance { get; }

        /// <summary>
        /// Transaction Cost - calculated from MarketValue * TransactionCostPct
        /// </summary>
        public double TransactionCost
        {
            get { return MarketValue * TransactionCostPct; }
        }

        /// <summary>
        /// Stock Weight (calculated as a Market Value percentage of the Total Market Value of the Fund)
        /// </summary>
        public double StockWeight { get; set; }
    }
}
