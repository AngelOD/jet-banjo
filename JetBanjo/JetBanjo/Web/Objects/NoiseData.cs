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
            NoiseData temp = new NoiseData();
            string ip = DataStore.GetValue(DataStore.Keys.Ip);
            string room = DataStore.GetValue(DataStore.Keys.Room);
            WebResult<NoiseData> result = await WebHandler.ReadData<NoiseData>(ip + "/api/room/" + room + "/" + SensorType.Noise);
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
            NoiseData temp = await Get();
            dB = temp.dB;
            temp = null;
        }

    }
}
