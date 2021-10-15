using F500.DU;
using NUnit.Framework;
using UnityEditor.VersionControl;
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
                QuantityNeeded = 37.5m
            });
            
            concrete.Parts.Add(new Part()
            {
                Schematic = carbon,
                QuantityNeeded = 37.5m
            });
            
            concrete.Parts.Add(new Part()
            {
                Schematic = calcium,
                QuantityNeeded = 5
            });
            
            PartListGenerator generator = new PartListGenerator(concrete, 50);
            generator.Generate();
            Assert.AreEqual(50, generator.Quantity);
            Assert.AreEqual(1, generator.Iterations);
        }

        [Test]
        public void GeneratePureIron()
        {
            Schematic iron = new Schematic()
            {
                Name = "Pure Iron",
                BatchOutputSize = 45
            };

            Schematic ironOre = new Schematic()
            {
                Name = "Hematite",
                BatchOutputSize = 1
            };
            
            iron.Parts.Add(new Part()
            {
                Schematic = ironOre,
                QuantityNeeded = 60,            // what we are saying here is we need 60 Hematite to produce 45 pure iron
            });

            PartListGenerator generator = new PartListGenerator(iron, 45);
            generator.Generate();
            Assert.AreEqual(1, generator.Parts.Count);
            OutputPart result = generator.Parts[ironOre.Name];
            Assert.AreEqual(60, result.Created);
            Assert.AreEqual(1, generator.Iterations);
            
            generator = new PartListGenerator(iron, 100);
            generator.Generate();
            Assert.AreEqual(1, generator.Parts.Count);
            result = generator.Parts[ironOre.Name];
            Assert.AreEqual(180, result.Created);
            Assert.AreEqual(3, generator.Iterations);
        }
    }
}