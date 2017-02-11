using System;
using System.Globalization;
using Ghostware.NMEAParser.Enums;
using Ghostware.NMEAParser.Extensions;
using Ghostware.NMEAParser.NMEAMessages.Base;

namespace Ghostware.NMEAParser.NMEAMessages
{
    public class GprmcMessage : NmeaMessage
    {
        #region Description

        //      $GPRMC,123519,A,4807.038,N,01131.000,E,022.4,084.4,230394,003.1,W*6A
        //
        //      Where:
        //          RMC Recommended Minimum sentence C
        //          123519       Fix taken at 12:35:19 UTC
        //          A            Status A = active or V = Void.
        //          4807.038, N   Latitude 48 deg 07.038' N
        //          01131.000,E Longitude 11 deg 31.000' E
        //          022.4        Speed over the ground in knots
        //          084.4        Track angle in degrees True
        //          230394       Date - 23rd of March 1994
        //          003.1,W Magnetic Variation
        //          *6A The checksum data, always begins with *

        #endregion

        #region Properties

        public TimeSpan FixTime { get; set; }

        /// <summary>
        /// Status A = active or V = Void.
        /// </summary>
        public bool IsActive { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        /// <summary>
        /// Speed over the ground in knots
        /// </summary>
        public double Speed { get; set; }

        /// <summary>
        /// Track angle in degrees True
        /// </summary>
        public double Course { get; set; }

        /// <summary>
        /// Date - 23rd of March 1994
        /// </summary>
        public DateTime UpdateDate { get; set; }

        /// <summary>
        /// Magnetic Variation
        /// </summary>
        public double MagneticVariation { get; set; }

        #endregion

        #region Message parsing

        public override void Parse(string[] messageParts)
        {
            if (messageParts == null || messageParts.Length < 11)
            {
                throw new ArgumentException("Invalid GPGGA message");
            }
            FixTime = messageParts[1].ToTimeSpan();
            IsActive = messageParts[2] == "A";
            Latitude = messageParts[3].ToCoordinates(messageParts[4], CoordinateType.Latitude);
            Longitude = messageParts[5].ToCoordinates(messageParts[6], CoordinateType.Longitude);
            Speed = messageParts[7].ToDouble();
            Course = messageParts[8].ToDouble();
            UpdateDate = DateTime.ParseExact(messageParts[9], "ddMMyy", CultureInfo.InvariantCulture);
            MagneticVariation = messageParts[10].ToDouble();
        }

        #endregion

        public override string ToString()
        {
            return $"Latitude {Latitude} - Longitude {Longitude}";
        }
    }
}
