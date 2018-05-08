using JetBanjo.Resx;
using JetBanjo.Utils;
using JetBanjo.Utils.DependencyService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static JetBanjo.Web.WebHandler;
using JetBanjo.Utils.Data;
using static JetBanjo.Utils.Data.DataStoreKeys;

namespace JetBanjo.Web.Objects
{
    public class Room
    {

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "score")]
        public double Score { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string RoomNumber { get; set; }

        /// <summary>
        /// Returns the latest room data for the subscribed room
        /// </summary>
        /// <returns>Room data object</returns>
        public static async Task<Room> Get()
        {
            string room = DataStore.GetValue(Keys.Room);
            return await Get(room);
        }

        /// <summary>
        /// Returns the latest room data for a given room identified by its id
        /// </summary>
        /// <param name="roomId">The room id</param>
        /// <returns>Room data object</returns>
        public static async Task<Room> Get(string roomId)
        {
            Room temp = new Room();
            string ip = DataStore.GetValue(Keys.Ip);
            WebResult<Room> result = await WebHandler.ReadData<Room>(ip + Constants.API_ROOMS_URL + "/" + roomId);
            if (HttpStatusCode.OK.Equals(result.ResponseCode))
                temp = result.Result;

            return temp;
        }

        /// <summary>
        /// Returns the latest list of room
        /// </summary>
        /// <returns>Room list</returns>
        public static async Task<List<Room>> GetList()
        {
            List<Room> roomList = new  List<Room>();
            string ip = DataStore.GetValue(Keys.Ip);
            WebResult<List<Room>> result = await WebHandler.ReadData<List<Room>>(ip + Constants.API_ROOMS_URL);
            if (HttpStatusCode.OK == result.ResponseCode)
                roomList = result.Result;

            return roomList;
        }

        /// <summary>
        /// Updates the current object with the latest data
        /// </summary>
        public async void Update()
        {
            Room temp = await Get(Id);
            RoomNumber = temp.RoomNumber;
            Score = temp.Score;
            temp = null;
        }

        #region Overrides
        public override bool Equals(object obj)
        {
            if (obj != null && obj is Room)
            {
                Room temp = obj as Room;
                if(temp.Id != null)
                {
                    return Id.Equals(temp.Id);
                }
                
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        /// <summary>
        /// Used to display this element
        /// </summary>
        /// <returns>A string containing the room number / name</returns>
        public override string ToString()
        {
            return RoomNumber;
        }
        #endregion
    }
}
