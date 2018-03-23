using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JetBanjo.Web.Objects
{
    public class NoiseData
    {
        [JsonProperty(PropertyName = "value")]
        public int dB { get; set; }


        public static NoiseData Get()
        {
            return new NoiseData();
        }

        public void Update()
        {
            NoiseData temp = Get();
            dB = temp.dB;
            temp = null;
        }

    }
}
