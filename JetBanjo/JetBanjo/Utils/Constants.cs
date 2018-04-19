using System;
using System.Collections.Generic;
using System.Text;
using JetBanjo.Utils;

namespace JetBanjo.Utils
{
    public static class Constants
    {
        //Image list offset
        public static int IMAGE_OFFSET_SLEEPING = 100; //Offset used if child is sleeping
        public static int IMAGE_OFFSET_NOISE = 200; //Offset used if child is holding hands over ears
        public static int IMAGE_OFFSET_SLEEPING_NOISE = 300; //Offset used if both

        //Ranges for classifying data (-1 indicates that no value is present)
        public static DataRange TEMP_RANGES = new DataRange("temp", 18, 19.5, 23.5, 25);
        public static DataRange HUMID_SUMMER_RANGES = new DataRange("humid", 25, 35, 50, 60);
        public static DataRange HUMID_WINTER_RANGES = new DataRange("humid", 25, 35, 40, 45);
        public static DataRange CO2_RANGES = new DataRange("co2", -1, -1, 1000, 2000);
        public static DataRange UV_RANGES = new DataRange("uv", -1, -1, 3, 5);
        public static DataRange LIGHT_RANGES = new DataRange("light", 200, 400, 1000, 5000);
        public static DataRange NOISE_RANGES = new DataRange("noise", -1, -1, 60, 75);
        public static DataRange VOC_RANGES = new DataRange("voc", -1, -1, 60, 180);
        //[60, 120, 180, 240]

        //Image constants

        //Done
        public static readonly Dictionary<int, List<CImage>> TEMP_IMAGES = new Dictionary<int, List<CImage>>()
        {
            {
                1, new List<CImage>()
                {
                    new CImage("overlay-frozen.png", ImageType.Frozen)
                }
            },
            {
                2, new List<CImage>()
                {
                    new CImage("overlay-cold.png", ImageType.ColdSweatFire),
                    new CImage("overlay-cold-arms-down.png", ImageType.ColdSweatFire)
                }
            },
            {
                2 + IMAGE_OFFSET_NOISE, new List<CImage>()
                {
                    new CImage("overlay-cold-no-arms.png", ImageType.ColdSweatFire),
                    new CImage("overlay-cold-arms-up.png", ImageType.ColdSweatFire)
                }
            },
            {
                2 + IMAGE_OFFSET_SLEEPING, new List<CImage>()
                {
                    new CImage("overlay-sleeping-cold-no-arms.png", ImageType.ColdSweatFire),
                    new CImage("overlay-sleeping-cold-arms-down.png", ImageType.ColdSweatFire)
                }
            },
            {
                2 + IMAGE_OFFSET_SLEEPING_NOISE, new List<CImage>()
                {
                    new CImage("overlay-sleeping-cold-no-arms.png", ImageType.ColdSweatFire),
                    new CImage("overlay-sleeping-cold-arms-up.png", ImageType.ColdSweatFire)
                }
            },
            {
                4, new List<CImage>()
                {
                    new CImage("overlay-sweat.png", ImageType.ColdSweatFire)
                }
            },
            {
                4 + IMAGE_OFFSET_SLEEPING, new List<CImage>()
                {
                    new CImage("overlay-sleeping-sweat.png", ImageType.ColdSweatFire)
                }
            },
            {
                5, new List<CImage>()
                {
                    new CImage("overlay-fire-no-arms.png", ImageType.ColdSweatFire),
                    new CImage("overlay-fire-arms-down.png", ImageType.ColdSweatFire)
                }
            },
            {
                5 + IMAGE_OFFSET_NOISE, new List<CImage>()
                {
                    new CImage("overlay-fire-no-arms.png", ImageType.ColdSweatFire),
                    new CImage("overlay-fire-arms-up.png", ImageType.ColdSweatFire)
                }
            },
            {
                5 + IMAGE_OFFSET_SLEEPING, new List<CImage>()
                {
                    new CImage("overlay-sleeping-fire-no-arms.png", ImageType.ColdSweatFire),
                    new CImage("overlay-fire-sleeping-arms-down.png", ImageType.ColdSweatFire)
                }
            },
            {
                5 + IMAGE_OFFSET_SLEEPING_NOISE, new List<CImage>()
                {
                    new CImage("overlay-sleeping-fire-no-arms.png", ImageType.ColdSweatFire),
                    new CImage("overlay-sleeping-fire-arms-up.png", ImageType.ColdSweatFire)
                }
            }
        };

