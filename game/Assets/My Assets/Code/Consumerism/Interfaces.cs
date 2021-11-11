using System.Collections.Generic;

namespace F500.Consumerism
{
	// Producers add "items" into the economy
	public interface IProducer {}
	
	// Consumers remove "items" from the economy
	public interface IConsumer {}
	
	// Sellers sell items to the market
	public interface ISeller {}
	
	// Buyers buy items from the market
	public interface IBuyer {}
	
	public interface IEconomicItem {}

	public interface IMarketPlace
	{
		Dictionary<string, IEconomicItem> Items { get; }
		event PriceChangedEvent PriceChanged;
		event QuantityChangedEvent QuantityChanged;
		event VolumeChangedEvent VolumeChanged;

		bool CanBuy(IEconomicItem item);
		void Buy(IEconomicItem item);
	}
}