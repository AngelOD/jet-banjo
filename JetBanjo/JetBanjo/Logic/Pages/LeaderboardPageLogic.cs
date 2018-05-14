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

namespace JetBanjo.Logic.Pages
{
    /// <summary>
    /// Logic used to pick images to show on the avatar page.
    /// </summary>
    public class LeaderboardPageLogic : ILeaderBoardPageLogic
    {
        public async Task<List<Room>> GetLeaderboard()
        {
            //Start the following as a task such that it can execute asynchronously
            Task<List<Room>> t = Task.Run<List<Room>>(() =>
            {
                List<Room> rooms = new List<Room>();
                

                return rooms;
            });
            return await t; //Asynchronously return the result of t, namely the list of images.
        }

    }
}
