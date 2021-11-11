using System.Collections.Generic;

namespace F500.Consumerism
{
    /// <summary>
    /// Market place is the store, where buyers and sellers do their transactions
    /// </summary>
    public class MarketPlace : IMarketPlace
    {
        public Dictionary<string, IEconomicItem> Items { get; } = new Dictionary<string, IEconomicItem>();
        public event PriceChangedEvent PriceChanged;
        public event QuantityChangedEvent QuantityChanged;
        public event VolumeChangedEvent VolumeChanged;

        public bool CanBuy(IEconomicItem item)
        {
            return true;
        }

        public void Buy(IEconomicItem item)
        {
            
        }
    }
}