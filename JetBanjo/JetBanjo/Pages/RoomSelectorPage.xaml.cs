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
                DataStore.SaveValue("roomTest", room.Id);
                ((App)App.Current).ChangeToMasterMenu();
            }
            
        }

        protected async override void OnAppearing()
        {
            //If the room option have been set already.
            if (DataStore.GetValue("roomTest") != null)
            {
                ((App)App.Current).ChangeToMasterMenu();
                return;
            }
            DependencyService.Get<IDisplayService>().ShowActivityIndicator();
            UpdateRoomList(await logic.GetList());
            DependencyService.Get<IDisplayService>().DismissActivityIndicator();
        }

        public void UpdateRoomList(List<Room> updatedRoomList)
        {
            roomList.ItemsSource = updatedRoomList;
        }
    }
}
