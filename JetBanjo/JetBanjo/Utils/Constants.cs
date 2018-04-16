using System;
using System.Collections.Generic;
using System.Text;
using JetBanjo.Utils;

namespace JetBanjo.Utils
{
    public static class Constants
    {
        //Ranges for classifying data (-1 indicates that no value is present)
        public static DataRange TEMP_RANGES = new DataRange(18, 19.5, 23.5, 25);
        public static DataRange HUMID_SUMMER_RANGES = new DataRange(25, 35, 50, 60);
        public static DataRange HUMID_WINTER_RANGES = new DataRange(25, 35, 40, 45);
        public static DataRange CO2_RANGES = new DataRange(-1, -1, 1000, 2000);
        public static DataRange UV_RANGES = new DataRange(-1, -1, 3, 5);
        public static DataRange LIGHT_RANGES = new DataRange(200, 400, 1000, 5000);
        public static DataRange NOISE_RANGES = new DataRange(-1, -1, 60, 75);

        //Season
        public static readonly List<int> WINTER_MONTHS = new List<int>() //We assume that all other months are SUMMER.
        {
            10, 11, 12, 1, 2, 3, 4
        };

        public const string DEBUG_IP_ADDRESS = "sw802f18.blazingskies.dk";
        public const double BUTTON_SCALE = 0.5;
        public const double ENTRY_SCALE = 0.5;

        public static TimeSpan cacheMaxAge = new TimeSpan(0, 2, 0); //0 hours, 2 minutes, 0 seconds
        public static TimeSpan timeoutTime = new TimeSpan(0, 0, 30); //0 hours, 0 minutes, 30 seconds


        public const string NETWORK_SEARCH = "_ipp._tcp";
        public const string API_ROOMS_URL = "/api/rooms";
    }
}
