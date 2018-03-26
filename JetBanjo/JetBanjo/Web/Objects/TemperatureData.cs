using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JetBanjo.Web.Objects
{
    public class TemperatureData
    {

        [JsonProperty(PropertyName = "value")]
        public double Temperature { get; set; }

        //ToDo Finish implmentation when the web handler and backend is more finished
        /// <summary>
        /// Returns the latest temperature data
        /// </summary>
        /// <returns>Temperature data object</returns>
        public static async Task<TemperatureData> Get()
        {
            return new TemperatureData();
        }

        /// <summary>
        /// Updates the current object with the latest data
        /// </summary>
        public async void Update()
        {
            TemperatureData temp = await Get();
            Temperature = temp.Temperature;
            temp = null;
        }
    }
}
