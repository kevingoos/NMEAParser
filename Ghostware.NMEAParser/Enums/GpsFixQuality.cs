namespace Ghostware.NMEAParser.Enums
{
    public enum GpsFixQuality
    {
        Invalid = 0,
        /// <summary>
        /// GPS fix (SPS)
        /// </summary>
        GpsFix = 1,
        /// <summary>
        /// DGPS fix
        /// </summary>
        DgpsFix = 2,
        /// <summary>
        /// PPS fix
        /// </summary>
        PpsFix = 3,
        /// <summary>
        /// Real Time Kinematic
        /// </summary>
        Rtk = 4,
        /// <summary>
        /// Float RTK
        /// </summary>
        FloatRtk = 5,
        /// <summary>
        /// estimated (dead reckoning) (2.3 feature)
        /// </summary>
        Estimated = 6,
        /// <summary>
        /// Manual input mode
        /// </summary>
        ManualInput = 7,
        /// <summary>
        /// Simulation mode
        /// </summary>
        Simulation = 8
    }
}
