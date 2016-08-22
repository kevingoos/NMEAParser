using System;
using System.IO.Ports;
using System.Threading;
using Ghostware.NMEAParser;
using Ghostware.NMEAParser.Exceptions;

namespace Ghostware.NMEASerialTestConsole
{
    public class SerialPortService
    {
        private readonly SerialPort _port = new SerialPort("COM8", 9600, Parity.None, 8, StopBits.One);
        private readonly NmeaParser _parser = new NmeaParser();

        public void StartSerialPort()
        {
            // Attach a method to be called when there
            // is data waiting in the port's buffer
            _port.DataReceived += port_DataReceived;

            // Begin communications
            _port.Open();

            // Enter an application loop to keep this thread alive
            while (_port.IsOpen)
            {
                Console.WriteLine("Running...");
                Thread.Sleep(1000);
            }
        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                var result = _parser.Parse(_port.ReadExisting());
                Console.WriteLine($"Result: {result}");
            }
            catch (UnknownTypeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NotNmeaException nmeaEx)
            {
                Console.WriteLine(nmeaEx.Message);
            }
        }
    }
}
