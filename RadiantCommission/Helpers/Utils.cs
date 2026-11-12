using System;

namespace RadiantCommission.Helpers
{
    public static class Utils
    {

        /// <summary>
        /// Generate a number from min to the max
        /// </summary>
        public static int GenerateRandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max + 1);
        }

        /// <summary>
        /// Generate a number from min to the max, always a factor of 10
        /// </summary>
        public static int GenerateRandom10Number(int min, int max)
        {
            Random random = new Random();
            int smallMin = (int)(min / 10);
            int smallMax = (int)(max / 10) + 1;
            return random.Next(smallMin, smallMax) * 10;
        }
    }
}
