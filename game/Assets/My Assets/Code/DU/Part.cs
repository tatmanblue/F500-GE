namespace F500.DU
{
    public class Part
    {
        public Schematic Schematic { get; set; }
        public decimal Quantity { get; set; }
    }

    /// <summary>
    /// Computational Class which stores how many of a Part
    /// is created 
    /// </summary>
    public class OutputPart : Part
    {
        public decimal Created { get; set; }
    }
}