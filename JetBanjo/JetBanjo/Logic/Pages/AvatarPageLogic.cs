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



        
        public async Task<List<Image>> BuildAvatar(SensorData sensorData)
        {
            //Temp
            


            //Humid

            //CO2

            //UV

            //Light

            //Noise
        }

    }
}
