using JetBanjo.Utils;
using JetBanjo.Web.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JetBanjo.Interfaces.Logic
{
    public interface IAvatarLogic
    {
        /// <summary>
        /// Based on the sensor data, asynchronously returns a list of CImages to be displayed on the avatar page.
        /// </summary>
        /// <param name="sensorData">The retrived sensor data for a room</param>
        /// <param name="dateTime">The current date</param>
        /// <returns>A list of CImages that contains the avatar images</returns>
        Task<List<CImage>> GetAvatar(SensorData sensorData, DateTime dateTime);
    }
}
