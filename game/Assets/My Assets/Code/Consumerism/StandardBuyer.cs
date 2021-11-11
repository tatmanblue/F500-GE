using System.Collections.Generic;

namespace F500.Consumerism
{
    public class StandardBuyer : IBuyer
    {
        public decimal MinPrice { get; private set; } = 50.0M;
        public decimal Quantity { get; private set; } = 1.0M;
        
        public StandardBuyer()
        {
            ServiceLocator.Current.OnPriceChanged += OnPriceChangedHandler;
        }

        private void OnPriceChangedHandler(PriceChangedEventArgs args)
        {
            if (args.Price < MinPrice)
            {
                List<IMarketPlace> markets = ServiceLocator.Current.GetMarkets();
                foreach (IMarketPlace m in markets)
                {
                    if (m.CanBuy(args.Item))
                        m.Buy(args.Item);
                }
            }
        }
    }
}