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
        DeviceOrientation GetScreenOrientation();

        bool GetScreenState();
    }

}
