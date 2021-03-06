﻿using JetBanjo.Resx;
using JetBanjo.Utils;
using JetBanjo.Utils.DependencyService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using JetBanjo.Utils.Data;
using static JetBanjo.Utils.Data.DataStoreKeys;

namespace JetBanjo.Web.Objects
{
    public class SensorObject
    {
        [JsonProperty(PropertyName = "value")]
        public double Value { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string RoomID { get; set; }

        public bool IsValid { get; private set; }

        /// <summary>
        /// Returns the latest sensor data for a given room for a given type.
        /// </summary>
        /// <param name="roomId">The roomId of the room</param>
        /// <param name="type">The sensor type</param>
        /// <returns>Sensor data object</returns>
        protected static async Task<T> Get<T>(string roomId, string type) where T : SensorObject
        {
            T temp = default(T);
            string ip = DataStore.GetValue(Keys.Ip);
            WebResult<T> result = await WebHandler.ReadData<T>(ip + Constants.API_ROOMS_URL + "/" + roomId + "/" + type);
            if (HttpStatusCode.OK.Equals(result.ResponseCode))
            {
                temp = result.Result;
                temp.IsValid = true;
            }
            else
            {
                temp.IsValid = false;
            }

            return temp;
        }

        /// <summary>
        /// Updates the current object with the latest data
        /// </summary>
        protected async Task Update<T>(string type) where T : SensorObject
        {
            T temp = await Get<T>(RoomID, type);
            Value = temp.Value;
            RoomID = temp.RoomID;
            temp = null;
        }

    }
}
