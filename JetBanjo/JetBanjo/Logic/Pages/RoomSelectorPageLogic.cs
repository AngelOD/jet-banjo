using JetBanjo.Interfaces.Logic;
using JetBanjo.Interfaces.Views;
using JetBanjo.Resx;
using JetBanjo.Web.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JetBanjo.Logic.Pages
{
    public class RoomSelectorPageLogic : IRoomSelectorPageLogic
    {
        private IRoomSelectorPageView view;
        private List<Room> roomList = new List<Room>();

        public void DownloadRoomList()
        {
            roomList.Add(new Room("1.1"));
            roomList.Add(new Room("2.1"));
            roomList.Add(new Room("3.1"));
        }

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

        public List<Room> GetList()
        {
            return roomList;
        }

        public void SetView(IRoomSelectorPageView view)
        {
            this.view = view;
        }
    }
}
