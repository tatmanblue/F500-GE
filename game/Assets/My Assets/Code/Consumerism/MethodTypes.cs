namespace F500.Consumerism
{
    public class ComputePriceAdjustmentData
    {
        public IMarketableItem Item { get; set; }
        public decimal Quantity { get; set; }
        public MarketChangeTriggers Trigger { get; set; } = MarketChangeTriggers.Error;
    }
}