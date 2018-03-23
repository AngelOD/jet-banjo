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
            logic.DownloadRoomList();
        }


        public void OnTextChanged(object sender, EventArgs args)
        {
            UpdateRoomList(logic.FilterList(searchBox.Text));
        }

        public void OnItemSelected(object sender, EventArgs args)
        {
            
        }

        protected override void OnAppearing()
        {
            UpdateRoomList(logic.GetList());
        }

        public void UpdateRoomList(List<Room> updatedRoomList)
        {
            roomList.ItemsSource = updatedRoomList;
        }
    }
}
