namespace EpamTechnicalExercise.Model
{
    public class Bond : Stock
    {
        private const double _transactionCostPct = 2;
        private const double _transactionCostTolerance = 100000;

        protected override double TransactionCostPct => _transactionCostPct;
        protected override double TransactionCostTolerance => _transactionCostTolerance;

        public Bond()
        {
            StockType = StockType.Bond;
        }
    }
}
