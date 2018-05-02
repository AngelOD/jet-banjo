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
    public class TemperatureData : SensorObject
    {
        /// <summary>
        /// Returns the latest temperature data for the subscribed room.
        /// </summary>
        /// <returns>Temperature data object</returns>
        public static async Task<TemperatureData> Get()
        {
            string room = DataStore.GetValue(Keys.Room);
            return await Get<TemperatureData>(room, SensorType.Temperature);
        }

        /// <summary>
        /// Returns the latest temperature data fora given room.
        /// </summary>
        /// <param name="roomId">The roomId of the room</param>
        /// <returns>Temperature data object</returns>
        public static async Task<TemperatureData> Get(string roomId)
        {
            return await Get<TemperatureData>(roomId, SensorType.Temperature);
        }

        /// <summary>
        /// Updates the current object with the latest data
        /// </summary>
        public async void Update()
        {
            await Update<TemperatureData>(SensorType.Temperature);
        }
    }
}
