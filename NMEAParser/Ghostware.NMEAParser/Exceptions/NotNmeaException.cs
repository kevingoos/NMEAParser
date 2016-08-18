using System;

namespace Ghostware.NMEAParser.Exceptions
{
    public class NotNmeaException : Exception
    {
        public NotNmeaException() : base("The is not an NMEA message. Please check the format of an NMEA message.")
        {
            
        }
    }
}
