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
        private ScorePageLogic scorePageLogic;
        public ListView ScoreList { get; private set; }
        ObservableCollection<Scale> scales = new ObservableCollection<Scale>();

        public ScoringPage()
		{
			InitializeComponent();
            Device.StartTimer(new TimeSpan(0, 0, 5), () => OnTimer());
            ScoreList = scoreListView;
            scorePageLogic = new ScorePageLogic(this);
        }

        private bool OnTimer()
        {
            Task.Run(async () => await RequestScore());
            return true;
        }

        private async Task RequestScore()
        {
            int newScore = 0;
            List<ScoreViewObj> temp = await logic.GetScore(await ScoreData.Get());

            foreach (ScoreViewObj obj in temp)
            {
                if (obj.scoreChange > newScore)
                    newScore = obj.scoreChange;
            }
            UpdateScoreList(temp);
            UpdateGauge(newScore);
            
        }

        private void UpdateScoreList(List<ScoreViewObj> updatedScoreList)
        {
            scoreListView.ItemsSource = updatedScoreList;
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
            scoreGauge.Headers.Clear();
            scoreGauge.Headers.Add(header);

            //New needle pointer
            NeedlePointer needlePointer = new NeedlePointer();
            needlePointer.Value = score;
            scale.Pointers.Add(needlePointer);

            //Update with new values
            scales.Add(scale);
            scoreGauge.Scales = scales;
        }

        public void OnItemSelected(object sender, EventArgs args)
        {
            var list = sender as ListView;
            var selectedItem = list?.SelectedItem;
            ScoreViewObj viewObj = selectedItem as ScoreViewObj;

            string causationString = "";

            foreach (ScoreCausation cause in viewObj.causations)
            {
                causationString += cause.ToString() + "\n";
            }

            DependencyService.Get<IDisplayService>().ShowDialog("Causation", causationString);
        }
    }
}