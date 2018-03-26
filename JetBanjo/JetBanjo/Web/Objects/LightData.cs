using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JetBanjo.Web.Objects
{
    public class LightData
    {
        [JsonProperty(PropertyName = "value")]
        public int Lux { get; set; }

        //ToDo Finish implmentation when the web handler and backend is more finished
        /// <summary>
        /// Returns the latest light data
        /// </summary>
        /// <returns>Light data object</returns>
        public static async Task<LightData> Get()
        {
            return new LightData();
        }

        /// <summary>
        /// Updates the current object with the latest data
        /// </summary>
        public async void Update()
        {
            LightData temp = await Get();
            Lux = temp.Lux;
            temp = null;
        }

    }
}
