using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFImageLoading.Forms;
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
        private IEQIssuesPageLogic logic;

		public IEQIssuesPage ()
		{
			InitializeComponent ();
            logic = new IEQIssuesPageLogic();

            ShowIssues();
        }

        private async Task<List<Tuple<string, CachedImage>>> RequestIssues()
        {
            return logic.GetIssues(await SensorData.Get(), DateTime.Now);
        }

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


        protected override bool OnBackButtonPressed()
        {
            //Pops the popup from the view
            Task.Run(async () => await Navigation.PopPopupAsync());
            return true;
        }

        async void OnDismissButtonClicked(object sender, EventArgs args)
        {
            //Pops the popup from the view
            await Navigation.PopPopupAsync();
        }
    }
}