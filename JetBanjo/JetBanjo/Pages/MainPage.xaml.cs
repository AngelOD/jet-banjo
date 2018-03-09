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

namespace JetBanjo.Pages
{
	public partial class MainPage : ContentPage, IMainPageView
	{

        private IMainPageLogic logic;

        public MainPage()
        {
            InitializeComponent();
            this.logic = new MainPageLogic();
            logic.SetView(this);
        }

        public MainPage(IMainPageLogic logic)
		{
			InitializeComponent();
            this.logic = logic;
            logic.SetView(this);
        }


        public void Test(object sender, EventArgs args)
        {
            DependencyService.Get<IDisplayService>().ShowDialog("lol", "test");
        }

        protected override void OnAppearing()
        {
            
        }

    }
}
