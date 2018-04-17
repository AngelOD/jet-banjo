using JetBanjo.Interfaces.Logic;
using JetBanjo.Logic.Sensor;
using System;
using System.Collections.Generic;
using System.Text;
using JetBanjo.Utils;
using Xamarin.Forms;
using JetBanjo.Web.Objects;
using System.Threading.Tasks;
using System.Globalization;

namespace JetBanjo.Logic.Pages
{
    public class AvatarPageLogic : IAvatarLogic
    {
        bool highCO2 = false;
        bool highNoise = false;

        private void reset()
        {
            highCO2 = false;
            highNoise = false;
        }

        //Classification
        private int Classify(double inputVal, DataRange ranges)
        {
            if (inputVal < ranges.minimum)
                return 1;
            else if (inputVal < ranges.lower)
                return 2;
            else if (inputVal < ranges.higher)
                return 3;
            else if (inputVal < ranges.maximum)
                return 4;
            else if (inputVal > ranges.maximum)
                return 5;
            else
                return -1;
        }

        private List<CImage> ChooseImage(int classification, DataRange ranges)
        {
            List<CImage> images = new List<CImage>();

            //temp, humid, co2, uv, light, noise
            if(ranges.sensorType.Equals("temp"))
            {
                switch (classification)
                {
                    case 1:
                        images.Add(new CImage("overlay-frozen.png", ImageType.Temperature));
                        break;
                    case 2:
                        images.Add(new CImage("overlay-cold.png", ImageType.Temperature));
                        break;
                    case 3:
                        //Nothing
                        break;
                    case 4:
                        images.Add(new CImage("overlay-sweat.png", ImageType.Temperature));
                        break;
                    case 5:
                        images.Add(new CImage("overlay-fire-no-arms.png", ImageType.Temperature));
                        break;
                    default:
                        //Nothing
                        break;
                }
            }
            else if (ranges.sensorType.Equals("humid"))
            {

            }
            else if (ranges.sensorType.Equals("co2"))
            {
                switch (classification)
                {
                    case 1:
                        images.Add(new CImage("overlay-frozen.png", ImageType.CO2));
                        break;
                    case 2:
                        images.Add(new CImage("overlay-cold.png", ImageType.CO2));
                        break;
                    case 3:
                        //Nothing
                        break;
                    case 4:
                        images.Add(new CImage("", ImageType.CO2));
                        break;
                    case 5:
                        images.Add(new CImage("overlay-fire-no-arms.png", ImageType.CO2));
                        break;
                    default:
                        //Nothing
                        break;
                }
            }
            else if (ranges.sensorType.Equals("uv"))
            {

            }
            else if (ranges.sensorType.Equals("light"))
            {

            }
            else if (ranges.sensorType.Equals("noise"))
            {

            }
        }
                
        public async Task<List<Image>> BuildAvatar(SensorData sensorData)
        {
            List<CImage> images = new List<CImage>();


            int co2Class = Classify(sensorData.CO2, Constants.CO2_RANGES);
            int noiseClass = Classify(sensorData.dB, Constants.NOISE_RANGES);



            //Temp



            //Humid

            //CO2

            //UV

            //Light

            //Noise7

        }

    }
}
