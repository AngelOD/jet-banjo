using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFImageLoading.Forms;
using JetBanjo.Logic.Pages;
using JetBanjo.Utils;
using JetBanjo.Web.Objects;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JetBanjo.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IEQIssuesPage : CContentPage
	{
        private IEQIssuesPageLogic logic;

        private List<Tuple<string, CachedImage>> list;

		public IEQIssuesPage ()
		{
			InitializeComponent ();
            logic = new IEQIssuesPageLogic();

            ShowIssues();
        }

        private async Task RequestIssues()
        {
            list = await logic.GetIssues(await SensorData.Get(), DateTime.Now);
        }

        public void ShowIssues()
        {
            Task.Run(async () => await RequestIssues()).Wait();

            foreach (Tuple<string, CachedImage> item in list)
            {
                if (!String.IsNullOrEmpty(item.Item1))
                {
                    StackLayout hStackLayout = new StackLayout()
                    {
                        Orientation = StackOrientation.Horizontal,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Padding = 10,
                        Spacing = 20
                    };

                    hStackLayout.Children.Add(item.Item2);

                    Label issue = new Label()
                    {
                        Text = item.Item1
                    };
                    hStackLayout.Children.Add(issue);
                    layout.Children.Add(hStackLayout);
                }
            }
        }

        protected override bool OnBackButtonPressed()
        {
            Navigation.PopModalAsync();
            return true;
        }

        async void OnDismissButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();
        }
    }
}