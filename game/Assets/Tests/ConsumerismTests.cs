using System;
using F500.Consumerism;
using NUnit.Framework;

namespace F500Tests
{
    public class TestMarketPlace : MarketPlace
    {
        public void CreatePriceChangeEvent(IMarketableItem item, decimal newPrice)
        {
            FirePriceChangeEvent(item, newPrice);
        }
    }
   
    public class ConsumerismTests
    {
        [Test]
        public void BuyerBuysAtPrice()
        {
            EconomicItem woodItem = new EconomicItem(1, "1", "wood");
            MarketableItem woodMarketItem = new MarketableItem()
            {
                Item = woodItem,
                Price = 50,
                Qty = 1000
            };

            TestMarketPlace marketPlace = new TestMarketPlace();
            marketPlace.Items.Add(woodMarketItem.Item.Id, woodMarketItem);
            
            ServiceLocator.Current.RegisterMarket(marketPlace);
            MarketActionItem actionItem = new MarketActionItem()
            {
                Item = woodItem,
                ActionQty = 1,
                Price = 30,
                Qty = Constants.NOT_APPLICABLE,
                Volume = Constants.NOT_APPLICABLE
            };
            
            StandardBuyer buyer = new StandardBuyer()
            {
                Item = actionItem
            };
            
            marketPlace.CreatePriceChangeEvent(woodMarketItem, 25);

        }
    }
}