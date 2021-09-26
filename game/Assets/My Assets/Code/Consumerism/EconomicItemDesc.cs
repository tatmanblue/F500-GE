namespace F500.Consumerism
{
    /// <summary>
    /// The EconomicItemDesc contains the data for an economic item
    /// that affects supply/demand and prices etc...there is one of thse records
    /// per system.
    /// 
    /// Note: this should probably be an interface so that different systems can
    /// have different inventory structures and as long as the type meets the contract
    /// it will work in the system
    /// </summary>
    public class EconomicItemDesc
    {
        public string UniqueId { get; set; }
    }
}