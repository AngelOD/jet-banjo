using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JetBanjo.Web.Objects
{
    public class VocData
    {
        [JsonProperty(PropertyName = "value")]
        public int VOC { get; set; }


        public static VocData Get()
        {
            return new VocData();
        }

        public void Update()
        {
            VocData temp = Get();
            VOC = temp.VOC;
            temp = null;
        }
    }
}
