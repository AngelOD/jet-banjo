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
            Device.StartTimer(new TimeSpan(0, 10, 0), () => OnTimer());
        }

        private void OnClickListView(object sender, EventArgs args)
        {
            if (leaderboardListView.SelectedItem == null)
                return;
            leaderboardListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            Device.BeginInvokeOnMainThread(async () => await RequestLeaderboard());
            base.OnAppearing();
        }

        private bool OnTimer()
        {
            Task.Run(async () => await RequestLeaderboard());
            return true;
        }

        private async Task RequestLeaderboard()
        {
            List<Room> temp = await Room.GetList(); //Actual data
            List<Room> sortedList = temp.OrderByDescending(o => o.Score).ToList();
            leaderboardListView.ItemsSource = sortedList;
        }
    }
}