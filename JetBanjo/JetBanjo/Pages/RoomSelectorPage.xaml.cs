using JetBanjo.Logic.Pages;
using JetBanjo.Interfaces.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using JetBanjo.Utils.DependencyService;
using JetBanjo.Web;
using JetBanjo.Web.Objects;
using JetBanjo.Utils;
using JetBanjo.Resx;
using System.Threading;
using JetBanjo.Utils.Data;
using static JetBanjo.Utils.Data.DataStoreKeys;

namespace JetBanjo.Pages
{
	public partial class RoomSelectorPage : CContentPage
    {
        private ILeaderBoardPageLogic logic;
        private IDisplayService displayService;

        public RoomSelectorPage()
        {
            InitializeComponent();
            logic = new RoomSelectorPageLogic();

            displayService = DependencyService.Get<IDisplayService>(DependencyFetchTarget.GlobalInstance); //Fetches the global instance of the dependency service. Even though it should not create more dialog objects. But it saves memory
        }

        /// <summary>
        /// Event for when the text in the room filter entry is changed
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="args">The event arguments</param>
        public void OnTextChanged(object sender, EventArgs args)
        {
            UpdateRoomList(logic.FilterList(searchBox.Text));
        }

        /// <summary>
        /// Event for when a room is selected on the room list
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="args">The event arguments</param>
        public void OnItemSelected(object sender, EventArgs args)
        {
            Room room = (Room)roomList.SelectedItem;
            if(room!= null)
            {
                DataStore.SaveValue(Keys.Room, room.Id);
                ((App)App.Current).ChangeToMasterMenu();
            }
            
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            //If the ip option have not been set already.
            if (string.IsNullOrWhiteSpace(DataStore.GetValue(Keys.Ip)))
            {
                displayService.ShowActivityIndicator();
                //await Task.Run(() => { Thread.Sleep(5000); });
                string ip = await DependencyService.Get<INetworkDiscovery>(DependencyFetchTarget.GlobalInstance).FindBackEnd();
                displayService.DismissActivityIndicator();
                if (!string.IsNullOrWhiteSpace(ip))
                {
                    DataStore.SaveValue(DataStoreKeys.Keys.Ip, ip);
                    ContinueStartup();
                }
                else
                    displayService.ShowDialog(AppResources.error, AppResources.cannot_detect_backend, ImageSource.FromResource("JetBanjo.Resources.error.png"), () => { OnFailToFindNetworkDevice(); });

            }
            else
            {
                ContinueStartup();
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            displayService.DismissInputDialog(); //Such that the dialog is not there twice, because of the way OnAppearing gets called.

        }


        private void OnFailToFindNetworkDevice()
        {
#if DEBUG
            displayService.ShowInputDialog(AppResources.ip, AppResources.ip_text, AppResources.ok, AppResources.example_ip, Constants.DEBUG_IP_ADDRESS, OnInputFromDialog);
#else
            displayService.ShowInputDialog(AppResources.ip, AppResources.ip_text, AppResources.ok , AppResources.example_ip, OnInputFromDialog);
#endif
        }

        /// <summary>
        /// Method to be used as callback for the IP dialog
        /// </summary>
        /// <param name="input">The string output of the dialog which is the input to this method</param>
        private void OnInputFromDialog(string input)
        {

            if (string.IsNullOrWhiteSpace(input))
            {
                displayService.ShowDialog(AppResources.error, AppResources.ip_null_or_empty_err_msg, ImageSource.FromResource("JetBanjo.Resources.error.png"),OnFailToFindNetworkDevice); //Show the same input dialog again
            }
            else
            {
                displayService.DismissInputDialog();
                DataStore.SaveValue(Keys.Ip, input);
                ContinueStartup();
            }
        }

        /// <summary>
        /// Continues with the setup part of the app,can only be used after the IP have been set.
        /// </summary>
        private async void ContinueStartup()
        {
            //If the ip option have been set already.
            if (!string.IsNullOrWhiteSpace(DataStore.GetValue(Keys.Ip)))
            {
                //If the room option have been set already.
                if (!string.IsNullOrWhiteSpace(DataStore.GetValue(Keys.Room)))
                {
                    ((App)App.Current).ChangeToMasterMenu();
                    return;
                }
                else
                {
                    //Else get them to choose a room
                    displayService.ShowActivityIndicator();
                    UpdateRoomList(await logic.GetList());
                    displayService.DismissActivityIndicator();
                }
            }
        }

        /// <summary>
        /// Assaings the updatedRoomList to the roomlist
        /// </summary>
        /// <param name="updatedRoomList">The list of rooms</param>
        public void UpdateRoomList(List<Room> updatedRoomList)
        {
            roomList.ItemsSource = updatedRoomList;
        }
    }
}
