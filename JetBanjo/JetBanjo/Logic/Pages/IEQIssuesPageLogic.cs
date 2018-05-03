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
        public List<Tuple<string,CImage>> getIssues(SensorData sensorData, DateTime dateTime)
        {
            List<Tuple<string, CImage>> list = new List<Tuple<string, CImage>>();

            int humidClass;

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


            test(humidClass, Constants.HUMID_SUMMER_RANGES);



            return list;
        }

        private void test(int classification, DataRange range)
        {
            //Pick a list of images based on the current sensor parameter and classification
            switch (range.sensorType)
            {
                case ("temp"):
                    
                    break;
                case ("humid"):

                    break;
                case ("co2"):

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
        }
	}
}