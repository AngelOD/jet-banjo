using JetBanjo.Logic.Pages;
using JetBanjo.Resx;
using JetBanjo.Utils.DependencyService;
using JetBanjo.Pages;
using JetBanjo.Pages.MasterDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using JetBanjo.Utils;

namespace JetBanjo
{
	public partial class App : Application
	{
        /// <summary>
        /// The Master page from the MasterDetail menu
        /// </summary>
        public Master MasterPage { get; private set; }

        public static Size ScreenSize { get; set; }

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
 
            MainPage = new NavigationPage(new RoomSelectorPage()); 
		}

        /// <summary>
        /// Changes the apps current MainPage (the one being shown) to the MasterDetailMenu
        /// </summary>
        public void ChangeToMasterMenu()
        {
            MasterPage = new Master();
            RegisterMenuItems();
            MainPage = MasterPage;
        }


        /// <summary>
        /// Registers the pages to the MasterDetail menu
        /// </summary>
        private void RegisterMenuItems()
        {
            MasterPage.Register(typeof(DonAvatarPage), AppResources.avatar);
            MasterPage.Register(new Settings(), AppResources.settings);
        }

		protected override void OnStart ()
		{
            // Handle when your app starts
            DependencyService.Get<INetworkDiscovery>(DependencyFetchTarget.GlobalInstance).OnAppStart();

        }

		protected override void OnSleep ()
		{
            // Handle when your app sleeps
            DependencyService.Get<INetworkDiscovery>(DependencyFetchTarget.GlobalInstance).OnAppStop();

        }

		protected override void OnResume ()
		{
            // Handle when your app resumes
            DependencyService.Get<INetworkDiscovery>(DependencyFetchTarget.GlobalInstance).OnAppStart();

        }
	}
}
