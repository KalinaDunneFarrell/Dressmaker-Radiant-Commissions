using RadiantCommission.Utilities;
using System;
using System.Collections.Generic;

namespace RadiantCommission.Creators
{
    internal static class QuestRequirementCreators
    {
        // Passing min/max so I could maybe add it to a settings config later

        internal static List<QuestRequirement> GetQuestRequirements()
        {
            // -- Fabric : Get # of fabrics and create a requirement for each
            MinMax fabricMM = new MinMax(0, 3);

        }



        internal static QuestRequirement GetAccessoryRequirement(MinMax variety, MinMax count, MinMax length)
        {
            AccessoryType type = (AccessoryType)Utils.GetRandomScriptableEnumFromArray(AccessoryType.AllAccessoryTypes);

            // If adding (lace) trim, create a TrimLengthRequirement
            if (type == AccessoryType.Trim || type == AccessoryType.Lace)
                return new TrimLengthRequirement()
                {
                    requiredType = type,
                    minimumLengthCm = Utils.GetRandom10Number(length)
                };

            // Not a trim, create an AccessoryCountRequirement
            return new AccessoryCountRequirement()
            {
                requiredType = type,
                minimumCount = Utils.GetRandomNumber(count)
            };
        }


        internal static List<QuestRequirement> GetFabricRequirements(MinMax typesMM)
        {
            List<QuestRequirement> requirements = new List<QuestRequirement>();

            // Get fabric types
            List<FabricType> fabricTypes = new List<FabricType>();
            for (int i = typesMM.Min; i <= typesMM.Max; i++)
            {
                FabricType type = (FabricType)Utils.GetRandomScriptableEnumFromArray(FabricType.AllFabricTypes);
                if (!fabricTypes.Contains(type))
                    fabricTypes.Add(type);
            }

            //FabricTypeRequirement         // simple check
            //FabricCompositionRequirement  // needs x points
            //FabricVarietyRequirement      // 

            return requirements;
        }

        internal static List<QuestRequirement> GetColorRequirements(MinMax coloursMM)
        {
            List<QuestRequirement> requirements = new List<QuestRequirement>();

            // Get colour types
            List<ColorType> colorTypes = new List<ColorType>();
            for (int i = coloursMM.Min; i <= coloursMM.Max; i++)
            {
                ColorType type = (ColorType)Utils.GetRandomNumber(0, Enum.GetNames(typeof(ColorType)).Length);
                if (!colorTypes.Contains(type))
                    colorTypes.Add(type);
            }

            //ColorCompositionRequirement
            //ColorTypeRequirement
            //ColorVarietyRequirement

            return requirements;
        }


        /// <summary>
        /// Create a <see cref="QualityRequirement"/> at a random threshold
        /// </summary>
        internal static QualityRequirement GetQualityRequirement(MinMax mm)
        {
            return new QualityRequirement()
            {
                comparison = Utils.GetRandomComparisonType(10),
                threshold = Utils.GetRandom10Number(mm)
            };
        }

        /// <summary>
        /// Create a new <see cref="TagScoreRequirement"/> for a
        /// random <see cref="ItemTag"/>
        /// </summary>
        /// <remarks>min/max parameters are for the target score</remarks>
        internal static TagScoreRequirement GetTagScoreRequirement(MinMax mm)
        {
            return new TagScoreRequirement()
            {
                comparisonType = Utils.GetRandomComparisonType(),
                tag = (ItemTag)Utils.GetRandomScriptableEnumFromArray(ItemTag.AllItemTags),
                targetScore = Utils.GetRandom10Number(mm)
            };
        }

        /// <summary>
        /// Create a new <see cref="SpecificGarmentRequirement"/> for
        /// a random <see cref="GarmentComponent"/>
        /// </summary>
        internal static SpecificGarmentRequirement GetSpecificGarmentRequirement()
        {
            return new SpecificGarmentRequirement()
            {
                requiredGarment = (GarmentComponent)Utils.GetRandomScriptableEnumFromArray(GarmentComponent.AllGarmentComponents)
            };
        }

    }
}
