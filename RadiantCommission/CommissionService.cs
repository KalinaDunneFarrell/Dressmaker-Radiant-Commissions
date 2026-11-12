using RadiantCommission.Creators;

namespace RadiantCommission
{
    /// <summary>
    /// Directs all functionality withing the RadiantCommission project
    /// </summary>
    public class CommissionService
    {
        private BepInEx.Logging.ManualLogSource _logger;
        private bool _radientCommissionIsInRegistry;
        private QuestDefinition _radientCommissionInRegistry;

        public CommissionService(BepInEx.Logging.ManualLogSource logger)
        {
            _logger = logger;
        }


        /// <summary>
        /// Get a new random Commission
        /// </summary>
        public QuestDefinition GetCommission()
        {
            // prevent adding multiple to ScriptableEnum registry
            if (!_radientCommissionIsInRegistry)
            {
                _logger.LogInfo("GetCommission() triggered");
                CommissionCreator comHelper = new CommissionCreator(_logger);

                _radientCommissionInRegistry = comHelper.CreateCommission();
                _radientCommissionIsInRegistry = true;
            }
            return _radientCommissionInRegistry;
        }
    }
}
