using System;
using System.Globalization;
using Ghostware.NMEAParser;
using Ghostware.NMEAParser.Enums;
using Ghostware.NMEAParser.Extensions;
using Ghostware.NMEAParser.NMEAMessages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ghostware.NMEAParserTests
{
    [TestClass]
    public class NmeaParserTests
    {
        private const string GgaMessage1 =
            "$GPGGA,091317.80,5037.0968,N,00534.6232,E,9,07,1.4,73.65,M,46.60,M,05,0136*50";

        private const string RmcMessage1 =
            "$GPRMC,091317.75,A,5037.0967674,N,00534.6232070,E,0.019,215.1,220816,0.0,E,D*33";

        private const string RmcMessage2 = "$GPRMC,153007,A,5050.10288,N,00419.91808,E,000.1,078.9,100217,,,A*75";
        private const string VtgMessage1 = "$GPVTG,054.7,T,034.4,M,005.5,N,010.2,K*48";
        private const string VtgMessage2 = "$GPVTG,141.92,T,,M,0.89,N,1.64,K,A*30";
        private const string GsaMessage1 = "$GPGSA,A,3,04,05,,09,12,,,24,,,,,2.5,1.3,2.1*39";
        private const string GsaMessage2 = "$GPGSA,A,3,08,11,27,01,22,19,32,,,,,,1.55,1.26,0.91*0B";

        //"$GPGGA,091317.80,5037.0968,N,00534.6232,E,9,07,1.4,73.65,M,46.60,M,05,0136*50"
        [TestMethod]
        public void GgaMessageTest1()
        {
            var parser = new NmeaParser();
            var result = parser.Parse(GgaMessage1);

            Assert.IsInstanceOfType(result, typeof(GpggaMessage));
            var message = (GpggaMessage) result;
            Assert.AreEqual("091317.80".ToTimeSpan(), message.FixTime);
            Assert.AreEqual("5037.0968".ToCoordinates("N", CoordinateType.Latitude), message.Latitude);
            Assert.AreEqual("00534.6232".ToCoordinates("E", CoordinateType.Longitude), message.Longitude);
            Assert.AreEqual(9, (int) message.FixQuality);
            Assert.AreEqual(7, message.NumberOfSatellites);
            Assert.AreEqual(1.4f, message.Hdop);
            Assert.AreEqual(73.65f, message.Altitude);
            Assert.AreEqual("M", message.AltitudeUnits);
            Assert.AreEqual(46.60f, message.HeightOfGeoId);
            Assert.AreEqual("M", message.HeightOfGeoIdUnits);
            Assert.AreEqual(5, message.TimeSpanSinceDgpsUpdate);
            Assert.AreEqual(136, message.DgpsStationId);
        }

        //"$GPRMC,091317.75,A,5037.0967674,N,00534.6232070,E,0.019,215.1,220816,0.0,E,D*33"
        [TestMethod]
        public void RmcMessageTest1()
        {
            var parser = new NmeaParser();
            var result = parser.Parse(RmcMessage1);

            Assert.IsInstanceOfType(result, typeof(GprmcMessage));
            var message = (GprmcMessage) result;
            Assert.AreEqual("091317.75".ToTimeSpan(), message.FixTime);
            Assert.AreEqual(true, message.IsActive);
            Assert.AreEqual("5037.0967674".ToCoordinates("N", CoordinateType.Latitude), message.Latitude);
            Assert.AreEqual("00534.6232070".ToCoordinates("E", CoordinateType.Longitude), message.Longitude);
            Assert.AreEqual(0.019f, message.Speed);
            Assert.AreEqual(215.1f, message.Course);
            Assert.AreEqual(DateTime.ParseExact("220816", "ddMMyy", CultureInfo.InvariantCulture), message.UpdateDate);
            Assert.AreEqual(0.0f, message.MagneticVariation);
        }

        //"$GPRMC,153007,A,5050.10288,N,00419.91808,E,000.1,078.9,100217,,,A*75"
        [TestMethod]
        public void RmcMessageTest2()
        {
            var parser = new NmeaParser();
            var result = parser.Parse(RmcMessage2);

            Assert.IsInstanceOfType(result, typeof(GprmcMessage));
            var message = (GprmcMessage) result;
            Assert.AreEqual("153007".ToTimeSpan(), message.FixTime);
            Assert.AreEqual(true, message.IsActive);
            Assert.AreEqual("5050.10288".ToCoordinates("N", CoordinateType.Latitude), message.Latitude);
            Assert.AreEqual("00419.91808".ToCoordinates("E", CoordinateType.Longitude), message.Longitude);
            Assert.AreEqual(000.1f, message.Speed);
            Assert.AreEqual(078.9f, message.Course);
            Assert.AreEqual(DateTime.ParseExact("100217", "ddMMyy", CultureInfo.InvariantCulture), message.UpdateDate);
            Assert.AreEqual(float.NaN, message.MagneticVariation);
        }

        //"$GPVTG,054.7,T,034.4,M,005.5,N,010.2,K*48"
        [TestMethod]
        public void VtgMessageTest1()
        {
            var parser = new NmeaParser();
            var result = parser.Parse(VtgMessage1);

            Assert.IsInstanceOfType(result, typeof(GpvtgMessage));
            var message = (GpvtgMessage) result;
            Assert.AreEqual(054.7f, message.TrackDegrees);
            Assert.AreEqual(034.4f, message.MagneticTrack);
            Assert.AreEqual(005.5f, message.GroundSpeetKnots);
            Assert.AreEqual(010.2f, message.GroundSpeed);
        }

        //"$GPVTG,141.92,T,,M,0.89,N,1.64,K,A*30"
        [TestMethod]
        public void VtgMessageTest2()
        {
            var parser = new NmeaParser();
            var result = parser.Parse(VtgMessage2);

            Assert.IsInstanceOfType(result, typeof(GpvtgMessage));
            var message = (GpvtgMessage) result;
            Assert.AreEqual(141.92f, message.TrackDegrees);
            Assert.AreEqual(float.NaN, message.MagneticTrack);
            Assert.AreEqual(0.89f, message.GroundSpeetKnots);
            Assert.AreEqual(1.64f, message.GroundSpeed);
        }

        //"$GPGSA,A,3,04,05,,09,12,,,24,,,,,2.5,1.3,2.1*39"
        [TestMethod]
        public void GsaMessageTest1()
        {
            var parser = new NmeaParser();
            var result = parser.Parse(GsaMessage1);

            Assert.IsInstanceOfType(result, typeof(GpgsaMessage));
            var message = (GpgsaMessage) result;
            Assert.AreEqual(true, message.GpsStatusAuto);
            Assert.AreEqual(3, (int)message.SatelliteFix);
            Assert.AreEqual("04,05,,09,12,,,24,,,,,", message.Pnrs);
            Assert.AreEqual(2.5f, message.Pdop);
            Assert.AreEqual(1.3f, message.Hdop);
            Assert.AreEqual(2.1f, message.Vdop);
        }
    }
}