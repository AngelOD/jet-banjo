using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private List<Tuple<string, CImage>> list;

		public IEQIssuesPage ()
		{
            logic = new IEQIssuesPageLogic();
			InitializeComponent ();
		}

        private async Task RequestIssues()
        {
            list = logic.getIssues(await SensorData.Get(), DateTime.Now);
        }

        public void ShowIssues()
        {
            Task.Run(async () => await RequestIssues());

            //todo add rest of func to show image and text
            foreach (Tuple<string, CImage> item in list)
            {
                AbsoluteLayout abLayout = new AbsoluteLayout();

                //abLayout.Children.Add()
            }
        }
	}
}