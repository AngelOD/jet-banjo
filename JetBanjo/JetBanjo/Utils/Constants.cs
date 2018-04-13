using System;
using System.Collections.Generic;
using System.Text;

namespace JetBanjo.Utils
{
    public static class Constants
    {
        //Temperature thresholds
        private const double SEMI_OPTIMAL_TEMP_RANGE = 0.5; //Non-Zero, positive, max 1. Allowed variance from optimal temp.
        public const double MAX_TEMP = 25;
        public const double MAX_COMFORTABLE_TEMP = 23;
        public const double MIN_COMFORTABLE_TEMP = 20;
        public const double MIN_TEMP = 18;
        public const double MIN_OPTIMAL_ALLOWED = MIN_COMFORTABLE_TEMP - SEMI_OPTIMAL_TEMP_RANGE;
        public const double MAX_OPTIMAL_ALLOWED = MAX_COMFORTABLE_TEMP + SEMI_OPTIMAL_TEMP_RANGE;

        //Humidity Thresholds. In percent.
        private const double SEMI_OPTIMAL_HUMIDITY_RANGE = 10;
        public const double MIN_HUMIDITY = 25;
        public const double MAX_HUMIDITY_SUMMER = 60;
        public const double MAX_HUMIDITY_WINTER = 45;
        public const double MIN_OPTIMAL_HUMIDITY = MIN_HUMIDITY + SEMI_OPTIMAL_HUMIDITY_RANGE;
        public const double MAX_OPTIMAL_HUMIDITY_WINTER = MAX_HUMIDITY_WINTER - SEMI_OPTIMAL_HUMIDITY_RANGE;
        public const double MAX_OPTIMAL_HUMIDITY_SUMMER = MAX_HUMIDITY_SUMMER - SEMI_OPTIMAL_HUMIDITY_RANGE;

        //CO2 Thresholds. In Parts per Million
        private const double SEMI_OPTIMAL_CO2_RANGE = 250;
        public const double MAX_OPTIMAL_CO2 = 1000;
        public const double MAX_CO2 = 2000;
        public const double MAX_SUBOPTIMAL_CO2 = MAX_CO2 - SEMI_OPTIMAL_CO2_RANGE;
        public const double MAX_SEMI_OPTIMAL_CO2 = MAX_OPTIMAL_CO2 + SEMI_OPTIMAL_CO2_RANGE;

        //Light Thresholds. In lux
        public const double MIN_LUX = 200;
        public const double MIN_SUBOPTIMAL_LUX = 300;
        public const double MIN_OPTIMAL_LUX = 400;
        public const double MAX_OPTIMAL_LUX = 500;
        public const double MAX_SUBOPTIMAL_LUX = 1000;
        public const double MAX_LUX = 5000;

        //Noise Thresholds. In Decibel(A)
        public const double OPTIMAL_DB = 60;
        public const double SUBOPTIMAL_DB = 75;
        public const double MAX_DB = 85;

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
