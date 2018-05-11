using JetBanjo.Interfaces.Logic;
using System;
using System.Collections.Generic;
using System.Text;
using JetBanjo.Utils;
using JetBanjo.Utils.Data;
using Xamarin.Forms;
using JetBanjo.Web.Objects;
using System.Threading.Tasks;
using System.Globalization;

namespace JetBanjo.Logic.Pages
{
    /// <summary>
    /// Logic used to pick images to show on the avatar page.
    /// </summary>
    public class AvatarPageLogic : IAvatarLogic
    {
        //Booleans used to indicate if the current set of images should account for high co2 or noise.
        bool highCO2 = false;   
        bool highNoise = false;

        /// <summary>
        /// Based on the sensor data, asynchronously returns a list of CImages to be displayed on the avatar page.
        /// </summary>
        /// <param name="sensorData">The retrived sensor data for a room</param>
        /// <param name="dateTime">The current date</param>
        /// <returns>A list of CImages that contains the avatar images</returns>
        public async Task<List<CImage>> GetAvatar(SensorData sensorData, DateTime dateTime)
        {
            //Start the following as a task such that it can execute asynchronously
            Task<List<CImage>> t = Task.Run<List<CImage>>(() =>
            {
                List<CImage> images = new List<CImage>();
                int humidClass;

                //Call the classify method once for each sensor value.
                if (Constants.WINTER_MONTHS.Contains(dateTime.Month))
                    humidClass = Classifier.Classify(sensorData.Humidity, Constants.HUMID_WINTER_RANGES);
                else
                    humidClass = Classifier.Classify(sensorData.Humidity, Constants.HUMID_SUMMER_RANGES);
                int co2Class = Classifier.Classify(sensorData.CO2, Constants.CO2_RANGES);
                int noiseClass = Classifier.Classify(sensorData.dB, Constants.NOISE_RANGES);
                int tempClass = Classifier.Classify(sensorData.Temperature, Constants.TEMP_RANGES);
                int uvClass = Classifier.Classify(sensorData.UV, Constants.UV_RANGES);
                int lightClass = Classifier.Classify(sensorData.Lux, Constants.LIGHT_RANGES);
                int vocClass = Classifier.Classify(sensorData.VOC, Constants.VOC_RANGES);

                //Determine if the classifications indicate that the child should be sleeping or holding up hands.
                if (noiseClass == 4)
                    highNoise = true;
                if (co2Class == 5)
                    highCO2 = true;

                //Call the RetrieveImages method once for each sensor value classified, and get the corresponding images.
                images.AddRange(RetrieveImages(co2Class, Constants.CO2_RANGES));
                images.AddRange(RetrieveImages(noiseClass, Constants.NOISE_RANGES));
                images.AddRange(RetrieveImages(tempClass, Constants.TEMP_RANGES));
                images.AddRange(RetrieveImages(uvClass, Constants.UV_RANGES));
                images.AddRange(RetrieveImages(lightClass, Constants.LIGHT_RANGES));
                images.AddRange(RetrieveImages(humidClass, Constants.HUMID_SUMMER_RANGES));
                images.AddRange(RetrieveImages(vocClass, Constants.VOC_RANGES));
                ResetChild();

                //Add background to avatar
                images.Add(new CImage("basic-classroom.png", ImageType.Background));
                //Sort the images such that they will overlay eachother in the correct order.
                images.Sort();

                return images;
            });
            return await t; //Asynchronously return the result of t, namely the list of images.
        }


        #region Private methods
        private void ResetChild()
        {
            highCO2 = false;
            highNoise = false;
        }

        /// <summary>
        /// Uses the classification of a single sensor parameter to pick a set of images to show.
        /// Is called once for each parameter.
        /// </summary>
        /// <param name="classification">The classification int</param>
        /// <param name="range">The data range for which the images are selected</param>
        /// <returns>A list of CImages</returns>
        private List<CImage> RetrieveImages(int classification, DataRange range)
        {
            List<CImage> imageList = new List<CImage>();

            int cs = classification;

            //Determine if the avatar should be laying down, holding hands over ears, or both
            if (highCO2 && highNoise)
                cs += Constants.IMAGE_OFFSET_SLEEPING_NOISE;
            else if (highCO2)
                cs += Constants.IMAGE_OFFSET_SLEEPING;
            else if (highNoise)
                cs += Constants.IMAGE_OFFSET_NOISE;

            //Pick a list of images based on the current sensor parameter and classification
            switch (range.sensorType)
            {
                case ("temp"):
                    if (Constants.TEMP_IMAGES.ContainsKey(cs))
                        imageList.AddRange(Constants.TEMP_IMAGES[cs]);
                    break;
                case ("humid"):
                    if (Constants.HUMID_IMAGES.ContainsKey(cs))
                        imageList.AddRange(Constants.HUMID_IMAGES[cs]);
                    break;
                case ("co2"):
                    if (Constants.CO2_IMAGES.ContainsKey(cs))
                        imageList.AddRange(Constants.CO2_IMAGES[cs]);
                    break;
                case ("uv"):
                    if (Constants.UV_IMAGES.ContainsKey(cs))
                        imageList.AddRange(Constants.UV_IMAGES[cs]);
                    break;
                case ("light"):
                    if (Constants.LIGHT_IMAGES.ContainsKey(cs))
                        imageList.AddRange(Constants.LIGHT_IMAGES[cs]);
                    break;
                case ("noise"):
                    if (Constants.NOISE_IMAGES.ContainsKey(cs))
                        imageList.AddRange(Constants.NOISE_IMAGES[cs]);
                    break;
                case ("voc"):
                    if (Constants.VOC_IMAGES.ContainsKey(cs))
                        imageList.AddRange(Constants.VOC_IMAGES[cs]);
                    break;
                default:
                    break;
            }

            return imageList;
        }
        #endregion

    }
}
