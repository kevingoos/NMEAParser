namespace Ghostware.NMEAParser.NMEAMessages.Base
{
    public abstract class NmeaMessage
    {
        public abstract void Parse(string[] messageParts);
    }
}
