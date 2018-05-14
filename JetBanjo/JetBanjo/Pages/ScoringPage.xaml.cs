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
        ObservableCollection<Scale> scales = new ObservableCollection<Scale>();
        List<ScoreViewObj> source = new List<ScoreViewObj>();

        //Mock data
        List<ScoreViewObj> alternative = new List<ScoreViewObj>()
        {
            new ScoreViewObj(new List<ScoreCausation>(){new ScoreCausation("temphum", 100, "TooHot")}, 100, DateTime.Now),
            new ScoreViewObj(new List<ScoreCausation>(){new ScoreCausation("temphum", 100, "TooHot")}, 100, DateTime.Now),
            new ScoreViewObj(new List<ScoreCausation>(){new ScoreCausation("temphum", 100, "TooHot")}, 100, DateTime.Now),
            new ScoreViewObj(new List<ScoreCausation>(){new ScoreCausation("temphum", 100, "TooHot")}, 100, DateTime.Now),
            new ScoreViewObj(new List<ScoreCausation>(){new ScoreCausation("temphum", 100, "TooHot")}, 100, DateTime.Now),
            new ScoreViewObj(new List<ScoreCausation>(){new ScoreCausation("temphum", 100, "TooHot")}, 100, DateTime.Now)
        };

        public ScoringPage()
		{
			InitializeComponent();
            scoreLabel.WidthRequest = App.ScreenSize.Width;
            eventLabel.Text = AppResources.measurements + ":";

            scoreListView.ItemsSource = alternative;

            //Event on clicking item in listview
            scoreListView.ItemSelected += OnClickListView;


            logic = new ScorePageLogic(this);
            Device.StartTimer(new TimeSpan(0, 10, 0), () => OnTimer());
        }

        protected override void OnAppearing()
        {
            Device.BeginInvokeOnMainThread(async () => await RequestScore());
            base.OnAppearing();
        }

        private bool OnTimer()
        {
            Task.Run(async () => await RequestScore());
            return true;
        }

        private void OnClickListView(object sender, EventArgs args)
        {
            if (scoreListView.SelectedItem == null)
                return;


            var list = sender as ListView;
            var selectedItem = list?.SelectedItem;
            ScoreViewObj viewObj = selectedItem as ScoreViewObj;

            string causationString = "";

            foreach (ScoreCausation cause in viewObj.causations)
            {
                causationString += cause.ToString() + "\n";
            }

            DependencyService.Get<IDisplayService>().ShowDialog(AppResources.causation + ":", causationString);


            scoreListView.SelectedItem = null;
        }

        private async Task RequestScore()
        {
            int newScore = 0;
            List<ScoreViewObj> temp = await logic.GetScore(await ScoreData.Get()); //Actual data
            //List<ScoreViewObj> temp = alternative; //Mock data

            foreach (ScoreViewObj obj in temp)
            {
                newScore += obj.scoreChange;
            }

            scoreLabel.Text = newScore.ToString() + " / " + temp.Count * Constants.MAX_SCORE_PER_HOUR;
            scoreListView.ItemsSource = temp;
        }
    }
}