        //Done
        public static readonly Dictionary<int, List<CImage>> HUMID_IMAGES = new Dictionary<int, List<CImage>>()
        {
            {
                1, new List<CImage>()
                {
                    new CImage("overlay-desert.png", ImageType.Humidity)
                }
            },
            {
                5, new List<CImage>()
                {
                    new CImage("overlay-watervapour.png", ImageType.Humidity)
                }
            }
        };

        //Done
        public static readonly Dictionary<int, List<CImage>> CO2_IMAGES = new Dictionary<int, List<CImage>>()
        {
            {
                1, new List<CImage>()
                {
                    new CImage("child-no-arms.png", ImageType.Character)
                }
            },
            {
                2, new List<CImage>()
                {
                    new CImage("child-no-arms.png", ImageType.Character)
                }
            },
            {
                3, new List<CImage>()
                {
                    new CImage("child-no-arms.png", ImageType.Character)
                }
            },
            {
                4, new List<CImage>()
                {
                    new CImage("child-no-arms.png", ImageType.Character),
                    new CImage("overlay-dizzy.png", ImageType.CO2)
                }
            },
            {
                5, new List<CImage>()
                {
                    new CImage("child-sleeping-no-arms.png", ImageType.CO2)
                }
            }
        };

        //Done
        public static readonly Dictionary<int, List<CImage>> UV_IMAGES = new Dictionary<int, List<CImage>>()
        {
            {
                4, new List<CImage>()
                {
                    new CImage("overlay-tan-no-arms.png", ImageType.UV),
                    new CImage("overlay-tan-arms-down.png", ImageType.UV)
                }
            },
            {
                4 + IMAGE_OFFSET_SLEEPING, new List<CImage>()
                {
                    new CImage("overlay-sleeping-tan-no-arms.png", ImageType.UV),
                    new CImage("overlay-sleeping-tan-arms-down.png", ImageType.UV)
                }
            },
            {
                4 + IMAGE_OFFSET_NOISE, new List<CImage>()
                {
                    new CImage("overlay-tan-no-arms.png", ImageType.UV),
                    new CImage("overlay-tan-arms-up.png", ImageType.UV)
                }
            },
            {
                4 + IMAGE_OFFSET_SLEEPING_NOISE, new List<CImage>()
                {
                    new CImage("overlay-sleeping-tan-no-arms.png", ImageType.UV),
                    new CImage("overlay-sleeping-tan-arms-up.png", ImageType.UV)
                }
            },
            {
                5, new List<CImage>()
                {
                    new CImage("overlay-sunburn-no-arms.png", ImageType.UV),
                    new CImage("overlay-sunburn-arms-down.png", ImageType.UV)
                }
            },
            {
                5 + IMAGE_OFFSET_SLEEPING, new List<CImage>()
                {
                    new CImage("overlay-sleeping-sunburn-no-arms.png", ImageType.UV),
                    new CImage("overlay-sleeping-sunburn-arms-down.png", ImageType.UV)
                }
            },
            {
                5 + IMAGE_OFFSET_NOISE, new List<CImage>()
                {
                    new CImage("overlay-sunburn-no-arms.png", ImageType.UV),
                    new CImage("overlay-sunburn-arms-up.png", ImageType.UV)
                }
            },
            {
                5 + IMAGE_OFFSET_SLEEPING_NOISE, new List<CImage>()
                {
                    new CImage("overlay-sleeping-sunburn-no-arms.png", ImageType.UV),
                    new CImage("overlay-sleeping-sunburn-arms-up.png", ImageType.UV)
                }
            },
        };

