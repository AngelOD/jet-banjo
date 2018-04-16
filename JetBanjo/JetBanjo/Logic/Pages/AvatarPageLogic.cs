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
            if(ranges.sensorType.Equals("co2"))
            {
                switch (classification)
                {
                    case 1:
                        images.Add(new CImage(""));
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    default:
                        break;
                }
            }
            else if (ranges.sensorType.Equals("humid"))
            {

            }
            else if (ranges.sensorType.Equals("co2"))
            {

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


            int tempClass = Classify(sensorData.Temperature, Constants.TEMP_RANGES);
            if(sensorData.Temperature)


            //Temp
            


            //Humid

            //CO2

            //UV

            //Light

            //Noise7
            
        }

    }
}
