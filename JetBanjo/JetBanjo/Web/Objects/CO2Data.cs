using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JetBanjo.Web.Objects
{
    public class CO2Data
    {

        [JsonProperty(PropertyName = "value")]
        public int CO2 { get; set; }


        public static CO2Data Get()
        {
            return new CO2Data();
        }

        public void Update()
        {
            CO2Data temp = Get();
            CO2 = temp.CO2;
            temp = null;
        }
    }
}
