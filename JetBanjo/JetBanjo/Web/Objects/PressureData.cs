using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JetBanjo.Web.Objects
{
    public class PressureData
    {
        [JsonProperty(PropertyName = "value")]
        public int Pressure { get; set; }

        //ToDo Finish implmentation when the web handler and backend is more finished
        /// <summary>
        /// Returns the latest pressure data
        /// </summary>
        /// <returns>Pressure data object</returns>
        public static async Task<PressureData> Get()
        {
            return new PressureData();
        }

        /// <summary>
        /// Updates the current object with the latest data
        /// </summary>
        public async void Update()
        {
            PressureData temp = await Get();
            Pressure = temp.Pressure;
            temp = null;
        }
    }
}
