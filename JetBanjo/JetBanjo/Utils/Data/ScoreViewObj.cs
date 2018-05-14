using JetBanjo.Resx;
using System;
using System.Collections.Generic;
using System.Text;

namespace JetBanjo.Utils.Data
{
    /// <summary>
    /// Object used to present in score page listView.
    /// </summary>
    public class ScoreViewObj
    {
        public int ScoreChange { get; set; }
        public List<ScoreCausation> causations;
        public DateTime timeStamp;

        public ScoreViewObj(List<ScoreCausation> scoreCausations, int score, DateTime time)
        {
            timeStamp = time;
            causations = scoreCausations;
            ScoreChange = score;
        }

        public override string ToString()
        {
            return AppResources.time + " " + timeStamp.Hour + "            Score: " + ScoreChange;
        }
    }
}
