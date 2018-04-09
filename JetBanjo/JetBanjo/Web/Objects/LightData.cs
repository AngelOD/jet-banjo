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
            LightData temp = new LightData();
            string ip = DataStore.GetValue(DataStore.Keys.Ip);
            string room = DataStore.GetValue(DataStore.Keys.Room);
            WebResult<LightData> result = await WebHandler.ReadData<LightData>(ip + "/api/room/" + room + "/" + SensorType.Light);
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
            LightData temp = await Get();
            Lux = temp.Lux;
            temp = null;
        }

    }
}
