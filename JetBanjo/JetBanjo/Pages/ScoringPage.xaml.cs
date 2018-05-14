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
            new ScoreViewObj(new List<ScoreCausation>(){new ScoreCausation("temphum", 100, "TooHot")}, 100),
            new ScoreViewObj(new List<ScoreCausation>(){new ScoreCausation("temphum", 100, "TooHot")}, 100),
            new ScoreViewObj(new List<ScoreCausation>(){new ScoreCausation("temphum", 100, "TooHot")}, 100),
            new ScoreViewObj(new List<ScoreCausation>(){new ScoreCausation("temphum", 100, "TooHot")}, 100),
            new ScoreViewObj(new List<ScoreCausation>(){new ScoreCausation("temphum", 100, "TooHot")}, 100),
            new ScoreViewObj(new List<ScoreCausation>(){new ScoreCausation("temphum", 100, "TooHot")}, 100),
        };

        public ScoringPage()
		{
			InitializeComponent();
            scoreListView.ItemsSource = alternative;

            //Event on clicking item in listview
            scoreListView.ItemSelected += (sender, e) =>
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

                DependencyService.Get<IDisplayService>().ShowDialog("Causation", causationString);


                scoreListView.SelectedItem = null;
            };


            logic = new ScorePageLogic(this);
            Device.StartTimer(new TimeSpan(0, 0, 5), () => OnTimer());
        }

        private bool OnTimer()
        {
            Task.Run(async () => await RequestScore());
            return true;
        }

        private async Task RequestScore()
        {
            int newScore = 0;
            //List<ScoreViewObj> temp = await logic.GetScore(await ScoreData.Get());
            List<ScoreViewObj> temp = alternative;

            foreach (ScoreViewObj obj in temp)
            {
                newScore += obj.scoreChange;
            }

            scoreListView.ItemsSource = temp;
            gaugePointer.Value = newScore;
            gaugeHeader.Text = newScore.ToString();
            Console.WriteLine("Current score: " + newScore);

            
            UpdateGauge(newScore);
            
        }

        private void UpdateGauge(int score)
        {
            //Clear Gauge
            scales.Clear();

            //New Scale
            Scale scale = new Scale();
            scale.Interval = 100;
            scale.StartValue = 0;
            scale.EndValue = 1000;

            //New header (score)
            Header header = new Header();
            header.Text = score.ToString();
            //scoreGauge.Headers.Clear();
            //scoreGauge.Headers.Add(header);

            //New needle pointer
            NeedlePointer needlePointer = new NeedlePointer();
            needlePointer.Value = score;
            scale.Pointers.Add(needlePointer);

            //Update with new values
            scales.Add(scale);
            //scoreGauge.Scales = scales;
        }
    }
}