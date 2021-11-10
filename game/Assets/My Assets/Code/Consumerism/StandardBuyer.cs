namespace F500.Consumerism
{
    public class StandardBuyer
    {
        public decimal MinPrice { get; private set; } = 50.0M;
        public decimal Quantity { get; private set; } = 1.0M;
        
        public StandardBuyer()
        {
            ServiceLocator.Current.OnPriceChanged += OnPriceChangedHandler;
        }

        private void OnPriceChangedHandler(PriceChangedEventArgs args)
        {
            
        }
    }
}