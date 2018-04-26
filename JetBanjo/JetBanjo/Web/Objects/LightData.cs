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
    public class LightData : SensorObject
    {
        /// <summary>
        /// Returns the latest light data for the subscribed room.
        /// </summary>
        /// <returns>Light data object</returns>
        public static async Task<LightData> Get()
        {
            string room = DataStore.GetValue(Keys.Room);
            return await Get<LightData>(room, SensorType.Light);
        }

        /// <summary>
        /// Returns the latest light data fora given room.
        /// </summary>
        /// <param name="roomId">The roomId of the room</param>
        /// <returns>Light data object</returns>
        public static async Task<LightData> Get(string roomId)
        {
            return await Get<LightData>(roomId, SensorType.Light);
        }

        /// <summary>
        /// Updates the current object with the latest data
        /// </summary>
        public async void Update()
        {
            await Update<LightData>(SensorType.Light);
        }
    }
}
