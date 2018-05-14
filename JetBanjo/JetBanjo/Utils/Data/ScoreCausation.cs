using System;
using System.Collections.Generic;
using System.Text;

namespace JetBanjo.Utils.Data
{
    public class ScoreCausation
    {
        public string sensorName { get; set; }
        public double score { get; set; }
        public string message { get; set; } = "No Data";

        public ScoreCausation(string sensor, double scoreChange, string scoreMessage)
        {
            message = scoreMessage;
            sensorName = sensor;
            score = scoreChange;
        }

        public override string ToString()
        {
            return message;
        }
    }
}
