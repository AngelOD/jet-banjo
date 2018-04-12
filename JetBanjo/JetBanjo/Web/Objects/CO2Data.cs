using JetBanjo.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using static JetBanjo.Web.WebHandler;
using Xamarin.Forms;
using JetBanjo.Utils.DependencyService;
using JetBanjo.Resx;

namespace JetBanjo.Web.Objects
{
    public class CO2Data : SensorObject
    {
        /// <summary>
        /// Returns the latest CO2 data for the subscribed room.
        /// </summary>
        /// <returns>CO2 data object</returns>
        public static async Task<CO2Data> Get()
        {
            string room = DataStore.GetValue(DataStore.Keys.Room);
            return await Get<CO2Data>(room, SensorType.CO2);
        }

        /// <summary>
        /// Returns the latest CO2 data fora given room.
        /// </summary>
        /// <param name="roomId">The roomId of the room</param>
        /// <returns>CO2 data object</returns>
        public static async Task<CO2Data> Get(string roomId)
        {
            return await Get<CO2Data>(roomId, SensorType.CO2);
        }

        /// <summary>
        /// Updates the current object with the latest data
        /// </summary>
        public async void Update()
        {
            await Update<CO2Data>(SensorType.CO2);
        }
    }
}
