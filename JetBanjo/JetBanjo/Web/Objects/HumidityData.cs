using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JetBanjo.Web.Objects
{
    public class HumidityData
    {
        [JsonProperty(PropertyName = "value")]
        public double Humidity { get; set; }

        //ToDo Finish implmentation when the web handler and backend is more finished
        /// <summary>
        /// Returns the latest humidityData data
        /// </summary>
        /// <returns>Humidity data object</returns>
        public static async Task<HumidityData> Get()
        {
            return new HumidityData();
        }

        /// <summary>
        /// Updates the current object with the latest data
        /// </summary>
        public async void Update()
        {
            HumidityData temp = await Get();
            Humidity = temp.Humidity;
            temp = null;
        }
    }
}
