using JetBanjo.Interfaces.Logic;
using JetBanjo.Pages;
using JetBanjo.Utils;
using JetBanjo.Utils.Data;
using JetBanjo.Web.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JetBanjo.Logic.Pages
{
    public class ScorePageLogic : IScorePageLogic
    {
        private ScoringPage scoringPage;



        public ScorePageLogic(ScoringPage page)
        {
            scoringPage = page;
        }

        private string GetMessage(double data, string type)
        {
            string returnString = "";

            if(data >= Constants.SCORE_RANGES.maximum)
            {
                returnString = "Perfect " + type + "!";
            }
            else if (data >= Constants.SCORE_RANGES.higher)
            {
                returnString = "Acceptable " + type + "!";
            }
            else if (data >= Constants.SCORE_RANGES.lower)
            {
                returnString = "Bad " + type + "!";
            }
            else if (data >= Constants.SCORE_RANGES.minimum)
            {
                returnString = "Terrible " + type + "!";
            }

            return returnString;
        }


        public async Task<List<ScoreViewObj>> GetScore(List<ScoreData> scoreData)
        {
            //Start the following as a task such that it can execute asynchronously
            Task<List<ScoreViewObj>> t = Task.Run<List<ScoreViewObj>>(() =>
            {
                List<ScoreViewObj> listViewSource = new List<ScoreViewObj>();
                
                foreach(ScoreData data in scoreData)
                {
                    List<ScoreCausation> causes = new List<ScoreCausation>
                    {
                        new ScoreCausation("Air Quality", data.IAQScore , GetMessage(data.IAQScore, "Air Quality")),
                        new ScoreCausation("Temperature", data.TempHumScore, GetMessage(data.IAQScore, "Temperature")),
                        new ScoreCausation("Sound", data.SoundScore, GetMessage(data.IAQScore, "Sound")),
                        new ScoreCausation("Light", data.VisualScore, GetMessage(data.IAQScore, "Light"))
                    };

                    double overallScore = data.IAQScore + data.TempHumScore + data.SoundScore + data.VisualScore;
                    listViewSource.Add(new ScoreViewObj(causes, (int)overallScore));

                }

                return listViewSource;
            });
            return await t; //Asynchronously return the result of t, namely the list of score events.
        }
    }
}
