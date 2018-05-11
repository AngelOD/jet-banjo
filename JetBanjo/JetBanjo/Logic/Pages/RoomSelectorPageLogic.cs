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

        /// <summary>
        /// Returns a filtered list of rooms based on the input
        /// </summary>
        /// <param name="filterKey"></param>
        /// <returns>A list of filtered rooms</returns>
        public async Task<List<Room>> FilterList(string filterKey)
        {
            if (string.IsNullOrWhiteSpace(filterKey))
            {
                return await Room.GetList(); //Returns the current available rooms from the back-end
            }
            else
            {
                List<Room> roomList = await Room.GetList(); //Fetches he current available rooms
                return roomList.Where(r => r.RoomNumber.ToLower().Contains(filterKey.ToLower())).ToList(); //Filters them based on the room number and returns it
            }
        }

        /// <summary>
        /// //Returns the current available rooms from the back-end
        /// </summary>
        /// <returns>A list of rooms</returns>
        public async Task<List<Room>> GetList()
        {
            return await Room.GetList(); //Returns the current available rooms from the back-end
        }
    }
}
