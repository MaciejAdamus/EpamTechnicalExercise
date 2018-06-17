namespace EpamTechnicalExercise.Model.StockModel
{
    public class Bond : Stock
    {
        public override double TransactionCostPct => 0.02;
        public override double TransactionCostTolerance => 100000;

        public Bond()
        {
            StockType = StockType.Bond;
        }
    }
}
