using JetBanjo.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using static JetBanjo.Web.WebHandler;
using Xamarin.Forms;
using JetBanjo.Utils.DependencyService;
using JetBanjo.Resx;

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
            CO2Data temp = new CO2Data();
            string ip = DataStore.GetValue(DataStore.Keys.Ip);
            string room = DataStore.GetValue(DataStore.Keys.Room);
            WebResult<CO2Data> result = await WebHandler.ReadData<CO2Data>(ip + "/api/room/" + room + "/" + SensorType.CO2);
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
            CO2Data temp = await Get();
            CO2 = temp.CO2;
            temp = null;
        }
    }
}
