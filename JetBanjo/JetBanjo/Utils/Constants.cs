﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JetBanjo.Utils
{
    public static class Constants
    {

        public const string DEBUG_IP_ADDRESS = "sw802f18.blazingskies.dk";
        public const double BUTTON_SCALE = 0.5;
        public const double ENTRY_SCALE = 0.5;

        public static TimeSpan cacheMaxAge = new TimeSpan(0, 2, 0); //0 hours, 2 minutes, 0 seconds
        public static TimeSpan timeoutTime = new TimeSpan(0, 0, 30); //0 hours, 0 minutes, 30 seconds


        public const string NETWORK_SEARCH = "_ipp._tcp";
        public const string API_ROOMS_URL = "/api/rooms";
    }
}
