using System;

namespace RadiantCommission
{
    /// <summary>
    /// Directs all functionality withing the RadiantCommission project
    /// </summary>
    public class CommissionService
    {
        private BepInEx.Logging.ManualLogSource _logger;

        public CommissionService(BepInEx.Logging.ManualLogSource logger)
        {
            _logger = logger;
        }


        /// <summary>
        /// Get a new random Commission
        /// </summary>
        public QuestDefinition GetCommission()
        {
            _logger.LogInfo("GetCommission() triggered");

            QuestDefinition quest = new QuestDefinition();
            quest = QuestDefinition.RepeatingQuest; // copy off-rack

            quest.budget = GenerateRandomNumber(3, 7) * 100;

            /* TODO
             * completionRequirements (List QuestRequirement)
             * requirements (List StoryletRequirement) : set null?
                * GetFailedReq uses this, not completion
             * PrettyName (string) : has no set, how to create?
             * Quest Tags - from QuestRequirement
             */

            return quest;
        }


        /// <summary>
        /// Generate a number from min to the max
        /// </summary>
        private int GenerateRandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max + 1);
        }
    }
}
