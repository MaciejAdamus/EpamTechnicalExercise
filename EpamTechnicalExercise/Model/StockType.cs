using System;
using System.Collections.Generic;

namespace EpamTechnicalExercise.Model
{
    public enum StockType
    {
        Equity,
        Bond
    }

    /// <summary>
    /// Stock instance Type mapping to StockType enum
    /// </summary>
    public static class StockTypes
    {
        private static Dictionary<StockType, Type> _stockTypes = new Dictionary<StockType, Type>()
        {
            { StockType.Equity, typeof(Equity) },
            { StockType.Bond, typeof(Bond) }
        };

        /// <summary>
        /// Get Type of stock, based on available enum values
        /// </summary>
        public static Type GetStockTypeFromString(string type)
        {
            var typeEnum = (StockType)Enum.Parse(typeof(StockType), type);

            return _stockTypes[typeEnum];
        }
    }
}
