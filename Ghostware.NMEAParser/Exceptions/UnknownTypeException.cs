using System;

namespace Ghostware.NMEAParser.Exceptions
{
    public class UnknownTypeException : Exception
    {
        public UnknownTypeException() : base("Unknown Class Type")
        {
            
        }
    }
}