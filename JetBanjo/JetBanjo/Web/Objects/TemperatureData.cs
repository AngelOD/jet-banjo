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
            TemperatureData temp = new TemperatureData();
            string ip = DataStore.GetValue(DataStore.Keys.Ip);
            string room = DataStore.GetValue(DataStore.Keys.Room);
            WebResult<TemperatureData> result = await WebHandler.ReadData<TemperatureData>(ip + "/api/room/" + room + "/" + SensorType.Temperature);
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
            TemperatureData temp = await Get();
            Temperature = temp.Temperature;
            temp = null;
        }
    }
}
