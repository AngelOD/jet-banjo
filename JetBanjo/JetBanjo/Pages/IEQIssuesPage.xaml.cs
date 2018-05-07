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
            //Console.WriteLine("Why u no work?! Be my snitch!");

            ShowIssues();
        }

        private async Task RequestIssues()
        {
            Console.WriteLine("RI-1");
            list = await logic.GetIssues(await SensorData.Get(), DateTime.Now);
            //Console.WriteLine(list[0].Item1);
            Console.WriteLine("RI-2");
        }


        public void ShowIssues()
        {
            Console.WriteLine("SI-1");

            Task.Run(async () => await RequestIssues()).Wait();

            Console.WriteLine("SI-2");

            foreach (Tuple<string, CachedImage> item in list)
            {
                if (!String.IsNullOrEmpty(item.Item1))
                {
                    AbsoluteLayout abLayout = new AbsoluteLayout();
                    abLayout.Children.Add(item.Item2);

                    Label issue = new Label()
                    {
                        Text = item.Item1
                    };
                    abLayout.Children.Add(issue);
                    layout.Children.Add(abLayout);
                }
            }

            Console.WriteLine("SI-3");
            //test
            AbsoluteLayout testlayout = new AbsoluteLayout();
            Label testlabel = new Label()
            {
                Text = "Hey there! Do you know if this is working as intended?"
            };
            testlayout.Children.Add(testlabel);
            layout.Children.Add(testlayout);
        }
	}
}