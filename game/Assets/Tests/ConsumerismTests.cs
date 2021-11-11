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
            StandardBuyer buyer = new StandardBuyer()
            {
                Item = woodMarketItem,
                Quantity = 1,
                MinPrice = 30
            };
            
            marketPlace.CreatePriceChangeEvent(woodMarketItem, 25);

        }
    }
}