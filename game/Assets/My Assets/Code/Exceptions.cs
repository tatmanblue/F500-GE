using System;

namespace F500
{
    public class RulesException : Exception
    {
        public RulesException(string message) : base(message)
        {
        }
    }
}