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
        public Image AvatarImage { get; set; }
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
            Console.WriteLine("Halp");
            this.logic = logic;
            logic.SetView(this);
            this.BindingContext = this;
            Image embeddedImage = new Image { Source = ImageSource.FromResource("JetBanjo.Resources.donathan.JPG") };
            Avatar = embeddedImage;

            

            Title = roomName;
        }



        

	}
}