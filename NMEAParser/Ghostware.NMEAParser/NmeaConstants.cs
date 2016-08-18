using System;
using System.Collections.Generic;
using Ghostware.GPSDLib.Exceptions;
using Ghostware.NMEAParser.NMEAMessages;

namespace Ghostware.NMEAParser
{
    public static class NmeaConstants
    {
        public static Dictionary<string, Type> TypeDictionary = new Dictionary<string, Type>
        {
            {"GPGGA", typeof(GpggaMessage)}
        };

        public static Type GetClassType(string typeName)
        {
            Type result;
            TypeDictionary.TryGetValue(typeName, out result);

            if (result == null)
            {
                throw new UnknownTypeException();
            }

            return result;
        }
    }
}
