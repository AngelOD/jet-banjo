using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JetBanjo.Web.Objects
{
    public class UvData
    {
        [JsonProperty(PropertyName = "value")]
        public int UV { get; set; }


        public static UvData Get()
        {
            return new UvData();
        }

        public void Update()
        {
            UvData temp = Get();
            UV = temp.UV;
            temp = null;
        }

    }
}
