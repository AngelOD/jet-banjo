using FFImageLoading.Forms;
using JetBanjo.Web.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace JetBanjo.Interfaces.Logic
{
    public interface IIEQIssuesPageLogic
    {
        /// <summary>
        /// Returns a list of tupples that contain the information string and icon
        /// </summary>
        /// <param name="sensorData">The retrived sensor data for a room</param>
        /// <param name="dateTime">The current date</param>
        /// <returns>A list of tuples</returns>
        List<Tuple<string, CachedImage>> GetIssues(SensorData sensorData, DateTime dateTime);
    }
}
