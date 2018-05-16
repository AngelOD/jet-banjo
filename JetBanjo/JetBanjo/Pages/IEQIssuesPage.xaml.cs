using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFImageLoading.Forms;
using JetBanjo.Interfaces.Logic;
using JetBanjo.Logic.Pages;
using JetBanjo.Utils;
using JetBanjo.Web.Objects;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JetBanjo.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IEQIssuesPage : PopupPage
	{
        private IIEQIssuesPageLogic logic;
        private string currentRoomId;

		public IEQIssuesPage (string roomId)
		{
			InitializeComponent ();
            logic = new IEQIssuesPageLogic();
            currentRoomId = roomId;

            ShowIssues();
        }

        /// <summary>
        /// Returns a list of tupples that contain the information string and icon
        /// </summary>
        /// <param name="sensorData">The retrived sensor data for a room</param>
        /// <param name="dateTime">The current date</param>
        /// <returns>A list of tuples</returns>
        public void ShowIssues()
        {
            List<Tuple<string, CachedImage>> list = Task.Run(async () => await RequestIssues()).Result;

            foreach (Tuple<string, CachedImage> item in list)
            {
                if (!String.IsNullOrEmpty(item.Item1))
                {
                    //Creates a horizontal stacklayout that can holds the image and text
                    StackLayout hStackLayout = new StackLayout()
                    {
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Spacing = 10
                    };

                    hStackLayout.Children.Add(item.Item2);  //Adds the image to the stacklayout

                    Label issue = new Label()
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Text = item.Item1
                    };

                    hStackLayout.Children.Add(issue); //Adds the label to the stacklayout
                    layout.Children.Add(hStackLayout); //Adds the horizontal stacklayout to the vertical stacklayout
                    TapGestureRecognizer gestureRecognizer = new TapGestureRecognizer(); 
                    gestureRecognizer.Tapped += (s, arg) => OnBackButtonPressed();
                    layout.GestureRecognizers.Add(gestureRecognizer); //Adds such that when the outer stacklayout is tapped it fires the OnBackButtonPressed
                }
            }
        }


        /// <summary>
        /// Dismisses the dialog
        /// </summary>
        /// <returns></returns>
        protected override bool OnBackButtonPressed()
        {
            //Pops the popup from the view
            Task.Run(async () => await Navigation.PopPopupAsync());
            return true;
        }

        #region Private methods
        /// <summary>
        /// Dismisses the dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private async void OnDismissButtonClicked(object sender, EventArgs args)
        {
            //Pops the popup from the view
            await Navigation.PopPopupAsync();
        }

        /// <summary>
        /// Gets the issuses from the sensor data.
        /// </summary>
        /// <returns>A list of icons and information</returns>
        private async Task<List<Tuple<string, CachedImage>>> RequestIssues()
        {
            return logic.GetIssues(await SensorData.Get(currentRoomId), DateTime.Now);
        }
        #endregion
    }
}