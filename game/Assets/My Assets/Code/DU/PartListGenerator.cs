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

        public Dictionary<string, OutputPart> Parts { get; private set; } = new Dictionary<string, OutputPart>();

        public PartListGenerator(Schematic schematic, int qty)
        {
            Schematic = schematic;
            Quantity = qty;
        }

        public void Generate()
        {
            foreach (Part part in Schematic.Parts)
            {
                Generate(part);
            }
        }

        private void Generate(Part item)
        {
            Schematic schematic = item.Schematic;
            OutputPart itemPart;
            Parts.TryGetValue(schematic.Name, out itemPart);
            if (null == itemPart)
            {
                itemPart = new OutputPart()
                {
                    Schematic = schematic
                };
                Parts.Add(schematic.Name, itemPart);
            }

            foreach (Part part in schematic.Parts)
            {
                Generate(part);
            }
        }
    }
}