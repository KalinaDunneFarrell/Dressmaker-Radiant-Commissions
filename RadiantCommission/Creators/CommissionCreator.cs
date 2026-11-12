using Framework;
using System.Collections.Generic;

namespace RadiantCommission.Creators
{
    internal class CommissionCreator
    {
        private readonly BepInEx.Logging.ManualLogSource _logger;

        internal CommissionCreator(BepInEx.Logging.ManualLogSource logger)
        {
            _logger = logger;
        }

        internal QuestDefinition CreateCommission()
        {
            QuestDefinition quest = ScriptableEnum.CreateRuntimeValue<QuestDefinition>("RadiantCommission");

            quest.budget = Utils.GetRandomNumber(3, 7) * 100;
            quest.questGiverCharacter = CharacterDefinition.Blank;


            List<FabricType> types = new List<FabricType>();



            /* TODO
             * completionRequirements (List QuestRequirement)
             * requirements (List StoryletRequirement) : set null?
                * GetFailedReq uses this, not completion
             * PrettyName (string) : has no set, how to create?
             * Quest Tags - from QuestRequirement
             */

            return quest;
        }

        // ----- ----- ----- Requirement Creators

    }
}
