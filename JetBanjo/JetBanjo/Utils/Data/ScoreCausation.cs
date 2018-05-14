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
        public string SensorName { get; set; }
        public double Score { get; set; }
        public string Message { get; set; } = "No Data";

        public ScoreCausation(string sensor, double scoreChange, string scoreMessage)
        {
            Message = scoreMessage;
            SensorName = sensor;
            Score = scoreChange;
        }

        public override string ToString()
        {
            return Message;
        }
    }
}
