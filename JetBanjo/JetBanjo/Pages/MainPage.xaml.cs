using JetBanjo.Logic.Pages;
using JetBanjo.Interfaces.Logic;
using JetBanjo.Interfaces.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

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
	}
}
