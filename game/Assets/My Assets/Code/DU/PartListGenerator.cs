using System.Collections.Generic;
using System.Linq;

namespace F500.DU
{
    public class PartListGenerator
    {
        /// <summary>
        /// Hightest level item to make.  It will be made from the list of parts (which
        /// will possibly be made of parts (aka recursion)
        /// </summary>
        public Schematic Schematic { get; private set; }
        /// <summary>
        /// # of this.Schematic to make.  
        /// </summary>
        public int Quantity { get; private set; }

        public List<OutputPart> Parts { get; private set; } = new List<OutputPart>();

        public PartListGenerator(Schematic schematic, int qty)
        {
            Schematic = schematic;
            Quantity = qty;
        }

        public void Generate()
        {
            foreach (Part part in Schematic.Parts)
            {
                Generate(part.Schematic);
            }
        }

        private void Generate(Schematic item)
        {
            foreach (Part part in Schematic.Parts)
            {
                if (!Parts.Any(n => n.Schematic.Name == part.Schematic.Name))
                {
                    OutputPart outputPart = new OutputPart()
                    {
                        Schematic = part.Schematic,
                        Quantity = part.Quantity
                    };
                }
                Generate(part.Schematic);
            }
        }
    }
}