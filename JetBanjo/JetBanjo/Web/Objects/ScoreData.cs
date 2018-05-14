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
        [JsonProperty(PropertyName = "room_id")]
        public double RoomID { get; set; }

        [JsonProperty(PropertyName = "id")]
        public double ID { get; set; }

        [JsonProperty(PropertyName = "end_time")]
        public Int64 EndTime { get; set; }

        [JsonProperty(PropertyName = "interval")]
        public double Timespan { get; set; }

        [JsonProperty(PropertyName = "total_score")]
        public double TotalScore { get; set; }

        [JsonProperty(PropertyName = "iaq_score")]
        public double IAQScore { get; set; }

        [JsonProperty(PropertyName = "sound_score")]
        public double SoundScore { get; set; }

        [JsonProperty(PropertyName = "temp_hum_score")]
        public double TempHumScore { get; set; }

        [JsonProperty(PropertyName = "visual_score")]
        public double VisualScore { get; set; }

        /// <summary>
        /// Asynchronously returns a list of scoreData objects for the current room.
        /// </summary>
        /// <returns></returns>
        public static async Task<List<ScoreData>> GetList() 
        {
            string roomId = DataStore.GetValue(Keys.Room);
            List<ScoreData> temp = new List<ScoreData>();
            string ip = DataStore.GetValue(Keys.Ip);
            WebResult<List<ScoreData>> result = await WebHandler.ReadData<List<ScoreData>>(ip + Constants.API_SCORE_URL + "/" + roomId);
            if (HttpStatusCode.OK.Equals(result.ResponseCode))
                temp = result.Result;

            return temp;
        }
    }
}
