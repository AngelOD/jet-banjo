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
        Task<List<ScoreViewObj>> GetScore(List<ScoreData> scoreData);
    }
}
