using System.Collections.Generic;

namespace F500.Consumerism
{
	// Producers add "items" into the economy
	public interface IProducer {}
	
	// Consumers remove "items" from the economy
	public interface IConsumer {}
	
	// Sellers sell items to the market
	public interface ISeller {}
	
	/// <summary>
	/// Buyers buy items from the market 
	/// </summary>
	public interface IBuyer {}

	public interface IEconomicItem
	{
		string UniqueId { get; }
		string Name { get; }
	}

	public interface IMarketPlace
	{
		Dictionary<string, IEconomicItem> Items { get; }
		event PriceChangedEvent PriceChanged;
		event QuantityChangedEvent QuantityChanged;
		event VolumeChangedEvent VolumeChanged;

		bool CanBuy(IEconomicItem item, decimal qty);
		void Buy(IEconomicItem item, decimal qty);
	}
}