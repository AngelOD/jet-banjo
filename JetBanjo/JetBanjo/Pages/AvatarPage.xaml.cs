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
        public string RoomName { get; set; } = "Default";
        private bool swap = true;
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
            this.BindingContext = this;
            Avatar.Source = ImageSource.FromResource("JetBanjo.Resources.donfbred.png");
            Console.WriteLine("Halp");
        }

        public void Test(object sender, EventArgs args)
        {
            if(swap)
                Avatar.Source = ImageSource.FromResource("JetBanjo.Resources.roed.png");
            else
                Avatar.Source = ImageSource.FromResource("JetBanjo.Resources.donfbred.png");
            swap = !swap;

        }




    }
}