using System;
using System.Collections.Generic;
using System.Text;

namespace JetBanjo.Utils
{
    public class SensorType
    {
        //The different sensor types used in the web classes
        //It cannot be a enum becuase of the need for string values
        public const string CO2 = "co2";
        public const string Humidity = "humidity";
        public const string Light = "light";
        public const string Noise = "noise";
        public const string Pressure = "pressure";
        public const string Temperature = "temperature";
        public const string UV = "uv";
        public const string VOC = "voc";

    }
}
