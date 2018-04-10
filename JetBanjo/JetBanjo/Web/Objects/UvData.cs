using JetBanjo.Resx;
using JetBanjo.Utils;
using JetBanjo.Utils.DependencyService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static JetBanjo.Web.WebHandler;

namespace JetBanjo.Web.Objects
{
    public class UVData : SensorObject
    {
        /// <summary>
        /// Returns the latest UV data for the subscribed room.
        /// </summary>
        /// <returns>UV data object</returns>
        public static async Task<UVData> Get()
        {
            string room = DataStore.GetValue(DataStore.Keys.Room);
            return await Get<UVData>(room, SensorType.UV);
        }

        /// <summary>
        /// Returns the latest UV data fora given room.
        /// </summary>
        /// <param name="roomId">The roomId of the room</param>
        /// <returns>UV data object</returns>
        public static async Task<UVData> Get(string roomId)
        {
            return await Get<UVData>(roomId, SensorType.UV);
        }

        /// <summary>
        /// Updates the current object with the latest data
        /// </summary>
        public async void Update()
        {
            await Update<UVData>(SensorType.UV);
        }

    }
}
