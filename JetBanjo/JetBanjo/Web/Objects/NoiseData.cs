using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JetBanjo.Web.Objects
{
    public class NoiseData
    {
        [JsonProperty(PropertyName = "value")]
        public int dB { get; set; }

        //ToDo Finish implmentation when the web handler and backend is more finished
        /// <summary>
        /// Returns the latest noise data
        /// </summary>
        /// <returns>Noise data object</returns>
        public static async Task<NoiseData> Get()
        {
            return new NoiseData();
        }

        /// <summary>
        /// Updates the current object with the latest data
        /// </summary>
        public async void Update()
        {
            NoiseData temp = await Get();
            dB = temp.dB;
            temp = null;
        }

    }
}
