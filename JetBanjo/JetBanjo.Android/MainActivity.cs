using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace JetBanjo.Droid
{
    [Activity(Label = "JetBanjo", Icon = "@drawable/icon", Theme = "@style/MyTheme.Splash", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        /// <summary>
        /// Reference to the MainActivity context used in renderes and dependency service implementations
        /// </summary>
        public static Context Context { get; private set; }

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            SetTheme(Resource.Style.MainTheme); //Reset the theme, such that the splash screen theme is not used again

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            Context = this; //Sets the context
            LoadApplication(new App());
        }
    }
}

