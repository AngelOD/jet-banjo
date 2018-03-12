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
        private Image avatarImage;
        public Image AvatarImage { get { return avatarImage; } }
        public AvatarPage()
        {
            InitializeComponent();
            logic = new AvatarPageLogic();
            logic.SetView(this);
            this.BindingContext = this;
        }

		public AvatarPage (IAvatarLogic logic, string roomName)
		{
			InitializeComponent();
            this.logic = logic;
            logic.SetView(this);
            

            Image avatarImage = new Image()
            {
                Source = ImageSource.FromResource("JetBanjo.Resources.donfBred.png"),
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Aspect = Aspect.AspectFit
            };

            Title = roomName;
        }



        

	}
}