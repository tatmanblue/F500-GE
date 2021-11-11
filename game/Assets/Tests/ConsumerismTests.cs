using System;
using F500.Consumerism;
using NUnit.Framework;

namespace F500Tests
{
    public class TestMarketPlace : MarketPlace
    {
        public void CreatePriceChangeEvent(EconomicItem item, decimal newPrice)
        {
            FirePriceChangeEvent(item, newPrice);
        }
    }
   
    public class ConsumerismTests
    {
        [Test]
        public void BuyerBuysAtPrice()
        {
            EconomicItem woodAtMarket = new EconomicItem
            {
                Price = 50M,
                Qty = 50M,
                UniqueId = "wood"
            };

            EconomicItem woodCriteria = new EconomicItem()
            {
                Price = 30,
                Qty = 1,
                UniqueId = "wood"
            };

            TestMarketPlace marketPlace = new TestMarketPlace();
            marketPlace.Items.Add(woodAtMarket.UniqueId, woodAtMarket);
            
            ServiceLocator.Current.RegisterMarket(marketPlace);
            StandardBuyer buyer = new StandardBuyer()
            {
                Item = woodCriteria,
                Quantity = 1,
                MinPrice = 30
            };
            
            marketPlace.CreatePriceChangeEvent(woodAtMarket, 25);

        }
    }
}