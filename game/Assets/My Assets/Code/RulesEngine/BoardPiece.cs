using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace F500.RulesEngine
{
    [Flags]
    public enum BoardTrigger
    {
        None = 0,
        BusinessCondition = 1,
        EnvironmentCondition = 2,
        PayDay = 4,
        PathDecision = 8
    }
    
    public enum BoardPieceType
    {
        Error,
        BusinessCondition,
        EnvironmentCondition,
        Financial,
        Investments,
        Manufacturing,
        Sales
    }
    
    public class BoardPiece
    {
        public int Position { get; set; }
        public string Display { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public BoardPieceType Type { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public BoardTrigger Trigger { get; set; }
    }
    
}