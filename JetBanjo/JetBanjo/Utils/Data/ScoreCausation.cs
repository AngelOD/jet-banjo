using System;
using System.Collections.Generic;
using System.Text;

namespace JetBanjo.Utils.Data
{
    /// <summary>
    /// Object used in ScoreViewObj to represent the effect of a single IEQ factor.
    /// </summary>
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
