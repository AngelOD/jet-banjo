using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JetBanjo.Web.Objects
{
    public class PressureData
    {
        [JsonProperty(PropertyName = "value")]
        public int Pressure { get; set; }


        public static PressureData Get()
        {
            return new PressureData();
        }

        public void Update()
        {
            PressureData temp = Get();
            Pressure = temp.Pressure;
            temp = null;
        }
    }
}
