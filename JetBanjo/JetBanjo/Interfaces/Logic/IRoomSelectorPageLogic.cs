﻿using JetBanjo.Web.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JetBanjo.Interfaces.Logic
{
    public interface IRoomSelectorPageLogic
    {

        List<Room> FilterList(string filterKey);

        Task<List<Room>> GetList();

    }
}
