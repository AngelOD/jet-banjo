using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JetBanjo.Web.Objects
{
    public class LightData
    {
        [JsonProperty(PropertyName = "value")]
        public int Lux { get; set; }


        public static LightData Get()
        {
            return new LightData();
        }

        public void Update()
        {
            LightData temp = Get();
            Lux = temp.Lux;
            temp = null;
        }

    }
}
