using JetBanjo.Utils.Data;

namespace JetBanjo.Utils
{
	public static class Classifier
	{
        /// <summary>
        /// Classification. Reads a value and a range, and determine where the values lies within the range.
        /// </summary>
        /// <param name="inputVal"></param>
        /// <param name="ranges"></param>
        /// <returns></returns>
        public static int Classify(double inputVal, DataRange ranges)
        {
            if (inputVal < ranges.minimum)
                return 1;
            else if (inputVal < ranges.lower)
                return 2;
            else if (inputVal < ranges.higher)
                return 3;
            else if (inputVal < ranges.maximum)
                return 4;
            else if (inputVal >= ranges.maximum)
                return 5;
            else
                return -1;
        }
    }
}