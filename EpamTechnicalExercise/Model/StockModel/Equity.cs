﻿namespace EpamTechnicalExercise.Model.StockModel
{
    public class Equity : Stock
    {
        public override double TransactionCostPct => 0.005;
        public override double TransactionCostTolerance => 200000;
        public override StockType StockType => StockType.Equity;
    }
}
