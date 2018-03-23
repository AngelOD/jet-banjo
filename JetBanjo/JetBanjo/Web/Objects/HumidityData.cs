using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JetBanjo.Web.Objects
{
    public class HumidityData
    {
        [JsonProperty(PropertyName = "value")]
        public double Humidity { get; set; }


        public static HumidityData Get()
        {
            return new HumidityData();
        }

        public void Update()
        {
            HumidityData temp = Get();
            Humidity = temp.Humidity;
            temp = null;
        }
    }
}
