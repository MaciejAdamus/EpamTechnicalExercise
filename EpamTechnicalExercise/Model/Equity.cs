
namespace EpamTechnicalExercise.Model
{
    public class Equity : Stock
    {
        private const double _transactionCostPct = 0.5;
        private const double _transactionCostTolerance = 200000;

        protected override double TransactionCostPct => _transactionCostPct;
        protected override double TransactionCostTolerance => _transactionCostTolerance;

        public Equity()
        {
            StockType = StockType.Equity;
        }
    }
}
