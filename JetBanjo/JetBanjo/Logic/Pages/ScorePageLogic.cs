using JetBanjo.Interfaces.Logic;
using JetBanjo.Pages;
using JetBanjo.Resx;
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

            int classification = Classifier.Classify(data, Constants.SCORE_RANGES);

            switch (classification)
            {
                case 1:
                    returnString = AppResources.terrible + " " + type + "!";
                    break;
                case 2:
                    returnString = AppResources.bad + " " + type + "!";
                    break;
                case 3:
                    returnString = AppResources.acceptable + " " + type + "!";
                    break;
                case 4:
                    returnString = AppResources.good + " " + type + "!";
                    break;
                case 5:
                    returnString = AppResources.perfect + " " + type + "!";
                    break;
                default:
                    break;
            }

            return returnString;
        }

        private DateTime FromUnixTime(long unixTime)
        {
            //note: input is in nanoseconds
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime/1000000000);
        }

        public async Task<List<ScoreViewObj>> GetScore(List<ScoreData> scoreData)
        {
            //Start the following as a task such that it can execute asynchronously
            Task<List<ScoreViewObj>> t = Task.Run<List<ScoreViewObj>>(() =>
            {
                List<ScoreViewObj> listViewSource = new List<ScoreViewObj>();
                
                foreach(ScoreData data in scoreData)
                {
                    DateTime time = FromUnixTime(data.EndTime);

                    List<ScoreCausation> causes = new List<ScoreCausation>
                    {
                        new ScoreCausation(AppResources.air_qual, data.IAQScore , GetMessage(data.IAQScore, AppResources.air_qual)),
                        new ScoreCausation(AppResources.temp_hum, data.TempHumScore, GetMessage(data.TempHumScore, AppResources.temp_hum)),
                        new ScoreCausation(AppResources.sound, data.SoundScore, GetMessage(data.SoundScore, AppResources.sound)),
                        new ScoreCausation(AppResources.visual, data.VisualScore, GetMessage(data.VisualScore, AppResources.visual))
                    };

                    double overallScore = data.TotalScore;
                    listViewSource.Add(new ScoreViewObj(causes, (int)overallScore, time));

                }

                return listViewSource;
            });
            return await t; //Asynchronously return the result of t, namely the list of score events.
        }
    }
}
