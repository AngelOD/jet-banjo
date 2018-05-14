using JetBanjo.Utils.Data;
using JetBanjo.Web.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JetBanjo.Interfaces.Logic
{
    public interface IScorePageLogic
    {
        /// <summary>
        /// Asynchronously returns a list of ScoreViewObjs to display in the ListView
        /// </summary>
        /// <param name="scoreData">List of scoredata for a room</param>
        /// <returns>ScoreViewObjs to show in listview</returns>
        List<ScoreViewObj> GetScore(List<ScoreData> scoreData);
    }
}
