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

namespace JetBanjo.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ScoringPage : CContentPage
	{
        private IScorePageLogic logic;
        public ListView ScoreList { get; private set; }

		public ScoringPage()
		{
			InitializeComponent();
            InitializeGauge();

            List<ScoreViewObj> objects = new List<ScoreViewObj>
            {
                new ScoreViewObj(new List<ScoreCausation> { new ScoreCausation("Air", 100, "Too Hot!"), new ScoreCausation("Air", 100, "Too Not Hot!") }, 100),
                new ScoreViewObj(new List<ScoreCausation> { new ScoreCausation("Air", 100, "Too Hot!"), new ScoreCausation("Air", 100, "What!") }, 100),
                new ScoreViewObj(new List<ScoreCausation> { new ScoreCausation("Air", 100, "Too Hot!"), new ScoreCausation("Air", 100, "asgas") }, 100),
                new ScoreViewObj(new List<ScoreCausation> { new ScoreCausation("Air", 100, "Too Hot!"), new ScoreCausation("Air", 100, "What can i do!") }, 100),
                new ScoreViewObj(new List<ScoreCausation> { new ScoreCausation("Air", 100, "Too Hot!"), new ScoreCausation("Air", 100, "IDK!") }, 100)
            };

            UpdateScoreList(objects);
            ScoreList = scoreListView;
        }
        public void UpdateScoreList(List<ScoreViewObj> updatedScoreList)
        {
            scoreListView.ItemsSource = updatedScoreList;
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

        private void InitializeGauge() 
        {
            //Initializing circular gauge 
            scoreGauge.Margin = 0;

            //Adding header 
            Header header = new Header();
            header.Text = "Score";
            scoreGauge.Headers.Add(header);

            //Initializing scales for circular gauge
            ObservableCollection<Scale> scales = new ObservableCollection<Scale>();
            Scale scale = new Scale();
            scale.Interval = 100;
            scale.StartValue = 0;
            scale.EndValue = 2000;
            scales.Add(scale);

            //Adding range
            Range range = new Range();
            range.StartValue = 0;
            range.EndValue = 1000;
            range.Color = Color.Red;
            scale.Ranges.Add(range);

            Range range2 = new Range();
            range.StartValue = 1001;
            range.EndValue = 2000;
            range.Color = Color.Green;
            scale.Ranges.Add(range2);

            //Adding needle pointer
            NeedlePointer needlePointer = new NeedlePointer();
            needlePointer.Value = 1000;
            scale.Pointers.Add(needlePointer);

            //Adding range pointer
            RangePointer rangePointer = new RangePointer();
            rangePointer.Value = 60;
            scale.Pointers.Add(rangePointer);

            //Adding marker pointer
            MarkerPointer markerPointer = new MarkerPointer();
            markerPointer.Value = 70;
            scale.Pointers.Add(markerPointer);


            scales.Add(scale);
            scoreGauge.Scales = scales;
        }
    }
}