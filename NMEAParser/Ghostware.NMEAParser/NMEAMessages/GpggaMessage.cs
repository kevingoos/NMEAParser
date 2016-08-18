using System;
using Ghostware.NMEAParser.Enums;

namespace Ghostware.NMEAParser.NMEAMessages
{
    public class GpggaMessage : NmeaMessage
    {
        #region Properties

        /// <summary>
        /// Fix taken at
        /// </summary>
        public TimeSpan LastUpdateTime { get; set; }

		public double Latitude { get; set; }

        public double Longitude { get; set; }

        public GpsFixQuality FixQuality { get; set; }

        public int NumberOfSatellites { get; set; }

        /// <summary>
        /// Horizontal dilution of position
        /// </summary>
        public double Hdop { get; set; }

        /// <summary>
        /// Altitude, Meters, above mean sea level
        /// </summary>
        public double Altitude { get; set; }

        /// <summary>
        /// Altitude units ('M' for Meters)
        /// </summary>
        public string AltitudeUnits { get; set; }

        /// <summary>
        /// Height of geoid (mean sea level) above WGS84
        /// </summary>
        public double HeightOfGeoid { get; set; }

        /// <summary>
        /// Time in seconds since last DGPS update
        /// </summary>
        public TimeSpan TimeSpanSinceDgpsUpdate { get; set; }

        /// <summary>
        /// DGPS station ID number
        /// </summary>
        public int DgpsStationId { get; set; }

        #endregion
        
        public GpggaMessage()
        {
            
        }

        public override void Parse(string[] messageParts)
        {
            throw new System.NotImplementedException();
        }
    }
}
