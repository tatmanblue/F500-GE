﻿namespace F500.Consumerism
{
    /// <summary>
    /// An item in the economy.  Instance is a aggregation and unique per inventory.
    /// 
    /// Note: this should probably be an interface so that different systems can
    /// have different inventory structures and as long as the type meets the contract
    /// it will work in the system
    /// </summary>
    public class EconomicItem
    {
        public decimal Qty { get; set; }
        public decimal Price { get; set; }
        public string UniqueId { get; set; }
    }
}