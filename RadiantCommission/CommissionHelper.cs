namespace RadiantCommission
{
    /// <summary>
    /// Directs all functionality withing the RadiantCommission project
    /// </summary>
    public class CommissionHelper
    {
        private BepInEx.Logging.ManualLogSource _logger;

        public CommissionHelper(BepInEx.Logging.ManualLogSource logger)
        {
            _logger = logger;
        }


        /// <summary>
        /// Get a new random Commission
        /// </summary>
        // TODO currently a placeholder just to test UI trigger
        public void GetCommission()
        {
            _logger.LogInfo("GetCommission() triggered");
        }
    }
}
