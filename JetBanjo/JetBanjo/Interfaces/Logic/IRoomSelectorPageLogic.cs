using JetBanjo.Interfaces.Views;
using JetBanjo.Web.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JetBanjo.Interfaces.Logic
{
    public interface IRoomSelectorPageLogic
    {
        void SetView(IRoomSelectorPageView view);

        List<Room> FilterList(string filterKey);

        Task<List<Room>> GetList();

    }
}
