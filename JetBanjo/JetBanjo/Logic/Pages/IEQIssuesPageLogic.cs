using FFImageLoading.Forms;
using JetBanjo.Interfaces.Logic;
using JetBanjo.Resx;
using JetBanjo.Utils;
using JetBanjo.Utils.Data;
using JetBanjo.Web.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JetBanjo.Logic.Pages
{
	public class IEQIssuesPageLogic : IIEQIssuesPageLogic
	{
        /// <summary>
        /// Returns a list of tupples that contain the information string and icon
        /// </summary>
        /// <param name="sensorData">The retrived sensor data for a room</param>
        /// <param name="dateTime">The current date</param>
        /// <returns>A list of tuples</returns>

        int tempClass;



        public List<Tuple<string,CachedImage>> GetIssues(SensorData sensorData, DateTime dateTime)
        {
            List<Tuple<string, CachedImage>> list = new List<Tuple<string, CachedImage>>();

            int humidClass;

            //Call the classify method once for each sensor values.
            if (Constants.WINTER_MONTHS.Contains(dateTime.Month))
                humidClass = Classifier.Classify(sensorData.Humidity, Constants.HUMID_WINTER_RANGES);
            else
                humidClass = Classifier.Classify(sensorData.Humidity, Constants.HUMID_SUMMER_RANGES);
            int co2Class = Classifier.Classify(sensorData.CO2, Constants.CO2_RANGES);
            int noiseClass = Classifier.Classify(sensorData.dB, Constants.NOISE_RANGES);
                tempClass = Classifier.Classify(sensorData.Temperature, Constants.TEMP_RANGES);
            int uvClass = Classifier.Classify(sensorData.UV, Constants.UV_RANGES);
            int lightClass = Classifier.Classify(sensorData.Lux, Constants.LIGHT_RANGES);
            int vocClass = Classifier.Classify(sensorData.VOC, Constants.VOC_RANGES);

            list.Add(Merger(humidClass, Constants.HUMID_SUMMER_RANGES));
            list.Add(Merger(co2Class, Constants.CO2_RANGES));
            list.Add(Merger(noiseClass, Constants.NOISE_RANGES));
            list.Add(Merger(tempClass, Constants.TEMP_RANGES));
            list.Add(Merger(uvClass, Constants.UV_RANGES));
            list.Add(Merger(lightClass, Constants.LIGHT_RANGES));
            list.Add(Merger(vocClass, Constants.VOC_RANGES));

            return list;
        }

        #region Private methods
        /// <summary>
        /// Merger that based on the classification and the range sets the icon and text
        /// </summary>
        /// <param name="classification">The classification int</param>
        /// <param name="range">The data range for which the images are selected</param>
        /// <returns>A Tuple of a information string and a icon</returns>
        private Tuple<string, CachedImage> Merger(int classification, DataRange range)
        {
            CachedImage image = new CachedImage();
            string text = "";
            
            //Pick a list of images based on the current sensor parameter and classification
            switch (range.SensorType)
            {
                case ("temp"):
                    if (Constants.TEMP_ICONS.ContainsKey(classification))
                    {
                        image = Constants.TEMP_ICONS[classification];
                        switch (classification)
                        {
                            case 1:
                                text = AppResources.issue_temp_ice;
                                break;
                            case 2:
                                text = AppResources.issue_temp_cold;
                                break;
                            case 4:
                                text = AppResources.issue_temp_sweat;
                                break;
                            case 5:
                                text = AppResources.issue_temp_fire;
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case ("humid"):
                    if (Constants.HUM_ICONS.ContainsKey(classification))
                    {
                        image = Constants.HUM_ICONS[classification];
                        switch (classification)
                        {
                            case 1:
                                if(tempClass == 5)
                                {
                                    text = AppResources.issue_hum_dry_temp_high;
                                }
                                else if(tempClass == 1)
                                {
                                    text = AppResources.issue_hum_dry_temp_low;
                                }
                                else text = AppResources.issue_hum_dry;
                                break;
                            case 5:
                                if (tempClass == 5)
                                {
                                    text = AppResources.issue_hum_wet_temp_high;
                                }
                                else if (tempClass == 1)
                                {
                                    text = AppResources.issue_hum_wet_temp_low;
                                }
                                else text = AppResources.issue_hum_wet;
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case ("co2"):
                    if (Constants.CO2_ICONS.ContainsKey(classification))
                    {
                        image = Constants.CO2_ICONS[classification];
                        switch (classification)
                        {
                            case 4:
                                text = AppResources.issue_co2_soft;
                                break;
                            case 5:
                                text = AppResources.issue_co2_severe;
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case ("uv"):
                    if (Constants.UV_ICONS.ContainsKey(classification))
                    {
                        image = Constants.UV_ICONS[classification];
                        switch (classification)
                        {
                            case 4:
                                text = AppResources.issue_uv_what;
                                break;
                            case 5:
                                text = AppResources.issue_uv_what;
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case ("light"):
                    if (Constants.LIGHT_ICONS.ContainsKey(classification))
                    {
                        image = Constants.LIGHT_ICONS[classification];
                        switch (classification)
                        {
                            case 1:
                                text = AppResources.issue_light_dark;
                                break;
                            case 5:
                                text = AppResources.issue_light_bright;
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case ("noise"):
                    if (Constants.NOISE_ICONS.ContainsKey(classification))
                    {
                        image = Constants.NOISE_ICONS[classification];
                        switch (classification)
                        {
                            case 4:
                                text = AppResources.issue_noise;
                                break;
                            case 5:
                                text = AppResources.issue_noise;
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case ("voc"):
                    if (Constants.VOC_ICONS.ContainsKey(classification))
                    {
                        image = Constants.VOC_ICONS[classification];
                        switch (classification)
                        {
                            case 4:
                                text = AppResources.issue_voc;
                                break;
                            case 5:
                                text = AppResources.issue_voc;
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }
            Tuple<string, CachedImage> pair = new Tuple<string, CachedImage>(text, image);
            return pair;
        }
        #endregion
    }
}