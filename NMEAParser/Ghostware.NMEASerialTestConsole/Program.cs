namespace Ghostware.NMEASerialTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            SerialPortService service = new SerialPortService();
            service.StartSerialPort();
        }
    }
}
