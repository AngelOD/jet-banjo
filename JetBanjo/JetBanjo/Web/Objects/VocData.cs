using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JetBanjo.Web.Objects
{
    public class VOCData
    {
        [JsonProperty(PropertyName = "value")]
        public int VOC { get; set; }

        //ToDo Finish implmentation when the web handler and backend is more finished
        /// <summary>
        /// Returns the latest VOC data
        /// </summary>
        /// <returns>Voc data object</returns>
        public static async Task<VOCData> Get()
        {
            return new VOCData();
        }

        /// <summary>
        /// Updates the current object with the latest data
        /// </summary>
        public async void Update()
        {
            VOCData temp = await Get();
            VOC = temp.VOC;
            temp = null;
        }
    }
}
