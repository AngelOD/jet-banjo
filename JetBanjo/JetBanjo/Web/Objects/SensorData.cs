using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

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


        public static SensorData Get()
        {
            return new SensorData();
        }

        public void Update()
        {
            SensorData temp = Get();
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
