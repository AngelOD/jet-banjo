using System;
using System.Collections.Generic;
using System.Text;

namespace JetBanjo.Utils.Data
{
    public class DataRange
    {
        public DataRange(string type, double min, double low, double high, double max)
        {
            SensorType = type;
            Minimum = min;
            Lower = low;
            Higher = high;
            Maximum = max;
        }

        //Properties for a sensor of a given type
        public string SensorType { get; private set; }
        public double Minimum { get; private set; }
        public double Lower { get; private set; }
        public double Higher { get; private set; }
        public double Maximum { get; private set; }
    }
}
