using Framework;
using System;
using System.Collections.Generic;

namespace RadiantCommission.Utilities
{
    public static class Utils
    {

        /// <summary>
        /// Generate a number from min to the max
        /// </summary>
        public static int GetRandomNumber(MinMax mm)
        {
            Random random = new Random();
            return random.Next(mm.Min, mm.Max + 1);
        }

        /// <summary>
        /// Generate a number from min to the max
        /// </summary>
        public static int GetRandomNumber(int min, int max)
        {
            return GetRandomNumber(new MinMax(min, max));
        }

        /// <summary>
        /// Generate a number from min to the max, always a factor of 10
        /// </summary>
        public static int GetRandom10Number(MinMax mm)
        {
            Random random = new Random();
            int smallMin = (int)(mm.Min / 10);
            int smallMax = (int)(mm.Max / 10) + 1;
            return random.Next(smallMin, smallMax) * 10;
        }

        /// <summary>
        /// Generate a number from min to the max, always a factor of 10
        /// </summary>
        public static int GetRandom10Number(int min, int max)
        {
            return GetRandom10Number(new MinMax(min, max));
        }

        /// <summary>
        /// Get a random <see cref="ComparisonType"/>, usually 'AtLeast'
        /// </summary>
        /// <param name="chance">Higher number means more likely to be 'AtLeast'</param>
        /// <param name="canBeExactly">Can the type be 'Exactly'</param>
        internal static ComparisonType GetRandomComparisonType(int chance = 7, bool canBeExactly = false)
        {
            ComparisonType comparisonType = ComparisonType.AtLeast;

            int random = GetRandomNumber(new MinMax(0, chance));

            if (random == 0)
                comparisonType = ComparisonType.AtMost;
            else if (random == 1)
                comparisonType = ComparisonType.Exactly;

            return comparisonType;
        }

        /// <summary>
        /// Pull out a random element from an array of <see cref="ScriptableEnum"/>s
        /// </summary>
        internal static ScriptableEnum GetRandomScriptableEnumFromArray(ScriptableEnum[] array)
        {
            // subtract 1 from the max since the Random method adds 1
            int maxCount = array.Length - 1;
            return array[GetRandomNumber(0, maxCount)];
        }

        /// <summary>
        /// Get a list of percentages that together will add up to 100%
        /// </summary>
        internal static List<int> GetPercentages(int max)
        {
            if (max < 1 || max > 100)
                throw new ArgumentOutOfRangeException(nameof(max));

            List<int> percentages = new List<int>();
            int remaining = 100;

            for (int i = 0; i < max - 1; i++)
            {
                // Leave at least 1% for each remaining element.
                int percentage = GetRandomNumber(1, remaining - (max - i - 1) + 1);

                percentages.Add(percentage);
                remaining -= percentage;
            }

            percentages.Add(remaining);

            return percentages;
        }
    }
}
