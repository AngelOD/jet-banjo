using FFImageLoading.Forms;
using JetBanjo.Resx;
using JetBanjo.Utils;
using JetBanjo.Utils.Data;
using JetBanjo.Web.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace JetBanjo.Logic.Pages
{
	public class IEQIssuesPageLogic
	{
        public List<Tuple<string,CachedImage>> GetIssues(SensorData sensorData, DateTime dateTime)
        {
            Console.WriteLine("GI-0");
            List<Tuple<string, CachedImage>> list = new List<Tuple<string, CachedImage>>();

            int humidClass;

            Console.WriteLine("GI-1");

            //Call the classify method once for each sensor values.
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

            Console.WriteLine("GI-2");

            list.Add(Test(humidClass, Constants.HUMID_SUMMER_RANGES));
            list.Add(Test(co2Class, Constants.HUMID_SUMMER_RANGES));
            list.Add(Test(noiseClass, Constants.HUMID_SUMMER_RANGES));
            list.Add(Test(tempClass, Constants.HUMID_SUMMER_RANGES));
            list.Add(Test(uvClass, Constants.HUMID_SUMMER_RANGES));
            list.Add(Test(lightClass, Constants.HUMID_SUMMER_RANGES));
            list.Add(Test(vocClass, Constants.HUMID_SUMMER_RANGES));

            Console.WriteLine("GI-3");

            return list;
        }

        private Tuple<string, CachedImage> Test(int classification, DataRange range)
        {
            CachedImage image = new CachedImage();
            string text = "";
            //Pick a list of images based on the current sensor parameter and classification
            switch (range.sensorType)
            {
                case ("temp"):
                    if (Constants.TEMP_ICONS.ContainsKey(classification))
                    {
                        image = Constants.TEMP_ICONS[classification];
                        switch (classification)
                        {
                            case 1:
                                text = AppResources.issue_ice;
                                break;
                            case 2:
                                text = AppResources.issue_cold;
                                break;
                            case 4:
                                text = AppResources.issue_sweat;
                                break;
                            case 5:
                                text = AppResources.issue_fire;
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case ("humid"):
                    if (Constants.TEMP_ICONS.ContainsKey(classification))
                    {
                        image = Constants.TEMP_ICONS[classification];
                        switch (classification)
                        {
                            case 1:
                                text = AppResources.issue_ice;
                                break;
                            case 2:
                                text = AppResources.issue_cold;
                                break;
                            case 4:
                                text = AppResources.issue_sweat;
                                break;
                            case 5:
                                text = AppResources.issue_fire;
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case ("co2"):
                    if (Constants.TEMP_ICONS.ContainsKey(classification))
                    {
                        image = Constants.TEMP_ICONS[classification];
                        switch (classification)
                        {
                            case 1:
                                text = AppResources.issue_ice;
                                break;
                            case 2:
                                text = AppResources.issue_cold;
                                break;
                            case 4:
                                text = AppResources.issue_sweat;
                                break;
                            case 5:
                                text = AppResources.issue_fire;
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case ("uv"):

                    break;
                case ("light"):

                    break;
                case ("noise"):

                    break;
                case ("voc"):

                    break;
                default:
                    break;
            }
            Tuple<string, CachedImage> pair = new Tuple<string, CachedImage>(text, image);
            return pair;
        }
	}
}