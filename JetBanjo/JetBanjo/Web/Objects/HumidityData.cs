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
            HumidityData temp = new HumidityData();
            string ip = DataStore.GetValue(DataStore.Keys.Ip);
            string room = DataStore.GetValue(DataStore.Keys.Room);
            WebResult<HumidityData> result = await WebHandler.ReadData<HumidityData>(ip + "/api/room/" + room + "/" + SensorType.Humidity);
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
            HumidityData temp = await Get();
            Humidity = temp.Humidity;
            temp = null;
        }
    }
}
