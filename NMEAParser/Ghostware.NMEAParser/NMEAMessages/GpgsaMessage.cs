using System;
using Ghostware.NMEAParser.Enums;
using Ghostware.NMEAParser.Extensions;
using Ghostware.NMEAParser.NMEAMessages.Base;

namespace Ghostware.NMEAParser.NMEAMessages
{
    public class GpgsaMessage : NmeaMessage
    {
        #region Description

        //      $GPGSA,A,3,04,05,,09,12,,,24,,,,,2.5,1.3,2.1*39

        //          Where:
        //              GSA Satellite status
        //              A        Auto selection of 2D or 3D fix(M = manual)
        //              3        3D fix - values include:   1 = no fix
        //                                                  2 = 2D fix
        //                                                  3 = 3D fix
        //              04,05... PRNs of satellites used for fix(space for 12)
        //              2.5      PDOP(dilution of precision)
        //              1.3      Horizontal dilution of precision(HDOP)
        //              2.1      Vertical dilution of precision(VDOP)
        //              *39      the checksum data, always begins with*

        #endregion

        #region Properties

        /// <summary>
        /// Auto selection of 2D or 3D fix(M = manual)
        /// </summary>
        public bool GpsStatusAuto { get; set; }

        /// <summary>
        /// 3D fix - values include:    1 = no fix
        //                              2 = 2D fix
        //                              3 = 3D fix
        /// </summary>
        public SatelliteFixType SatelliteFix { get; set; }

        /// <summary>
        /// PRNs of satellites used for fix(space for 12)
        /// </summary>
        public string Pnrs { get; set; }

        /// <summary>
        /// PDOP(dilution of precision)
        /// </summary>
        public float Pdop { get; set; }


        /// <summary>
        /// Horizontal dilution of precision(HDOP)
        /// </summary>
        public float Hdop { get; set; }

        /// <summary>
        /// Vertical dilution of precision(VDOP)
        /// </summary>
        public float Vdop { get; set; }

        #endregion

        #region Message parsing

        public override void Parse(string[] messageParts)
        {
            if (messageParts == null || messageParts.Length < 9)
            {
                throw new ArgumentException("Invalid GPGSA message");
            }
            GpsStatusAuto = messageParts[1].ToBoolean("A");
            SatelliteFix = (SatelliteFixType)Enum.Parse(typeof(SatelliteFixType), messageParts[2]);
            for (var i = 0 + 3; i < 12 + 3; i++)
            {
                Pnrs += $"{messageParts[i]},";
            }
            
            Pdop = messageParts[15].ToFloat();
            Hdop = messageParts[16].ToFloat();
            Vdop = messageParts[17].ToFloat();
        }

        #endregion

        public override string ToString()
        {
            return $"Status {GpsStatusAuto} - Satellite Fix Type {SatelliteFix}";
        }
    }
}
