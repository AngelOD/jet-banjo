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
using JetBanjo.Utils.Data;
using static JetBanjo.Utils.Data.DataStoreKeys;

namespace JetBanjo.Web.Objects
{
    public class HumidityData : SensorObject
    {
        /// <summary>
        /// Returns the latest humidity data for the subscribed room.
        /// </summary>
        /// <returns>Humidity data object</returns>
        public static async Task<HumidityData> Get()
        {
            string room = DataStore.GetValue(Keys.Room);
            return await Get<HumidityData>(room, SensorType.Humidity);
        }

        /// <summary>
        /// Returns the latest humidity data fora given room.
        /// </summary>
        /// <param name="roomId">The roomId of the room</param>
        /// <returns>Humidity data object</returns>
        public static async Task<HumidityData> Get(string roomId)
        {
            return await Get<HumidityData>(roomId, SensorType.Humidity);
        }

        /// <summary>
        /// Updates the current object with the latest data
        /// </summary>
        public async void Update()
        {
            await Update<HumidityData>(SensorType.Humidity);
        }
    }
}
