using JetBanjo.Interfaces.Logic;
using System;
using System.Collections.Generic;
using System.Text;
using JetBanjo.Utils;
using JetBanjo.Utils.Data;
using Xamarin.Forms;
using JetBanjo.Web.Objects;
using System.Threading.Tasks;
using System.Globalization;
using System.Linq;

namespace JetBanjo.Logic.Pages
{
    /// <summary>
    /// Logic used for the LeaderboardPage.
    /// </summary>
    public class LeaderboardPageLogic : ILeaderBoardPageLogic
    {
        /// <summary>
        /// Retrieves rooms and their scores, and returns them in a sorted list.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Room>> GetLeaderboard()
        {
            List<Room> rooms = await Room.GetList();
            List<Room> sortedList = rooms.OrderByDescending(o => o.Score).ToList();
            return sortedList;
        }
    }
}
