using System;
using System.Collections.Generic;

namespace F500.Consumerism
{
    /// <summary>
    /// Market place is the store, where buyers and sellers do their transactions
    /// </summary>
    public class MarketPlace : IMarketPlace
    {
        private PriceChangedEvent priceChangedEvent;
        private QuantityChangedEvent qtyChangedEvent;
        private VolumeChangedEvent volumeChangedEvent;

        public Dictionary<string, IEconomicItem> Items { get; } = new Dictionary<string, IEconomicItem>();
        
        public event PriceChangedEvent PriceChanged
        {
            add
            {
                priceChangedEvent -= value;
                priceChangedEvent += value;
            }
            remove
            {
                priceChangedEvent -= value;
            }
        }
        public event QuantityChangedEvent QuantityChanged
        {
            add
            {
                qtyChangedEvent -= value;
                qtyChangedEvent += value;
            }
            remove
            {
                qtyChangedEvent -= value;
            }
        }
        public event VolumeChangedEvent VolumeChanged
        {
            add
            {
                volumeChangedEvent -= value;
                volumeChangedEvent += value;
            }
            remove
            {
                volumeChangedEvent -= value;
            }
        }

        protected void FirePriceChangeEvent(EconomicItem item, decimal newPrice)
        {
            PriceChangedEvent safeEvent = priceChangedEvent;
            if (null == safeEvent) return;
            PriceChangedEventArgs args = new PriceChangedEventArgs
            {
                Item = item,
                Price = newPrice
            };

            safeEvent(args);
        }

        protected void FireQtyChangeEvent(EconomicItem item, decimal newQty)
        {
            QuantityChangedEvent safeEvent = qtyChangedEvent;
            if (null == safeEvent) return;
            QtyChangedEventArgs args = new QtyChangedEventArgs
            {
                Item = item,
                Quantity = newQty
            };

            safeEvent(args);
        }

        protected void FireVolumeChangeEvent(EconomicItem item, decimal newVolume)
        {
            VolumeChangedEvent safeEvent = volumeChangedEvent;
            if (null == safeEvent) return;
            VolumeChangedEventArgs args = new VolumeChangedEventArgs
            {
                Item = item,
                Volume = newVolume
            };

            safeEvent(args);
        }
        
        public bool CanBuy(IEconomicItem item, decimal qty)
        {
            return true;
        }

        public void Buy(IEconomicItem item, decimal qty)
        {
            
        }
    }
    
}