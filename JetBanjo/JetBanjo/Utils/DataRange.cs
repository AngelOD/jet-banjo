using System;
using System.Collections.Generic;
using System.Text;

namespace JetBanjo.Utils
{
    public class DataRange
    {
        public DataRange(double min, double low, double high, double max)
        {
            minimum = min;
            lower = low;
            higher = high;
            maximum = max;
        }

        public double minimum { get; set; }
        public double lower { get; set; }
        public double higher { get; set; }
        public double maximum { get; set; }
    }
}
