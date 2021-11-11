using System.Collections.Generic;

namespace F500.Consumerism
{
    /// <summary>
    /// A generic buyer that will buy an item off any market place when the
    /// price reaches a certain level
    /// </summary>
    public class StandardBuyer : IBuyer
    {
        public decimal MinPrice { get; set; } = 50.0M;
        public decimal Quantity { get; set; } = 1.0M;
        public IEconomicItem Item { get; set; }
        
        public StandardBuyer()
        {
            ServiceLocator.Current.OnPriceChanged += OnPriceChangedHandler;
        }

        private void OnPriceChangedHandler(PriceChangedEventArgs args)
        {
            if (args.Item.UniqueId != Item.UniqueId)
                return;

            if (args.Price < MinPrice)
            {
                List<IMarketPlace> markets = ServiceLocator.Current.GetMarkets();
                foreach (IMarketPlace m in markets)
                {
                    if (m.CanBuy(args.Item, Quantity))
                        m.Buy(args.Item, Quantity);
                }
            }
        }
    }
}