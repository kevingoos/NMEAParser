using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Ghostware.NMEAParser.Enums;

namespace Ghostware.NMEAParser.Extensions
{
    public static class StringExtensions
    {
        private const string Pattern = @"(\d{2})(\d{2})(\d{2})";

        public static TimeSpan ToTimeSpan(this string inputString)
        {
            var regexMatch = Regex.Match(inputString, Pattern);
            return regexMatch.Groups.Count == 0 ? TimeSpan.Zero : new TimeSpan(int.Parse(regexMatch.Groups[0].Value), int.Parse(regexMatch.Groups[1].Value), int.Parse(regexMatch.Groups[2].Value));
        }

        public static double ToCoordinates(this string inputString, string cardinalDirection, CoordinateType coordinateType)
        {
            if (string.IsNullOrEmpty(inputString)) return 0.0d;

            var degreeCharacters = coordinateType == CoordinateType.Latitude ? 2 : 3;

            var degree = inputString.Substring(0, degreeCharacters).ToDouble();
            degree += inputString.Substring(degreeCharacters).ToDouble() / 60;

            if (!double.IsNaN(degree) && (cardinalDirection == "S" || cardinalDirection == "W"))
            {
                degree *= -1;
            }
            return degree;
        }

        public static int ToInteger(this string inputString)
        {
            return !string.IsNullOrEmpty(inputString) ? int.Parse(inputString, CultureInfo.InvariantCulture) : 0;
        }

        public static double ToDouble(this string inputString)
        {
            return !string.IsNullOrEmpty(inputString) ? double.Parse(inputString, CultureInfo.InvariantCulture) : double.NaN;
        }
    }
}
