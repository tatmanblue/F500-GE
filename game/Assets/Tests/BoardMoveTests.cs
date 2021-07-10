using System.Collections;
using System.IO;
using F500.RulesEngine;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace F500Tests
{
    public class BoardMoveTests
    {
        [Test]
        public void MoveOnePlayer()
        {
            string dataFile = Path.GetFullPath(Path.Combine(TestContext.CurrentContext.TestDirectory, "..", "..", @"Assets\My Assets\Data\board.data"));
            Board board = Board.LoadFromFile(dataFile);
            board.Move(0, 1);
        }
        
        [Test]
        public void MoveOnePlayerWithoutData()
        {
            Board board = new Board();
            board.Move(0, 1);
        }
    }
}
