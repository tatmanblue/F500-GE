using System.Collections.Generic;

namespace F500.Consumerism
{
    /// <summary>
    /// When the quantity changes adjust the price by
    /// PriceChange * WhenQtyChange
    ///
    /// This responder takes no consideration for economic or market availability
    /// </summary>
    public class LinearPriceResponder : IMarketResponder
    {
        public decimal AdjustPriceBy { get; private set; }
        public decimal WhenQtyChangesBy { get; private set; }

        public LinearPriceResponder(decimal adjustPriceBy = 1, decimal whenQtyChangesBy = 1)
        {
            AdjustPriceBy = adjustPriceBy;
            WhenQtyChangesBy = whenQtyChangesBy;
        }

        public decimal ComputePrice(ComputePriceAdjustmentData args)
        {
            if (args.Trigger == MarketChangeTriggers.Error || args.Trigger == MarketChangeTriggers.System)
                return Constants.NOT_APPLICABLE;
            
            if (args.Quantity > WhenQtyChangesBy)
                return Constants.NOT_APPLICABLE;

            int modifer = Constants.PRICE_GOES_UP;
            if (args.Trigger == MarketChangeTriggers.Sell)
                modifer = Constants.PRICE_GOES_DOWN;
            
            decimal priceAdjustment = WhenQtyChangesBy * args.Quantity * modifer;

            return priceAdjustment;
        }
    }
}