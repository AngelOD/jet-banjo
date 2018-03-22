using System;
using System.Collections.Generic;
using System.Text;

namespace JetBanjo.Utils
{
    public static class Constants
    {
        //Temperature thresholds.
        private const double SEMI_OPTIMAL_TEMP_RANGE = 0.5; //Non-Zero, positive, max 1. Allowed variance from optimal temp.
        public const double MAX_TEMP = 25;
        public const double MAX_COMFORTABLE_TEMP = 23;
        public const double MIN_COMFORTABLE_TEMP = 20;
        public const double MIN_TEMP = 18;
        public const double MIN_OPTIMAL_ALLOWED = MIN_COMFORTABLE_TEMP - SEMI_OPTIMAL_TEMP_RANGE;
        public const double MAX_OPTIMAL_ALLOWED = MAX_COMFORTABLE_TEMP + SEMI_OPTIMAL_TEMP_RANGE;

        //Humidity Thresholds. In percent.
        public const double MIN_HUMIDITY = 25;
        public const double MAX_HUMIDITY_SUMMER = 60;
        public const double MAX_HUMIDITY_WINTER = 45;
    }
}
