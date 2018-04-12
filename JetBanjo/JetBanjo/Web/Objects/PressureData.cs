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
    public class PressureData : SensorObject
    {
        /// <summary>
        /// Returns the latest pressure data for the subscribed room.
        /// </summary>
        /// <returns>Pressure data object</returns>
        public static async Task<PressureData> Get()
        {
            string room = DataStore.GetValue(DataStore.Keys.Room);
            return await Get<PressureData>(room, SensorType.Pressure);
        }

        /// <summary>
        /// Returns the latest pressure data fora given room.
        /// </summary>
        /// <param name="roomId">The roomId of the room</param>
        /// <returns>Pressure data object</returns>
        public static async Task<PressureData> Get(string roomId)
        {
            return await Get<PressureData>(roomId, SensorType.Pressure);
        }

        /// <summary>
        /// Updates the current object with the latest data
        /// </summary>
        public async void Update()
        {
            await Update<PressureData>(SensorType.Pressure);
        }
    }
}
