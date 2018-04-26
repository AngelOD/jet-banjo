using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using JetBanjo.Droid.Utils;
using JetBanjo.Utils.DependencyService;

/// <summary>
/// Taken from https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/dependency-service/device-orientation
/// Used for determining th device orientation
/// </summary>
[assembly: Xamarin.Forms.Dependency(typeof(DeviceOrientationService))]
namespace JetBanjo.Droid.Utils
{
    public class DeviceOrientationService : IDeviceOrientationService
    {
        public DeviceOrientation GetOrientation()
        {
            IWindowManager windowManager = Application.Context.GetSystemService(Context.WindowService).JavaCast<IWindowManager>();

            var rotation = windowManager.DefaultDisplay.Rotation;
            bool isLandscape = rotation == SurfaceOrientation.Rotation90 || rotation == SurfaceOrientation.Rotation270;
            return isLandscape ? DeviceOrientation.Landscape : DeviceOrientation.Portrait;
        }
    }
}