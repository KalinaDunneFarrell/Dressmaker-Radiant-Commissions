namespace RadiantCommission.Utilities
{
    /// <summary>
    /// Helper class to contain a minimum and maximum value for something
    /// </summary>
    public class MinMax
    {
        public MinMax(int min, int max)
        {
            Min = min;
            Max = max;
        }

        private int _max;

        /// <summary>
        /// The Minimum value
        /// </summary>
        public int Min;

        /// <summary>
        /// The Maximum value
        /// </summary>
        /// <remarks>Will set to <see cref="Min"/> if setting to less than <see cref="Min"/></remarks>
        public int Max
        {
            get => _max;
            set
            {
                if (value < Min)
                    _max = Min;
                _max = value;
            }
        }
    }
}
