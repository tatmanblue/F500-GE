using F500.Consumerism;
using NUnit.Framework;

namespace F500Tests
{
    public class ConsumerismTests
    {
        [Test]
        public void BuyerBuysAtPrice()
        {
            MarketPlace marketPlace = new MarketPlace();
            ServiceLocator.Current.RegisterMarket(marketPlace);
            StandardBuyer buyer = new StandardBuyer();

        }
    }
}