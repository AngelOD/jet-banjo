using System;
using System.Collections.Generic;
using System.Text;

namespace JetBanjo.Utils.Data
{
    public class ScoreCausation
    {
        public string sensorName { get; set; }
        public int score { get; set; }
        public string message { get; set; }

        public ScoreCausation(string sensor, int scoreChange, string scoreMessage)
        {
            message = scoreMessage;
            sensorName = sensor;
            score = scoreChange;
        }

        public override string ToString()
        {
            return sensorName + " " + message + " " + score;
        }
    }
}
