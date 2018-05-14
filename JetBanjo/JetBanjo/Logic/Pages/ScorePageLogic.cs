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
        /// <summary>
        /// Returns a customized string explaining the state of a single IEQ parameter.
        /// </summary>
        /// <param name="data">Value (1-100) for given IEQ factor</param>
        /// <param name="type">The type of IEQ factor</param>
        /// <returns>Customized string explaining state of IEQ paramter</returns>
        private string GetMessage(double data, string type)
        {
            string returnString = ""; //String returned

            //Use the classifier to determine the state of the given IEQ factor
            int classification = Classifier.Classify(data, Constants.SCORE_RANGES);

            //Constructs the returnString based on the classification
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

        /// <summary>
        /// Convert database time (Unix in nanoseconds) to DateTime
        /// </summary>
        /// <param name="unixTime"></param>
        /// <returns>DateTime obj for time</returns>
        private DateTime FromUnixTime(long unixTime)
        {
            //note: input is in nanoseconds
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime / Constants.NANOSECONDS_PER_SECOND);
        }

        /// <summary>
        /// Asynchronously returns a list of ScoreViewObjs to display in the ListView
        /// </summary>
        /// <param name="scoreData"></param>
        /// <returns>ScoreViewObjs to show in listview</returns>
        public List<ScoreViewObj> GetScore(List<ScoreData> scoreData)
        {
            List<ScoreViewObj> listViewSource = new List<ScoreViewObj>();

            //For each data obj we determine the time, causes for the score, and the total score.
            foreach (ScoreData data in scoreData)
            {
                DateTime time = FromUnixTime(data.EndTime); //converts input unix time to datetime.

                //Creates a list of causations. Each elements corresponds to one IEQ factor.
                List<ScoreCausation> causes = new List<ScoreCausation>
                    {
                        new ScoreCausation(AppResources.air_qual, data.IAQScore , GetMessage(data.IAQScore, AppResources.air_qual)),
                        new ScoreCausation(AppResources.temp_hum, data.TempHumScore, GetMessage(data.TempHumScore, AppResources.temp_hum)),
                        new ScoreCausation(AppResources.sound, data.SoundScore, GetMessage(data.SoundScore, AppResources.sound)),
                        new ScoreCausation(AppResources.visual, data.VisualScore, GetMessage(data.VisualScore, AppResources.visual))
                    };

                double overallScore = data.TotalScore;
                listViewSource.Add(new ScoreViewObj(causes, (int)overallScore, time)); //add element to return list

            }

            return listViewSource;
        }
    }
}
