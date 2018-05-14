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
	public partial class ScoringPage : CContentPage
	{
        private IScorePageLogic logic;

        public ScoringPage()
		{
			InitializeComponent();
            scoreLabel.WidthRequest = App.ScreenSize.Width; //Set width of label showing current score
            eventLabel.Text = AppResources.measurements + ":"; //Set text of label above listview

            //Event on clicking item in listview
            scoreListView.ItemSelected += OnClickListView;


            logic = new ScorePageLogic();
            Device.StartTimer(new TimeSpan(0, 10, 0), () => OnTimer()); //Every 10 min refresh data.
        }

        /// <summary>
        /// Whenever we show the page, we request new data.
        /// </summary>
        protected override void OnAppearing()
        {
            Device.BeginInvokeOnMainThread(async () => await RequestScore());
            base.OnAppearing();
        }

        /// <summary>
        /// Every 10 min (defined by timer) get new data
        /// </summary>
        /// <returns>Always true (useless)</returns>
        private bool OnTimer()
        {
            Task.Run(async () => await RequestScore());
            return true;
        }

        /// <summary>
        /// Whenever we click an item in the listview, we show a popup with the causes that has resulted in this score.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="args">arguments</param>
        private void OnClickListView(object sender, EventArgs args)
        {
            //If no item is selected (somehow), we simply return.
            if (scoreListView.SelectedItem == null)
                return;

            //Set viewObj to be the selected item in the listView
            var list = sender as ListView;
            var selectedItem = list?.SelectedItem;
            ScoreViewObj viewObj = selectedItem as ScoreViewObj;

            //String containing the combined causations.
            string causationString = "";

            //For each causation, we concatenate the cause into a new line in the string.
            foreach (ScoreCausation cause in viewObj.causations)
            {
                causationString += cause.ToString() + "\n";
            }

            //Show dialog (popup) with the causations.
            DependencyService.Get<IDisplayService>().ShowDialog(AppResources.causation + ":", causationString);

            //Reset the selection in the listview.
            scoreListView.SelectedItem = null;
        }

        /// <summary>
        /// Get new data and update listview with new list of ScoreViewObjs
        /// </summary>
        /// <returns></returns>
        private async Task RequestScore()
        {
            int newScore = 0;
            List<ScoreViewObj> temp = logic.GetScore(await ScoreData.GetList()); //Get data from serer for current room

            //Combine scores into a total score
            foreach (ScoreViewObj obj in temp)
            {
                newScore += obj.ScoreChange;
            }

            //Update score label to new current score
            scoreLabel.Text = newScore.ToString() + " / " + temp.Count * Constants.MAX_SCORE_PER_HOUR;
            //Set itemsource for listview to be new data
            scoreListView.ItemsSource = temp;
        }
    }
}