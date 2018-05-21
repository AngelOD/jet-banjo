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
		public Settings()
		{
			InitializeComponent();
            IpBox.WidthRequest = (App.ScreenSize.Width * 0.8);
            CurrentIp.Text = DataStore.GetValue(Keys.Ip);
            Task.Run(async () => { await UpdateCurrentRoom(); }).Wait(); //Waits for the text has been updated
        }


        /// <summary>
        /// Updates the current room entry text with the room number
        /// </summary>
        /// <returns></returns>
        private async Task UpdateCurrentRoom()
        {
            Room temp = await Room.Get();
            Device.BeginInvokeOnMainThread(() => CurrentRoom.Text = temp.RoomNumber);
        }

        /// <summary>
        /// Displays the room selector dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns>Void</returns>
        public async void OnChangeRoomClick(object sender, EventArgs args)
        {
            ChangeRoom.Clicked -= OnChangeRoomClick;
            List<Room> rooms = await Room.GetList();

            //Local method that is used then a room is selected in the dialog
            void OnSearchListItemPicked(bool b, Room r)
            {

                if (b)
                {
                    DataStore.SaveValue(Keys.Room, r.Id);
                    Task.Run(async () => { await UpdateCurrentRoom(); }).Wait();
                }
                ChangeRoom.Clicked += OnChangeRoomClick;
            }

            //Displays the dialog
            DependencyService.Get<IDisplayService>().ShowSearchListDialog(rooms, AppResources.choose_room, AppResources.cancel, AppResources.example_room, OnSearchListItemPicked);
        }

        /// <summary>
        /// Clears the current room and updates the current room text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns>Void</returns>
        public async Task OnRemoveRoomClick(object sender, EventArgs args)
        {
            DataStore.RemoveValue(Keys.Room);
            await UpdateCurrentRoom();
        }

        /// <summary>
        /// When the entry text is changed save it to the device
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnIpChanged(object sender, EventArgs args)
        {
            DataStore.SaveValue(Keys.Ip, CurrentIp.Text);
        }

        /// <summary>
        /// When the remove button is presed, remove the ip and update the entry text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnRemoveIpClick(object sender, EventArgs args)
        {
            DataStore.RemoveValue(Keys.Ip);
            CurrentIp.Text = DataStore.GetValue(Keys.Ip);
        }

    }
}