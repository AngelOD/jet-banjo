using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Taken from https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/dependency-service/device-orientation
/// Used for determining th device orientation
/// </summary>
namespace JetBanjo.Utils.DependencyService
{
    public enum DeviceOrientation
    {
        Undefined,
        Landscape,
        Portrait
    }

    public interface IDeviceOrientationService
    {
        DeviceOrientation GetOrientation();
    }
}
