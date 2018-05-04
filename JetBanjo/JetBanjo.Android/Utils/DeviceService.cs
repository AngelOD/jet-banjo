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

[assembly: Xamarin.Forms.Dependency(typeof(DeviceService))]
namespace JetBanjo.Droid.Utils
{
    public class DeviceService : IDeviceService
    {
        public DeviceOrientation GetScreenOrientation()
        {
            IWindowManager windowManager = Application.Context.GetSystemService(Context.WindowService).JavaCast<IWindowManager>();

            var rotation = windowManager.DefaultDisplay.Rotation;
            bool isLandscape = rotation == SurfaceOrientation.Rotation90 || rotation == SurfaceOrientation.Rotation270;
            return isLandscape ? DeviceOrientation.LandscapeMode : DeviceOrientation.PortraitMode;
        }

        public bool GetScreenState()
        {
            PowerManager pm = (PowerManager)Application.Context.GetSystemService(Context.PowerService);
            return pm.IsInteractive;
        }
    }
}