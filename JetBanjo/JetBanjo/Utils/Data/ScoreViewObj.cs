using System;
using System.Collections.Generic;
using System.Text;

namespace JetBanjo.Utils.Data
{
    public class ScoreViewObj
    {
        public int scoreChange { get; set; }
        public List<ScoreCausation> causations;
        public DateTime timeStamp;

        public ScoreViewObj(List<ScoreCausation> scoreCausations, int score)
        {
            timeStamp = DateTime.Now;
            causations = scoreCausations;
            scoreChange = score;
        }

        public override string ToString()
        {
            return timeStamp.Hour + ":" + timeStamp.Minute + " " + scoreChange;
        }
    }
}
