using JetBanjo.Utils;
using JetBanjo.Utils.Data;
using JetBanjo.Utils.DependencyService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static JetBanjo.Utils.Data.DataStoreKeys;

namespace JetBanjo.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Settings : CContentPage
	{
		public Settings ()
		{
			InitializeComponent ();
        }


        public void OnRemoveRoomClick(object sender, EventArgs args)
        {
            DataStore.RemoveValue(Keys.Room);
        }

        public void OnRemoveIpClick(object sender, EventArgs args)
        {
            DataStore.RemoveValue(Keys.Ip);
        }

    }
}