using System;
using System.Collections.Generic;
using Ghostware.NMEAParser.Exceptions;
using Ghostware.NMEAParser.NMEAMessages;

namespace Ghostware.NMEAParser
{
    public static class NmeaConstants
    {
        private static readonly Dictionary<string, Type> TypeDictionary = new Dictionary<string, Type>
        {
            {"GPGGA", typeof(GpggaMessage)},
            {"GPRMC", typeof(GprmcMessage)},
            {"GPVTG", typeof(GpvtgMessage)},
            {"GPGSA", typeof(GpgsaMessage)}
        };

        /// <summary>
        /// Returns the correct class type of the message.
        /// </summary>
        /// <param name="typeName">The type name given.</param>
        /// <returns>The class type.</returns>
        /// <exception cref="UnknownTypeException">Given if the type is unkown.</exception>
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
