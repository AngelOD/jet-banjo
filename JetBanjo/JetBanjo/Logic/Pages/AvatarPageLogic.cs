using JetBanjo.Interfaces.Logic;
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

        private void resetChild()
        {
            highCO2 = false;
            highNoise = false;
        }

        //Classification
        private int Classify(double inputVal, DataRange ranges)
        {
            Console.WriteLine("Type: " + ranges.sensorType + " Var: " + inputVal);
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

        private List<CImage> RetrieveImages(int classification, DataRange range)
        {
            List<CImage> imageList = new List<CImage>();

            int temp = classification;

            if (highCO2 && highNoise)
                temp += Constants.IMAGE_OFFSET_SLEEPING_NOISE;
            else if (highCO2)
                temp += Constants.IMAGE_OFFSET_SLEEPING;
            else if (highNoise)
                temp += Constants.IMAGE_OFFSET_NOISE;

            switch (range.sensorType)
            {
                case ("temp"):
                    if (Constants.TEMP_IMAGES.ContainsKey(temp))
                        imageList.AddRange(Constants.TEMP_IMAGES[temp]);
                    break;
                case ("humid"):
                    if (Constants.HUMID_IMAGES.ContainsKey(temp))
                        imageList.AddRange(Constants.HUMID_IMAGES[temp]);
                    break;
                case ("co2"):
                    if (Constants.CO2_IMAGES.ContainsKey(temp))
                        imageList.AddRange(Constants.CO2_IMAGES[temp]);
                    break;
                case ("uv"):
                    if (Constants.UV_IMAGES.ContainsKey(temp))
                        imageList.AddRange(Constants.UV_IMAGES[temp]);
                    break;
                case ("light"):
                    if (Constants.LIGHT_IMAGES.ContainsKey(temp))
                        imageList.AddRange(Constants.LIGHT_IMAGES[temp]);
                    break;
                case ("noise"):
                    if (Constants.NOISE_IMAGES.ContainsKey(temp))
                        imageList.AddRange(Constants.NOISE_IMAGES[temp]);
                    break;
                case ("voc"):
                    if (Constants.NOISE_IMAGES.ContainsKey(temp))
                        imageList.AddRange(Constants.VOC_IMAGES[temp]);
                    break;
                default:
                    break;
            }

            return imageList;
        }

        public async Task<List<CImage>> GetAvatar(SensorData sensorData, DateTime dateTime)
        {
            Task<List<CImage>> t = Task.Run<List<CImage>>(() =>
            {
                List<CImage> images = new List<CImage>();
                int humidClass;

                if (Constants.WINTER_MONTHS.Contains(dateTime.Month))
                    humidClass = Classify(sensorData.Humidity, Constants.HUMID_WINTER_RANGES);
                else
                    humidClass = Classify(sensorData.Humidity, Constants.HUMID_SUMMER_RANGES);

                int co2Class = Classify(sensorData.CO2, Constants.CO2_RANGES);
                int noiseClass = Classify(sensorData.dB, Constants.NOISE_RANGES);
                int tempClass = Classify(sensorData.Temperature, Constants.TEMP_RANGES);
                int uvClass = Classify(sensorData.UV, Constants.UV_RANGES);
                int lightClass = Classify(sensorData.Lux, Constants.LIGHT_RANGES);
                int vocClass = Classify(sensorData.VOC, Constants.VOC_RANGES);

                if (noiseClass == 4)
                    highNoise = true;
                if (co2Class == 5)
                    highCO2 = true;

                images.AddRange(RetrieveImages(co2Class, Constants.CO2_RANGES));
                images.AddRange(RetrieveImages(noiseClass, Constants.NOISE_RANGES));
                images.AddRange(RetrieveImages(tempClass, Constants.TEMP_RANGES));
                images.AddRange(RetrieveImages(uvClass, Constants.UV_RANGES));
                images.AddRange(RetrieveImages(lightClass, Constants.LIGHT_RANGES));
                images.AddRange(RetrieveImages(humidClass, Constants.HUMID_SUMMER_RANGES));
                images.AddRange(RetrieveImages(vocClass, Constants.VOC_RANGES));
                resetChild();

                images.Add(new CImage("basic-classroom.png", ImageType.Background));
                images.Sort();

                return images;
            });
            return await t;
        }

    }
}
