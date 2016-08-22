using System;
using Ghostware.NMEAParser;

namespace Ghostware.NMEAParserTestConsole
{
    internal class Program
    {
        private const string GgaMessage1 = "$GPGGA,091317.80,5037.0968,N,00534.6232,E,9,07,1.4,73.65,M,46.60,M,05,0136*50";
        private const string RmcMessage1 = "$GPRMC,091317.75,A,5037.0967674,N,00534.6232070,E,0.019,215.1,220816,0.0,E,D*33";

        static void Main(string[] args)
        {
            var parser = new NmeaParser();

            Console.WriteLine($"Parsing GPGGA message: {GgaMessage1}");
            var result = parser.Parse(GgaMessage1);
            Console.WriteLine($"Result: {result}");

            Console.WriteLine($"Parsing GPGGA message: {RmcMessage1}");
            result = parser.Parse(RmcMessage1);
            Console.WriteLine($"Result: {result}");

            Console.WriteLine("Press enter to continue...");
            Console.ReadKey();
        }
    }
}
