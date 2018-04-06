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
            PressureData temp = new PressureData();
            string ip = DataStore.GetValue(DataStore.Keys.Ip);
            string room = DataStore.GetValue(DataStore.Keys.Room);
            WebResult<PressureData> result = await WebHandler.ReadData<PressureData>(ip + "/api/room/" + room + "/" + SensorType.Pressure);
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
            PressureData temp = await Get();
            Pressure = temp.Pressure;
            temp = null;
        }
    }
}
