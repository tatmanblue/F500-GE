using F500.Consumerism;
using NUnit.Framework;

namespace F500Tests
{
    public class ConsumerismTests
    {
        [Test]
        public void BuyerBuysAtPrice()
        {
            ServiceLocator.Current.RegisterMarket(new MarketPlace());
            StandardBuyer buyer = new StandardBuyer();
        }
    }
}