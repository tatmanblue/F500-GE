using System;
using PlasticPipe.Server;

namespace F500.Consumerism
{
    public class PriceChangedEventArgs
    {
        public IEconomicItem Item { get; set; }
        public DateTime When { get; set; } = DateTime.Now;
        public decimal Price { get; set; }
    }

    public class VolumeChangedEventArgs
    {
        public IEconomicItem Item { get; set; }
        public DateTime When { get; set; } = DateTime.Now;
        public decimal Volume { get; set; }
    }

    public class QtyChangedEventArgs
    {
        public IEconomicItem Item { get; set; }
        public DateTime When { get; set; } = DateTime.Now;
        public decimal Quantity { get; set; }
    }
    
    public delegate void PriceChangedEvent(PriceChangedEventArgs args);

    public delegate void VolumeChangedEvent(VolumeChangedEventArgs args);

    public delegate void QuantityChangedEvent(QtyChangedEventArgs args);
}