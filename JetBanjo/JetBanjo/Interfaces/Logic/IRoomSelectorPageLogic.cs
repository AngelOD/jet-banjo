using JetBanjo.Web.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JetBanjo.Interfaces.Logic
{
    public interface IRoomSelectorPageLogic
    {
        /// <summary>
        /// Returns a filtered list of rooms based on the input
        /// </summary>
        /// <param name="filterKey"></param>
        /// <returns>A list of filtered rooms<
        Task<List<Room>> FilterList(string filterKey);

        /// <summary>
        /// //Returns the current available rooms from the back-end
        /// </summary>
        /// <returns>A list of rooms</returns>
        Task<List<Room>> GetList();

    }
}
