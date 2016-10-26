using System;
using Ghostware.NMEAParser.NMEAMessages.Base;

namespace Ghostware.NMEAParser
{
    public class NmeaParser
    {
        /// <summary>
        /// Parses a string to the NmeaMessage class.
        /// </summary>
        /// <param name="message">The nmea string that need to be parsed.</param>
        /// <returns>Returns an NmeaMessage class. If it cannot parse it will return null.</returns>
        public NmeaMessage Parse(string message)
        {
            if (!message.StartsWith("$"))
            {
                return null;
            }
            var messageParts = message.Split(',');
            var classType = NmeaConstants.GetClassType(messageParts[0].TrimStart('$'));
            var newInstance = (NmeaMessage)Activator.CreateInstance(classType);
            newInstance.Parse(messageParts);
            return newInstance;
        }
    }
}
