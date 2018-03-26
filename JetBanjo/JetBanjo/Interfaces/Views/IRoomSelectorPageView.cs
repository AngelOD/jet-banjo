using JetBanjo.Web.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace JetBanjo.Interfaces.Views
{
    public interface IRoomSelectorPageView
    {
        void OnTextChanged(object sender, EventArgs args);

        void OnItemSelected(object sender, EventArgs args);

        void UpdateRoomList(List<Room> updatedRoomList);

    }
}
