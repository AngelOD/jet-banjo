using JetBanjo.Logic.Pages;
using JetBanjo.Interfaces.Logic;
using JetBanjo.Interfaces.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using JetBanjo.Utils.DependencyService;
using JetBanjo.Web;
using static JetBanjo.Web.WebHandler;
using JetBanjo.Web.Objects;
using JetBanjo.Utils;
using static JetBanjo.Utils.DataStore;
using JetBanjo.Resx;

namespace JetBanjo.Pages
{
	public partial class RoomSelectorPage : CContentPage, IRoomSelectorPageView
    {
        private IRoomSelectorPageLogic logic;

        public RoomSelectorPage()
        {
            InitializeComponent();
            logic = new RoomSelectorPageLogic();
            logic.SetView(this);
        }


        public void OnTextChanged(object sender, EventArgs args)
        {
            UpdateRoomList(logic.FilterList(searchBox.Text));
        }

        public void OnItemSelected(object sender, EventArgs args)
        {
            Room room = (Room)roomList.SelectedItem;
            if(room!= null)
            {
                DataStore.SaveValue(Keys.Room, room.Id);
                ((App)App.Current).ChangeToMasterMenu();
            }
            
        }

        protected override void OnAppearing()
        {
            //If the ip option have not been set already.
            if (DataStore.GetValue(Keys.Ip) == null)
            {
                DependencyService.Get<IDisplayService>().ShowInputDialog(AppResources.ip, AppResources.ip_text, AppResources.ok , "1.2.2", OnInputFromDialog);
            }
            else
            {
                ContinueStartup();
            }
        }

        private void OnInputFromDialog(string input)
        {
            DependencyService.Get<IDisplayService>().DismissInputDialog();
            DataStore.SaveValue(Keys.Ip, input);
            ContinueStartup();
        }

        private async void ContinueStartup()
        {
            //If the ip option have been set already.
            if (DataStore.GetValue(Keys.Ip) != null)
            {
                //If the room option have been set already.
                if (DataStore.GetValue(Keys.Room) != null)
                {
                    ((App)App.Current).ChangeToMasterMenu();
                    return;
                }
                //Else get them to choose a room
                DependencyService.Get<IDisplayService>().ShowActivityIndicator();
                UpdateRoomList(await logic.GetList());
                DependencyService.Get<IDisplayService>().DismissActivityIndicator();
            }
        }

        public void UpdateRoomList(List<Room> updatedRoomList)
        {
            roomList.ItemsSource = updatedRoomList;
        }
    }
}
