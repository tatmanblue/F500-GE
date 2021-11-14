using System.Collections.Generic;

namespace F500.Consumerism
{
    public class ServiceLocator
    {
        private List<IMarketPlace> markets = new List<IMarketPlace>();

        public static ServiceLocator Current { get; private set; } = new ServiceLocator();
        public static void Initiailze(){}

        public void RegisterMarket(IMarketPlace market)
        {
            markets.Add(market);
        }

        public List<IMarketPlace> GetMarkets()
        {
            // hmmm....do we need to worry about deep copy?
            return new List<IMarketPlace>(markets.ToArray());
        }
    }
}