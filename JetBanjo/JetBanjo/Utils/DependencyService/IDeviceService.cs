using System;
using System.Collections.Generic;
using System.Text;

namespace JetBanjo.Utils.DependencyService
{
    public enum DeviceOrientation
    {
        Undefined,
        LandscapeMode,
        PortraitMode
    }

    public interface IDeviceService
    {
        /// <summary>
        /// Gets the orientation of the screen
        /// </summary>
        /// <returns>Returns the screen orientation</returns>
        DeviceOrientation GetScreenOrientation();

        /// <summary>
        /// Returns true if the screen is on
        /// </summary>
        /// <returns></returns>
        bool GetScreenState();
    }

}
