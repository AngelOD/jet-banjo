using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using JetBanjo.iOS.Utils;
using JetBanjo.Utils.DependencyService;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(DeviceService))]
namespace JetBanjo.iOS.Utils
{
    public class DeviceService : IDeviceService
    {
        public DeviceOrientation GetScreenOrientation()
        {
            var currentOrientation = UIApplication.SharedApplication.StatusBarOrientation;
            bool isPortrait = currentOrientation == UIInterfaceOrientation.Portrait
                || currentOrientation == UIInterfaceOrientation.PortraitUpsideDown;

            return isPortrait ? DeviceOrientation.PortraitMode : DeviceOrientation.LandscapeMode;
        }

        public bool GetScreenState()
        {
            return AppDelegate.isScreenOn;
        }
    }
}