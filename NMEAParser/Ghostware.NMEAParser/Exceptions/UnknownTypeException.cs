using System;

namespace Ghostware.GPSDLib.Exceptions
{
    public class UnknownTypeException : Exception
    {
        public UnknownTypeException() : base("Unknown Class Type")
        {
            
        }
    }
}