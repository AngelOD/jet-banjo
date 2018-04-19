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

        //Image constants

        //Done
        public static Dictionary<int, List<CImage>> TEMP_IMAGES = new Dictionary<int, List<CImage>>()
        {
            {
                1, new List<CImage>()
                {
                    new CImage("overlay-frozen.png", ImageType.Temperature)
                }
            },
            {
                2, new List<CImage>()
                {
                    new CImage("overlay-cold.png", ImageType.Temperature),
                    new CImage("overlay-arms-down-cold.png", ImageType.Temperature)
                }
            },
            {
                2 + IMAGE_OFFSET_NOISE, new List<CImage>()
                {
                    new CImage("overlay-cold.png", ImageType.Temperature),
                    new CImage("overlay-arms-up-cold.png", ImageType.Temperature)
                }
            },
            {
                2 + IMAGE_OFFSET_SLEEPING, new List<CImage>()
                {
                    new CImage("overlay-sleeping-cold.png", ImageType.Temperature),
                    new CImage("overlay-sleeping-arms-down-cold.png", ImageType.Temperature)
                }
            },
            {
                2 + IMAGE_OFFSET_SLEEPING_NOISE, new List<CImage>()
                {
                    new CImage("overlay-sleeping-cold.png", ImageType.Temperature),
                    new CImage("overlay-sleeping-arms-up-cold.png", ImageType.Temperature)
                }
            },
            {
                3, new List<CImage>()},
            {
                4, new List<CImage>()
                {
                    new CImage("overlay-sweat.png", ImageType.Temperature)
                }
            },
            {
                4 + IMAGE_OFFSET_SLEEPING, new List<CImage>()
                {
                    new CImage("overlay-sleeping-sweat.png", ImageType.Temperature)
                }
            },
            {
                5, new List<CImage>()
                {
                    new CImage("overlay-fire-no-arms.png", ImageType.Temperature),
                    new CImage("overlay-fire-arms-down.png", ImageType.Temperature)
                }
            },
            {
                5 + IMAGE_OFFSET_NOISE, new List<CImage>()
                {
                    new CImage("overlay-fire-no-arms.png", ImageType.Temperature),
                    new CImage("overlay-fire-arms-up.png", ImageType.Temperature)
                }
            },
            {
                5 + IMAGE_OFFSET_SLEEPING, new List<CImage>()
                {
                    new CImage("overlay-sleeping-fire-no-arms.png", ImageType.Temperature),
                    new CImage("overlay-fire-sleeping-arms-down.png", ImageType.Temperature)
                }
            },
            {
                5 + IMAGE_OFFSET_SLEEPING_NOISE, new List<CImage>()
                {
                    new CImage("overlay-sleeping-fire-no-arms.png", ImageType.Temperature),
                    new CImage("overlay-sleeping-fire-arms-up.png", ImageType.Temperature)
                }
            }
        };

        //Done
        public static Dictionary<int, List<CImage>> HUMID_IMAGES = new Dictionary<int, List<CImage>>()
        {
            {
                1, new List<CImage>()
                {
                    new CImage("overlay-desert.png", ImageType.Temperature)
                }
            },
            {
                2, new List<CImage>()
            },
            {
                3, new List<CImage>()
            },
            {
                4, new List<CImage>()
            },
            {
                5, new List<CImage>()
                {
                    new CImage("overlay-watervapour.png", ImageType.Temperature)
                }
            }
        };

        //Done
        public static Dictionary<int, List<CImage>> CO2_IMAGES = new Dictionary<int, List<CImage>>()
        {
            {
                4, new List<CImage>()
                {
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
        public static Dictionary<int, List<CImage>> UV_IMAGES = new Dictionary<int, List<CImage>>()
        {
            {
                1, new List<CImage>()
            },
            {
                2, new List<CImage>()
            },
            {
                3, new List<CImage>()
            },
            {
                4, new List<CImage>()
                {
                    new CImage("overlay-no-arms-tan.png", ImageType.Temperature),
                    new CImage("overlay-arms-down-tan.png", ImageType.Temperature)
                }
            },
            {
                4 + IMAGE_OFFSET_SLEEPING, new List<CImage>()
                {
                    new CImage("overlay-sleeping-no-arms-tan.png", ImageType.Temperature),
                    new CImage("overlay-sleeping-arms-down-tan.png", ImageType.Temperature)
                }
            },
            {
                4 + IMAGE_OFFSET_NOISE, new List<CImage>()
                {
                    new CImage("overlay-no-arms-tan.png", ImageType.Temperature),
                    new CImage("overlay-arms-up-tan.png", ImageType.Temperature)
                }
            },
            {
                4 + IMAGE_OFFSET_SLEEPING_NOISE, new List<CImage>()
                {
                    new CImage("overlay-sleeping-no-arms-tan.png", ImageType.Temperature),
                    new CImage("overlay-sleeping-arms-up-tan.png", ImageType.Temperature)
                }
            },
            {
                5, new List<CImage>()
                {
                    new CImage("overlay-no-arms-sunburn.png", ImageType.Temperature),
                    new CImage("overlay-arms-down-sunburn.png", ImageType.Temperature)
                }
            },
            {
                5 + IMAGE_OFFSET_SLEEPING, new List<CImage>()
                {
                    new CImage("overlay-sleeping-no-arms-sunburn.png", ImageType.Temperature),
                    new CImage("overlay-sleeping-arms-down-sunburn.png", ImageType.Temperature)
                }
            },
            {
                5 + IMAGE_OFFSET_NOISE, new List<CImage>()
                {
                    new CImage("overlay-no-arms-sunburn.png", ImageType.Temperature),
                    new CImage("overlay-arms-up-sunburn.png", ImageType.Temperature)
                }
            },
            {
                5 + IMAGE_OFFSET_SLEEPING_NOISE, new List<CImage>()
                {
                    new CImage("overlay-sleeping-no-arms-sunburn.png", ImageType.Temperature),
                    new CImage("overlay-sleeping-arms-up-sunburn.png", ImageType.Temperature)
                }
            },
        };

        //Done
        public static Dictionary<int, List<CImage>> LIGHT_IMAGES = new Dictionary<int, List<CImage>>()
        {
            {
                1, new List<CImage>()
                {
                    new CImage("overlay-darkness.png", ImageType.Light)
                }
            },
            {
                2, new List<CImage>()
            },
            {
                3, new List<CImage>()
            },
            {
                4, new List<CImage>()
            },
            {
                5, new List<CImage>()
                {
                    new CImage("overlay-sunglasses.png", ImageType.Light)
                }
            },
            {
                5 + IMAGE_OFFSET_SLEEPING, new List<CImage>()
                {
                    new CImage("overlay-sleeping-sunglasses.png", ImageType.Light)
                }
            }
        };

        //Done
        public static Dictionary<int, List<CImage>> NOISE_IMAGES = new Dictionary<int, List<CImage>>()
        {
            {
                1, new List<CImage>()
                {
                    new CImage("child-arms-down.png", ImageType.Noise)
                }
            },
            {
                1 + IMAGE_OFFSET_SLEEPING, new List<CImage>()
                {
                    new CImage("child-sleeping-arms-down.png", ImageType.Noise)
                }
            },
            {
                2, new List<CImage>()
                {
                    new CImage("child-arms-down.png", ImageType.Noise)
                }
            },
            {
                2 + IMAGE_OFFSET_SLEEPING, new List<CImage>()
                {
                    new CImage("child-sleeping-arms-down.png", ImageType.Noise)
                }
            },
            {
                3, new List<CImage>()
                {
                    new CImage("child-arms-down.png", ImageType.Noise)
                }
            },
            {
                3 + IMAGE_OFFSET_SLEEPING, new List<CImage>()
                {
                    new CImage("child-sleeping-arms-down.png", ImageType.Noise)
                }
            },
            {
                4, new List<CImage>()
                {
                    new CImage("child-arms-down.png", ImageType.Noise)
                }
            },
            {
                4 + IMAGE_OFFSET_SLEEPING, new List<CImage>()
                {
                    new CImage("child-sleeping-arms-up.png", ImageType.Noise)
                }
            },
            {
                5, new List<CImage>()
                {
                    new CImage("overlay-earmuffs.png", ImageType.Noise),
                    new CImage("child-sleeping-arms-down.png", ImageType.Noise)
                }
            },
            {
                5 + IMAGE_OFFSET_SLEEPING, new List<CImage>()
                {
                    new CImage("overlay-earmuffs-sleeping.png", ImageType.Noise),
                    new CImage("child-sleeping-arms-down.png", ImageType.Noise)
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
