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
	public partial class AvatarPage : CContentPage, IAvatarView
	{
        private IAvatarLogic logic;
        public string RoomName { get; set; } = "Default";
        private bool swap = true;

        public enum AvatarType
        {
            Good, BadTemp, BadAir, BadSound
        };

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

        public void updateAvatar(AvatarType newAvatar)
        {
            switch (newAvatar)
            {
                case AvatarType.Good:
                    Avatar.Source = ImageSource.FromResource("JetBanjo.Resources.good.png");
                    break;
                case AvatarType.BadTemp:
                    Avatar.Source = ImageSource.FromResource("JetBanjo.Resources.badtemp.png");
                    break;
                case AvatarType.BadAir:
                    Avatar.Source = ImageSource.FromResource("JetBanjo.Resources.badair.png");
                    break;
                case AvatarType.BadSound:
                    Avatar.Source = ImageSource.FromResource("JetBanjo.Resources.badsound.png");
                    break;
                default:
                    break;
            }
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