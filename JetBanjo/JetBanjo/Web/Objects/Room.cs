using JetBanjo.Resx;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

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


        public static Room Get(string id)
        {
            return new Room();
        }

        public static List<Room> Get()
        {
            return new List<Room>();
        }

        public void Update()
        {
            Room temp = Get(Id);
            RoomNumber = temp.RoomNumber;
            Score = temp.Score;
            temp = null;
        }

        #region Overrides
        public override bool Equals(object obj)
        {
            if (obj is Room)
            {
                return Id.Equals(((Room)obj).Id);
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
