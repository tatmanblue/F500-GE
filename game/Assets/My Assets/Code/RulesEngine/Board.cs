using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace F500.RulesEngine
{
    public class Board
    {
        private BoardPiece[] _pieces;

        public BoardPiece Move(int startPosition, int places)
        {
            throw new NotImplementedException();
        }

        public static Board LoadFromFile(string file)
        {
            Board board = new Board();

            string data = File.ReadAllText(file);
            board._pieces = JsonConvert.DeserializeObject<BoardPiece[]>(data, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            return board;
        }
    }
}