        //Done
        public static readonly Dictionary<int, List<CImage>> LIGHT_IMAGES = new Dictionary<int, List<CImage>>()
        {
            {
                1, new List<CImage>()
                {
                    new CImage("overlay-darkness.png", ImageType.Dark)
                }
            },
            {
                5, new List<CImage>()
                {
                    new CImage("overlay-sunglasses.png", ImageType.Sunglasses)
                }
            },
            {
                5 + IMAGE_OFFSET_SLEEPING, new List<CImage>()
                {
                    new CImage("overlay-sleeping-sunglasses.png", ImageType.Sunglasses)
                }
            }
        };

        //Done
        public static readonly Dictionary<int, List<CImage>> VOC_IMAGES = new Dictionary<int, List<CImage>>()
        {
            {
                4, new List<CImage>()
                {
                    new CImage("overlay-lesser-green-fog.png", ImageType.VOC)
                }
            },
            {
                5, new List<CImage>()
                {
                    new CImage("overlay-sleeping-sunglasses.png", ImageType.VOC)
                }
            }
        };

        //Done
        public static readonly Dictionary<int, List<CImage>> NOISE_IMAGES = new Dictionary<int, List<CImage>>()
        {
            {
                1, new List<CImage>()
                {
                    new CImage("child-arms-down.png", ImageType.Arms)
                }
            },
            {
                1 + IMAGE_OFFSET_SLEEPING, new List<CImage>()
                {
                    new CImage("child-sleeping-arms-down.png", ImageType.Character)
                }
            },
            {
                2, new List<CImage>()
                {
                    new CImage("child-arms-down.png", ImageType.Arms)
                }
            },
            {
                2 + IMAGE_OFFSET_SLEEPING, new List<CImage>()
                {
                    new CImage("child-sleeping-arms-down.png", ImageType.Arms)
                }
            },
            {
                3, new List<CImage>()
                {
                    new CImage("child-arms-down.png", ImageType.Arms)
                }
            },
            {
                3 + IMAGE_OFFSET_SLEEPING, new List<CImage>()
                {
                    new CImage("child-sleeping-arms-down.png", ImageType.Arms)
                }
            },
            {
                4, new List<CImage>()
                {
                    new CImage("child-arms-down.png", ImageType.Arms)
                }
            },
            {
                4 + IMAGE_OFFSET_SLEEPING, new List<CImage>()
                {
                    new CImage("child-sleeping-arms-up.png", ImageType.Arms)
                }
            },
            {
                5, new List<CImage>()
                {
                    new CImage("overlay-earmuffs.png", ImageType.Noise),
                    new CImage("child-sleeping-arms-down.png", ImageType.Arms)
                }
            },
            {
                5 + IMAGE_OFFSET_SLEEPING, new List<CImage>()
                {
                    new CImage("overlay-earmuffs-sleeping.png", ImageType.Noise),
                    new CImage("child-sleeping-arms-down.png", ImageType.Arms)
                }
            }
        };

        //Season
        public static readonly List<int> WINTER_MONTHS = new List<int>() //We assume that all other months are SUMMER.
        {
            10, 11, 12, 1, 2, 3, 4
        };

        public const string DEBUG_IP_ADDRESS = "sw802f18.blazingskies.dk";
        public const double BUTTON_SCALE = 0.5;
        public const double ENTRY_SCALE = 0.5;
        public const double LABEL_SCALE = 0.5;
        public const double LIST_SCALE = 0.7;

        public static TimeSpan cacheMaxAge = new TimeSpan(0, 2, 0); //0 hours, 2 minutes, 0 seconds
        public static TimeSpan timeoutTime = new TimeSpan(0, 0, 30); //0 hours, 0 minutes, 30 seconds


        public const string NETWORK_SEARCH = "_ipp._tcp";
        public const string API_ROOMS_URL = "/api/rooms";
    }
}
