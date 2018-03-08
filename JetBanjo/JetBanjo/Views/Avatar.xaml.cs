using JetBanjo.Logic.Interfaces.Logic;
using JetBanjo.Logic.Interfaces.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JetBanjo.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Avatar : ContentPage, IAvatarView
	{
        IAvatarLogic logic;

		public Avatar (IAvatarLogic logic)
		{
			InitializeComponent ();
            this.logic = logic;
            logic.SetView(this);
        }
	}
}