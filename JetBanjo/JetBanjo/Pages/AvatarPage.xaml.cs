using JetBanjo.Interfaces.Logic;
using JetBanjo.Logic.Pages;
using JetBanjo.Utils.DependencyService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JetBanjo.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AvatarPage : CContentPage
	{
        private IAvatarLogic logic;
        public string RoomName { get; set; } = "Default";

        /*
        private bool swap = true;
        private int currentWarningElements = 0;
        */

        private Dictionary<int, Image> currentWarningImages = new Dictionary<int, Image>();

        public enum AvatarType
        {
            Good, BadTemp, BadAir, BadSound
        };

        public enum WarningType
        {
            GenericWarning, DonF
        };


        public AvatarPage()
        {
            InitializeComponent();
            logic = new AvatarPageLogic();
            AddTGR();

            this.BindingContext = this;

            var image = new Image {
                Source = ImageSource.FromResource("JetBanjo.Resources.donfbred.png"),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };

            BackgroundImage1.Source = ImageSource.FromResource("JetBanjo.Resources.roed.png");
            BackgroundGrid.Children.Add(image, 0, 0);
        }

        /// <summary>
        /// Adds a tap gesture recognizer
        /// </summary>
        private void AddTGR()
        {
            var tgr = new TapGestureRecognizer();
            tgr.Tapped += (s, e) =>
            {
                Tap();
            };
            BackgroundGrid.GestureRecognizers.Add(tgr);
        }
        
        public void ChangeBackgroundImage(int thermalScore, int iaqScore,  int visualScore, int noiseScore)
        {

        }

        public void Tap()
        {
            //Replace with custom popup
            DependencyService.Get<IDisplayService>(DependencyFetchTarget.GlobalInstance).ShowDialog("Hej Christoffer", "How is going?");
        }
    }
}