using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JetBanjo.Web.Objects
{
    public class CO2Data
    {

        [JsonProperty(PropertyName = "value")]
        public int CO2 { get; set; }


        //ToDo Finish implmentation when the web handler and backend is more finished
        /// <summary>
        /// Returns the latest CO2 data
        /// </summary>
        /// <returns>CO2 data object</returns>
        public static async Task<CO2Data> Get()
        {
            return new CO2Data();
        }

        /// <summary>
        /// Updates the current object with the latest data
        /// </summary>
        public async void Update()
        {
            CO2Data temp = await Get();
            CO2 = temp.CO2;
            temp = null;
        }
    }
}
