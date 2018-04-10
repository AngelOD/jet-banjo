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
    public class SensorData
    {
        [JsonProperty(PropertyName = "co2")]
        public int CO2 { get; set; }

        [JsonProperty(PropertyName = "humidity")]
        public double Humidity { get; set; }

        [JsonProperty(PropertyName = "light")]
        public int Lux { get; set; }

        [JsonProperty(PropertyName = "noise")]
        public int dB { get; set; }

        [JsonProperty(PropertyName = "pressure")]
        public int Pressure { get; set; }

        [JsonProperty(PropertyName = "temperature")]
        public double Temperature { get; set; }

        [JsonProperty(PropertyName = "uv")]
        public int UV { get; set; }

        [JsonProperty(PropertyName = "voc")]
        public int VOC { get; set; }

        /// <summary>
        /// Returns the latest combined sensor data
        /// </summary>
        /// <returns>Sensor data object</returns>
        public static async Task<SensorData> Get()
        {
            string room = DataStore.GetValue(DataStore.Keys.Room);
            return await Get(room);
        }

        /// <summary>
        /// Returns the latest combined sensor data
        /// </summary>
        /// <returns>Sensor data object</returns>
        public static async Task<SensorData> Get(string roomId)
        {
            SensorData temp = new SensorData();
            string ip = DataStore.GetValue(DataStore.Keys.Ip);
            WebResult<SensorData> result = await WebHandler.ReadData<SensorData>(ip + Constants.API_ROOMS_URL + "/" + roomId + "/all");
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
            SensorData temp = await Get();
            CO2 = temp.CO2;
            Humidity = temp.Humidity;
            Lux = temp.Lux;
            dB = temp.dB;
            Pressure = temp.Pressure;
            Temperature = temp.Temperature;
            UV = temp.UV;
            VOC = temp.VOC;
            temp = null;
        }

    }
}
