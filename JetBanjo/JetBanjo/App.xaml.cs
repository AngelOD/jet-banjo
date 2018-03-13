using JetBanjo.Logic.Pages;
using JetBanjo.Resx;
using JetBanjo.Utils;
using JetBanjo.Pages;
using JetBanjo.Pages.MasterDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace JetBanjo
{
	public partial class App : Application
	{

        private Master Master { get; set; }

		public App ()
		{
			InitializeComponent();

            // This lookup NOT required for Windows platforms - the Culture will be automatically set
            if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
            {
                // determine the correct, supported .NET culture
                var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
                Resx.AppResources.Culture = ci; // set the RESX for resource localization
                DependencyService.Get<ILocalize>().SetLocale(ci); // set the Thread for locale-aware methods
            }
            Master = new Master();
            RegisterMenuItems();
            MainPage = Master;
		}

        /// <summary>
        /// Registers the pages to the MasterDetail menu
        /// </summary>
        private void RegisterMenuItems()
        {
            Master.Register(new MainPage(new MainPageLogic()), AppResources.home);
            Master.Register(new AvatarPage(new AvatarPageLogic(), "Room E10123"), AppResources.avatar);
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
