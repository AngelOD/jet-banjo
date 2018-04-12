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
    public class VOCData : SensorObject
    {

        /// <summary>
        /// Returns the latest VOC data for the subscribed room.
        /// </summary>
        /// <returns>VOC data object</returns>
        public static async Task<VOCData> Get()
        {
            string room = DataStore.GetValue(DataStore.Keys.Room);
            return await Get<VOCData>(room, SensorType.VOC);
        }

        /// <summary>
        /// Returns the latest VOC data fora given room.
        /// </summary>
        /// <param name="roomId">The roomId of the room</param>
        /// <returns>VOC data object</returns>
        public static async Task<VOCData> Get(string roomId)
        {
            return await Get<VOCData>(roomId, SensorType.VOC);
        }

        /// <summary>
        /// Updates the current object with the latest data
        /// </summary>
        public async void Update()
        {
            await Update<VOCData>(SensorType.VOC);
        }
    }
}
