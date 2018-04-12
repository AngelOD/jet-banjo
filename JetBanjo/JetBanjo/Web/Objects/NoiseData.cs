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
    public class NoiseData : SensorObject
    {
        /// <summary>
        /// Returns the latest noise data for the subscribed room.
        /// </summary>
        /// <returns>Noise data object</returns>
        public static async Task<NoiseData> Get()
        {
            string room = DataStore.GetValue(DataStore.Keys.Room);
            return await Get<NoiseData>(room, SensorType.Noise);
        }

        /// <summary>
        /// Returns the latest noise data fora given room.
        /// </summary>
        /// <param name="roomId">The roomId of the room</param>
        /// <returns>Noise data object</returns>
        public static async Task<NoiseData> Get(string roomId)
        {
            return await Get<NoiseData>(roomId, SensorType.Noise);
        }

        /// <summary>
        /// Updates the current object with the latest data
        /// </summary>
        public async void Update()
        {
            await Update<NoiseData>(SensorType.Noise);
        }
    }
}
