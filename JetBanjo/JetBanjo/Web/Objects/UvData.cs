using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JetBanjo.Web.Objects
{
    public class UVData
    {
        [JsonProperty(PropertyName = "value")]
        public int UV { get; set; }

        //ToDo Finish implmentation when the web handler and backend is more finished
        /// <summary>
        /// Returns the latest UV data
        /// </summary>
        /// <returns>UV data object</returns>
        public static async Task<UVData> Get()
        {
            return new UVData();
        }

        /// <summary>
        /// Updates the current object with the latest data
        /// </summary>
        public async void Update()
        {
            UVData temp = await Get();
            UV = temp.UV;
            temp = null;
        }

    }
}
