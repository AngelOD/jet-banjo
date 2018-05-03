using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using JetBanjo.Utils;
using JetBanjo.Utils.Data;
using Newtonsoft.Json;
using static JetBanjo.Utils.Data.DataStoreKeys;

namespace JetBanjo.Web.Objects
{
    public class ScoreData
    {
        [JsonProperty(PropertyName = "OverallScore")]
        public double OverallScore { get; set; }

        [JsonProperty(PropertyName = "IAQScore")]
        public double IAQScore { get; set; }

        [JsonProperty(PropertyName = "TempHumScore")]
        public double TempHumScore { get; set; }

        [JsonProperty(PropertyName = "SoundScore")]
        public double SoundScore { get; set; }

        [JsonProperty(PropertyName = "VisualScore")]
        public double VisualScore { get; set; }

        public static async Task<List<ScoreData>> Get() 
        {
            string roomId = DataStore.GetValue(Keys.Room);
            List<ScoreData> temp = new List<ScoreData>();
            string ip = DataStore.GetValue(Keys.Ip);
            WebResult<List<ScoreData>> result = await WebHandler.ReadData<List<ScoreData>>(ip + Constants.API_ROOMS_URL + "/" + roomId + "/score");
            if (HttpStatusCode.OK.Equals(result.ResponseCode))
                temp = result.Result;

            return temp;
        }
    }
}
