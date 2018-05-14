using JetBanjo.Interfaces.Logic;
using JetBanjo.Utils.Data;
using JetBanjo.Utils.DependencyService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.SfGauge.XForms;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using JetBanjo.Web.Objects;
using JetBanjo.Logic.Pages;
using JetBanjo.Resx;
using JetBanjo.Utils;

namespace JetBanjo.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LeaderboardPage : CContentPage
    {
        private ILeaderBoardPageLogic logic;

        public LeaderboardPage()
        {
            InitializeComponent();

            logic = new LeaderboardPageLogic();

            //Sets event when we click an element in the listview
            leaderboardListView.ItemSelected += OnClickListView;

            //Updates leaderboard every 10 minutes (Or when we open page)
            Device.StartTimer(new TimeSpan(0, 10, 0), () => OnTimer()); 
        }

        /// <summary>
        /// Deselects item in listview whenever we select one (just so we have no highlighting)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void OnClickListView(object sender, EventArgs args)
        {
            if (leaderboardListView.SelectedItem == null)
                return;
            leaderboardListView.SelectedItem = null;
        }

        /// <summary>
        /// Whenever we open the page, we asynchronously request new data on the main thread.
        /// </summary>
        protected override void OnAppearing()
        {
            Device.BeginInvokeOnMainThread(async () => await RequestLeaderboard());
            base.OnAppearing();
        }

        /// <summary>
        /// Requests data for leaderboard every 10 min.
        /// </summary>
        /// <returns></returns>
        private bool OnTimer()
        {
            Task.Run(async () => await RequestLeaderboard());
            return true;
        }

        /// <summary>
        /// Retrieves a list of rooms and their scores, sorts the list, and presents it in the listview.
        /// </summary>
        /// <returns></returns>
        private async Task RequestLeaderboard()
        {
            List<Room> sortedList = await logic.GetLeaderboard();
            leaderboardListView.ItemsSource = sortedList;
        }
    }
}