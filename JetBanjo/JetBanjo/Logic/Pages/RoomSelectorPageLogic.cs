using JetBanjo.Interfaces.Logic;
using JetBanjo.Resx;
using JetBanjo.Web.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JetBanjo.Logic.Pages
{
    public class RoomSelectorPageLogic : IRoomSelectorPageLogic
    {
        private List<Room> roomList;

        private async Task DownloadRoomList()
        {
            roomList = await Room.GetList();
        }

        /// <summary>
        /// Returns a filtered list of rooms based on the input
        /// </summary>
        /// <param name="filterKey"></param>
        /// <returns>A list of filtered rooms</returns>
        public List<Room> FilterList(string filterKey)
        {
            if (string.IsNullOrWhiteSpace(filterKey))
            {
                return roomList;
            }
            else
            {
                return roomList.Where(r => r.RoomNumber.ToLower().Contains(filterKey.ToLower())).ToList();
            }
        }

        /// <summary>
        /// Returns a list of rooms
        /// </summary>
        /// <returns>A list of rooms</returns>
        public async Task<List<Room>> GetList()
        {
            if(roomList == null)
            {
                await DownloadRoomList();
            }

            return roomList;
        }
    }
}
