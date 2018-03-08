using JetBanjo.Interfaces.Logic;
using JetBanjo.Interfaces.Views;
using JetBanjo.Logic.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JetBanjo.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AvatarPage : ContentPage, IAvatarView
	{
        private IAvatarLogic logic;

        public AvatarPage()
        {
            InitializeComponent();
            logic = new AvatarPageLogic();
            logic.SetView(this);
        }

		public AvatarPage (IAvatarLogic logic)
		{
			InitializeComponent ();
            this.logic = logic;
            logic.SetView(this);

            StackLayout layout = new StackLayout();
            var avatarImage = new Image { Source = ImageSource.FromResource("TooHot.png") };

            layout.Children.Add(avatarImage);
        }



        

	}
}