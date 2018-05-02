using JetBanjo.Interfaces.Logic;
using JetBanjo.Pages;
using JetBanjo.Utils.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace JetBanjo.Logic.Pages
{
    public class ScorePageLogic : IScorePageLogic
    {
        //Used to store the current list of score objects for the view.
        public List<ScoreViewObj> currentScoreList = new List<ScoreViewObj>();

        private ScoringPage scoringPage;

        public ScorePageLogic(ScoringPage page)
        {
            scoringPage = page;
        }  

        


        private void AddDataPoint(List<ScoreCausation> causes, int scoreChange)
        {
            ScoreViewObj temp = new ScoreViewObj(causes, scoreChange);
            currentScoreList.Add(temp);
            scoringPage.UpdateScoreList(currentScoreList);
        }
    }
}
