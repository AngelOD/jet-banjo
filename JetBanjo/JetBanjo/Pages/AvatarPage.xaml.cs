using JetBanjo.Interfaces.Logic;
using JetBanjo.Logic.Pages;
using JetBanjo.Utils.DependencyService;
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
	public partial class AvatarPage : CContentPage
	{
        private IAvatarLogic logic;
        private string roomName;

        public AvatarPage()
        {
            InitializeComponent();
            logic = new AvatarPageLogic();
        }

		public AvatarPage (IAvatarLogic logic, string roomName)
		{
			InitializeComponent ();
            this.logic = logic;

            this.roomName = roomName;

            var avatarImage = new Image { Source = ImageSource.FromResource("TooHot.png") };
        }

        public void test(object sender, EventArgs args)
        {
            DependencyService.Get<IDisplayService>().ShowDialog("dwad", "DWAD");

        }

    }
}