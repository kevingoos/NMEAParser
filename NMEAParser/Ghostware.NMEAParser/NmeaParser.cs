using System;
using Ghostware.NMEAParser.Exceptions;
using Ghostware.NMEAParser.NMEAMessages;
using Ghostware.NMEAParser.NMEAMessages.Base;

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
            var classType = NmeaConstants.GetClassType(messageParts[0].TrimStart('$'));
            var newInstance = (NmeaMessage)Activator.CreateInstance(classType);
            newInstance.Parse(messageParts);
            return newInstance;
        }
    }
}
