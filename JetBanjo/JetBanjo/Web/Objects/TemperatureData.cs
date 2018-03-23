using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JetBanjo.Web.Objects
{
    public class TemperatureData
    {

        [JsonProperty(PropertyName = "value")]
        public double Temperature { get; set; }


        public static TemperatureData Get()
        {
            return new TemperatureData();
        }

        public void Update()
        {
            TemperatureData temp = Get();
            Temperature = temp.Temperature;
            temp = null;
        }
    }
}
