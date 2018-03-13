using JetBanjo.Logic.Pages;
using JetBanjo.Interfaces.Logic;
using JetBanjo.Interfaces.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using JetBanjo.Utils.DependencyService;
using JetBanjo.Web;
using static JetBanjo.Web.WebHandler;

namespace JetBanjo.Pages
{
	public partial class MainPage : CContentPage, IMainPageView
	{
        public string Teststring { get; set; } = "Lllllll";
        private IMainPageLogic logic;

        public MainPage()
        {
            InitializeComponent();
            this.logic = new MainPageLogic();
            logic.SetView(this);
            this.BindingContext = this;
        }


        public async void Test(object sender, EventArgs args)
        {
           WebResult<int> result = await WebHandler.ReadData<int>("https://google.dk");
            DependencyService.Get<IDisplayService>().ShowDialog("lol", result.ResponseCode.ToString(), ImageSource.FromResource("JetBanjo.Resources.error.png"));
        }

        protected override void OnAppearing()
        {
        }

    }
}
