using JetBanjo.Resx;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JetBanjo.Web.Objects
{
    public class Room
    {
        private string roomNumber;

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "score")]
        public int Score { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string RoomNumber
        {
            get
            {
                if (roomNumber.StartsWith(AppResources.room))
                    return roomNumber;
                else
                    return AppResources.room + " " + roomNumber;
            }
            set { roomNumber = value; }
        }

        //ToDo Finish implmentation when the web handler and backend is more finished
        /// <summary>
        /// Returns the latest room data for a given room identified by its id
        /// </summary>
        /// <returns>Room data object</returns>
        public static async Task<Room> Get(string id)
        {
            return new Room() { Id = id } ;
        }

        //ToDo Finish implmentation when the web handler and backend is more finished
        /// <summary>
        /// Returns the latest list of room
        /// </summary>
        /// <returns>Room list</returns>
        public static async Task<List<Room>> GetList()
        {
            List<Room> roomList = new  List<Room>();
            roomList.Add(new Room() { RoomNumber = "1.1", Id = "fst" });
            roomList.Add(new Room() { RoomNumber = "2.1", Id = "sec" });
            roomList.Add(new Room() { RoomNumber = "3.1", Id = "thd" });
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
