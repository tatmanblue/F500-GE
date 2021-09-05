namespace F500.DU
{
    public class Part
    {
        public Schematic Schematic { get; set; }
        public decimal QuantityNeeded { get; set; }
    }

    /// <summary>
    /// Computational Class which stores how many of a Part
    /// is created 
    /// </summary>
    public class OutputPart : Part
    {
        /// <summary>
        /// this is the amount of part actually created
        /// it would be a multiple of Schematic.BatchSize
        /// </summary>
        public decimal Created { get; set; }
    }
}