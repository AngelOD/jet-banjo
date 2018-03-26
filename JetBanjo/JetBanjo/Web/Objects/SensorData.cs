using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        //ToDo Finish implmentation when the web handler and backend is more finished
        /// <summary>
        /// Returns the latest combined sensor data
        /// </summary>
        /// <returns>Sensor data object</returns>
        public static async Task<SensorData> Get()
        {
            return new SensorData();
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
