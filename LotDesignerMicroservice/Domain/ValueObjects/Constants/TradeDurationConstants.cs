namespace LotDesignerMicroservice.Domain.ValueObjects.Constants
{
    /// <summary>
    /// Static class for TradeDuration value object constants
    /// </summary>
    public static class TradeDurationConstants
    {
        /// <summary>
        /// TradeDuration's min duration value
        /// </summary>
        public static readonly TimeSpan MIN_DURATION = new(3, 0, 0);

        /// <summary>
        /// TradeDuration's max duration value
        /// </summary>
        public static readonly TimeSpan MAX_DURATION = new(90, 0, 0, 0);
    }
}
