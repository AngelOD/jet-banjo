using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using JetBanjo.iOS.Utils;
using JetBanjo.Utils.DependencyService;
using UIKit;

/// <summary>
/// Taken from https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/dependency-service/device-orientation
/// Used for determining th device orientation
/// </summary>
[assembly: Xamarin.Forms.Dependency(typeof(DeviceOrientationService))]
namespace JetBanjo.iOS.Utils
{
    public class DeviceOrientationService : IDeviceOrientationService
    {
        public DeviceOrientation GetOrientation()
        {
            var currentOrientation = UIApplication.SharedApplication.StatusBarOrientation;
            bool isPortrait = currentOrientation == UIInterfaceOrientation.Portrait
                || currentOrientation == UIInterfaceOrientation.PortraitUpsideDown;

            return isPortrait ? DeviceOrientation.Portrait : DeviceOrientation.Landscape;
        }
    }
}