using F500.DU;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace F500Tests
{
    public class PartsAndSchematicsTests
    {
        [Test]
        public void GenerateConcreteCorrectly()
        {
            Schematic silicon = new Schematic()
            {
                Name = "Silicon",
                BatchOutputSize = 50
            };
            
            Schematic carbon = new Schematic()
            {
                Name = "Carbon",
                BatchOutputSize = 50
            };
            
            Schematic calcium = new Schematic()
            {
                Name = "Calcium",
                BatchOutputSize = 50
            };
            
            Schematic concrete = new Schematic()
            {
                Name = "Concrete",
                BatchOutputSize = 75
            };
            
            concrete.Parts.Add(new Part()
            {
                Schematic = silicon,
                Quantity = 37.5m
            });
            
            concrete.Parts.Add(new Part()
            {
                Schematic = carbon,
                Quantity = 37.5m
            });
            
            concrete.Parts.Add(new Part()
            {
                Schematic = calcium,
                Quantity = 5
            });
            
            PartListGenerator generator = new PartListGenerator(concrete, 50);
            generator.Generate();
            Assert.AreEqual(1, generator.Parts.Count);
        }

        [Test]
        public void GeneratePureIron()
        {
            Schematic iron = new Schematic()
            {
                Name = "Pure Iron",
                BatchOutputSize = 50
            };

            Schematic ironOre = new Schematic()
            {
                Name = "Iron Ore",
                BatchOutputSize = 20
            };
            
            iron.Parts.Add(new Part()
            {
                Schematic = ironOre,
                Quantity = 60,
            });

            PartListGenerator generator = new PartListGenerator(iron, 50);
            generator.Generate();
            Assert.AreEqual(1, generator.Parts.Count);
        }
    }
}