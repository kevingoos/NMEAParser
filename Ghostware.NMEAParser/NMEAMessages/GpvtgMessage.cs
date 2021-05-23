using System;
using Ghostware.NMEAParser.Extensions;
using Ghostware.NMEAParser.NMEAMessages.Base;

namespace Ghostware.NMEAParser.NMEAMessages
{
    public class GpvtgMessage : NmeaMessage
    {
        #region Description

        //      $GPVTG,054.7,T,034.4,M,005.5,N,010.2,K*48

        //      where:
        //          VTG Track made good and ground speed
        //          054.7,T True track made good(degrees)
        //          034.4,M Magnetic track made good
        //          005.5,N Ground speed, knots
        //          010.2,K Ground speed, Kilometers per hour
        //          *48          Checksum

        #endregion

        #region Properties

        /// <summary>
        /// True track made good(degrees)
        /// </summary>
        public float TrackDegrees { get; set; }

        /// <summary>
        /// Magnetic track made good
        /// </summary>
        public float MagneticTrack { get; set; }

        /// <summary>
        /// Ground speed, knots
        /// </summary>
        public float GroundSpeetKnots { get; set; }

        /// <summary>
        /// Ground speed, Kilometers per hour
        /// </summary>
        public float GroundSpeed { get; set; }

        #endregion

        #region Message parsing

        public override void Parse(string[] messageParts)
        {
            //$GPVTG,054.7,T,034.4,M,005.5,N,010.2,K * 48
            if (messageParts == null || messageParts.Length < 9)
            {
                throw new ArgumentException("Invalid GPVTG message");
            }
            TrackDegrees = messageParts[1].ToFloat();
            MagneticTrack = messageParts[3].ToFloat();
            GroundSpeetKnots = messageParts[5].ToFloat();
            GroundSpeed = messageParts[7].ToFloat();
        }

        #endregion

        public override string ToString()
        {
            return $"Speed {GroundSpeed} - Track level {TrackDegrees}";
        }
    }
}
