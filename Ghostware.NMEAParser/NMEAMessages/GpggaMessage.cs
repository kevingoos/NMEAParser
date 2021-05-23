using System;
using Ghostware.NMEAParser.Enums;
using Ghostware.NMEAParser.Extensions;
using Ghostware.NMEAParser.NMEAMessages.Base;

namespace Ghostware.NMEAParser.NMEAMessages
{
    public class GpggaMessage : NmeaMessage
    {
        #region Description

        //      $GPGGA,123519,4807.038,N,01131.000,E,1,08,0.9,545.4,M,46.9,M,,*47

        //      Where:
        //          GGA Global Positioning System Fix Data
        //          123519       Fix taken at 12:35:19 UTC
        //          4807.038,N Latitude 48 deg 07.038' N
        //          01131.000,E Longitude 11 deg 31.000' E
        //          1            Fix quality: 0 = invalid
        //                                  1 = GPS fix(SPS)
        //                                  2 = DGPS fix
        //                                  3 = PPS fix
        //			                        4 = Real Time Kinematic
        //			                        5 = Float RTK
        //                                  6 = estimated(dead reckoning) (2.3 feature)
        //			                        7 = Manual input mode
        //			                        8 = Simulation mode
        //          08           Number of satellites being tracked
        //          0.9          Horizontal dilution of position
        //          545.4, M      Altitude, Meters, above mean sea level
        //          46.9, M       Height of geoid(mean sea level) above WGS84
        //                      ellipsoid
        //          (empty field) time in seconds since last DGPS update
        //          (empty field) DGPS station ID number
        //          *47          the checksum data, always begins with*

        #endregion

        #region Properties

        /// <summary>
        /// Fix taken
        /// </summary>
        public TimeSpan FixTime { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public GpsFixQuality FixQuality { get; set; }

        public int NumberOfSatellites { get; set; }

        /// <summary>
        /// Horizontal dilution of position
        /// </summary>
        public float Hdop { get; set; }

        /// <summary>
        /// Altitude, Meters, above mean sea level
        /// </summary>
        public float Altitude { get; set; }

        /// <summary>
        /// Altitude units ('M' for Meters)
        /// </summary>
        public string AltitudeUnits { get; set; }

        /// <summary>
        /// Height of geoid (mean sea level) above WGS84
        /// </summary>
        public float HeightOfGeoId { get; set; }

        public string HeightOfGeoIdUnits { get; set; }

        /// <summary>
        /// Time in seconds since last DGPS update
        /// </summary>
        public int TimeSpanSinceDgpsUpdate { get; set; }

        /// <summary>
        /// DGPS station ID number
        /// </summary>
        public int? DgpsStationId { get; set; }

        #endregion

        #region Message parsing

        public override void Parse(string[] messageParts)
        {
            if (messageParts == null || messageParts.Length < 14)
            {
                throw new ArgumentException("Invalid GPGGA message");
            }
            FixTime = messageParts[1].ToTimeSpan();
            Latitude = messageParts[2].ToCoordinates(messageParts[3], CoordinateType.Latitude);
            Longitude = messageParts[4].ToCoordinates(messageParts[5], CoordinateType.Longitude);
            FixQuality = (GpsFixQuality)Enum.Parse(typeof(GpsFixQuality), messageParts[6]);
            NumberOfSatellites = messageParts[7].ToInteger();
            Hdop = messageParts[8].ToFloat();
            Altitude = messageParts[9].ToFloat();
            AltitudeUnits = messageParts[10];
            HeightOfGeoId = messageParts[11].ToFloat();
            HeightOfGeoIdUnits = messageParts[12];
            TimeSpanSinceDgpsUpdate = messageParts[13].ToInteger();
            DgpsStationId = messageParts[14].ToInteger();
        }

        #endregion

        public override string ToString()
        {
            return $"Latitude {Latitude} - Longitude {Longitude} - Hoogte {Altitude}";
        }
    }
}
