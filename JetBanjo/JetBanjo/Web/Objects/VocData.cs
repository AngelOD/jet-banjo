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
            VOCData temp = new VOCData();
            string ip = DataStore.GetValue(DataStore.Keys.Ip);
            string room = DataStore.GetValue(DataStore.Keys.Room);
            WebResult<VOCData> result = await WebHandler.ReadData<VOCData>(ip + "/api/room/" + room + "/" + SensorType.VOC);
            if (HttpStatusCode.OK.Equals(result.ResponseCode))
                temp = result.Result;
            else
                DependencyService.Get<IDisplayService>(DependencyFetchTarget.GlobalInstance).ShowToast(AppResources.download_err, false);

            return temp;
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
