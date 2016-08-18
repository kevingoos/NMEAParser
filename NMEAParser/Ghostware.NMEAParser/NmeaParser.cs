using System;
using Ghostware.NMEAParser.Exceptions;
using Ghostware.NMEAParser.NMEAMessages;

namespace Ghostware.NMEAParser
{
    public class NmeaParser
    {
        public NmeaMessage Parse(string message)
        {
            if (!message.StartsWith("$"))
            {
                throw new NotNmeaException();
            }
            var messageParts = message.Split(',');
            var classType = NmeaConstants.GetClassType(messageParts[0].Remove(0));
            var newInstance = (NmeaMessage)Activator.CreateInstance(classType);
            newInstance.Parse(messageParts);
            return newInstance;
        }
    }
}
