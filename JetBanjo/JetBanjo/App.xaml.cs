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

        /// <summary>
        /// If the app is in testing mode (Unit test)
        /// </summary>
        public static bool IsTesting { get; set; }

        /// <summary>
        /// The size of the screen that the app is running on
        /// </summary>
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
            SetWidthRequestBasedOnScreenSize();
            MainPage = new NavigationPage(new RoomSelectorPage());
        }

        /// <summary>
        /// Sets the dynamic width of the different UI elements based on the screen size
        /// </summary>
        private void SetWidthRequestBasedOnScreenSize()
        {
            buttonStyle.Setters.Add(new Setter() { Property = VisualElement.WidthRequestProperty, Value = ScreenSize.Width * Constants.BUTTON_SCALE });
            entryStyle.Setters.Add(new Setter() { Property = VisualElement.WidthRequestProperty, Value = ScreenSize.Width * Constants.ENTRY_SCALE });
            labelStyle.Setters.Add(new Setter() { Property = VisualElement.WidthRequestProperty, Value = ScreenSize.Width * Constants.LABEL_SCALE });
            listStyle.Setters.Add(new Setter() { Property = VisualElement.WidthRequestProperty, Value = ScreenSize.Width * Constants.LIST_SCALE });
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
            MasterPage.Register(typeof(AvatarPage), AppResources.avatar);
            MasterPage.Register(typeof(InfoPage), AppResources.infopage);
	    MasterPage.Register(typeof(ScoringPage), AppResources.scoring_page);
	    MasterPage.Register(typeof(LeaderboardPage), AppResources.leaderboard);
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
