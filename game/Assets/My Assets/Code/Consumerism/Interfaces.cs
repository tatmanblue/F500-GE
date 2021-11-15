using System.Collections.Generic;

namespace F500.Consumerism
{
	#region production and consumption
	// Producers add "items" into the economy
	public interface IProducer {}
	
	// Consumers remove "items" from the economy
	public interface IConsumer {}
	#endregion
	
	#region buying and selling
	// Sellers sell items to the market
	public interface ISeller
	{
		IMarketActionItem Item { get; }
	}

	/// <summary>
	/// Buyers buy items from the market 
	/// </summary>
	public interface IBuyer
	{
		IMarketActionItem Item { get; }
	}
	#endregion

	#region market
	public interface IEconomicItem
	{
		/// <summary>
		/// unique ID, used by system as reference
		/// </summary>
		int Id { get; }
		/// <summary>
		/// not used in the system, usable for identifying
		/// outside the system
		/// </summary>
		string SystemId { get; }
		/// <summary>
		/// a nice name, for display or something
		/// </summary>
		string Name { get; }
	}

	/// <summary>
	/// An item that can be held in the market
	/// </summary>
	public interface IMarketableItem
	{
		IEconomicItem Item { get; }
		decimal Price { get; }
		decimal Qty { get; }
	}

	public interface IMarketActionItem
	{
		IEconomicItem Item { get; }
		decimal Price { get; }
		decimal Qty { get; }
		decimal Volume { get; }
		decimal ActionQty { get; }
	}
	
	public interface IMarketPlace
	{
		Dictionary<int, IMarketableItem> Items { get; }
		event PriceChangedEvent PriceChanged;
		event QuantityChangedEvent QuantityChanged;
		event VolumeChangedEvent VolumeChanged;

		bool CanBuy(IMarketableItem item, decimal qty);
		void Buy(IMarketableItem item, decimal qty);

		bool CanSell(IMarketableItem item, decimal qty);
		void Sell(IMarketableItem item, decimal qty);
	}
	#endregion
}