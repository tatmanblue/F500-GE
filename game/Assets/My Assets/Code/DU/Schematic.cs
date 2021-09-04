using System.Collections.Generic;

namespace F500.DU
{
    public class Schematic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal BatchOutputSize { get; set; } = 1;
        public List<Part> Parts { get; set; } = new List<Part>();
        
    }
}