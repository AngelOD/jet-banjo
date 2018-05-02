using JetBanjo.Resx;
using JetBanjo.Utils;
using JetBanjo.Utils.Data;
using JetBanjo.Utils.DependencyService;
using JetBanjo.Web.Objects;
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
            RoomBox.WidthRequest = App.ScreenSize.Width * 0.8;
            IpBox.WidthRequest = App.ScreenSize.Width * 0.8;
            CurrentIp.Text = DataStore.GetValue(Keys.Ip);
            Task.Run(async () => { await UpdateCurrentRoom(); }).Wait();
        }



        private async Task UpdateCurrentRoom()
        {
            CurrentRoom.Text = (await Room.Get()).RoomNumber;
        }

        public async Task OnChangeRoomClick(object sender, EventArgs args)
        {
            List<Room> rooms = await Room.GetList();

            string result = await DisplayActionSheet(AppResources.choose_room, AppResources.cancel, null, rooms.Select(r => r.RoomNumber).ToArray());
            if (result != null && rooms != null && !result.Equals(AppResources.cancel))
            {
                Room temp = rooms.Find(r => r.RoomNumber.Equals(result));
                DataStore.SaveValue(Keys.Room, temp.Id);
                await UpdateCurrentRoom();
            }
        }
        public async Task OnRemoveRoomClick(object sender, EventArgs args)
        {
            DataStore.RemoveValue(Keys.Room);
            await UpdateCurrentRoom();
        }

        public void OnIpChanged(object sender, EventArgs args)
        {
            DataStore.SaveValue(Keys.Ip, CurrentIp.Text);
        }

        public void OnRemoveIpClick(object sender, EventArgs args)
        {
            DataStore.RemoveValue(Keys.Ip);
        }

    }
}