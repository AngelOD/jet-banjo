using JetBanjo.Logic.Interfaces.Logic;
using JetBanjo.Logic.Interfaces.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JetBanjo.Views
{
	public partial class MainPage : ContentPage, IMainPageView
	{

        IMainPageLogic logic;

		public MainPage(IMainPageLogic logic)
		{
			InitializeComponent();
            this.logic = logic;
            logic.SetView(this);
		}
	}
}
