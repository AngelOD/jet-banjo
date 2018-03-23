using JetBanjo.Interfaces.Views;
using JetBanjo.Web.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace JetBanjo.Interfaces.Logic
{
    public interface IRoomSelectorPageLogic
    {
        void SetView(IRoomSelectorPageView view);

        void DownloadRoomList();

        List<Room> FilterList(string filterKey);

        List<Room> GetList();

    }
}
