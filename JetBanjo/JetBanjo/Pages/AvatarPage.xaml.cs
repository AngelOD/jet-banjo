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
using System.Timers;
using JetBanjo.Web.Objects;
using JetBanjo.Utils;
using FFImageLoading.Forms;
using JetBanjo.Resx;
using JetBanjo.Utils.Data;
using Rg.Plugins.Popup.Extensions;

namespace JetBanjo.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AvatarPage : CContentPage
	{
        private IAvatarLogic logic;
        private string currentRoomId;
        private TapGestureRecognizer tapGestureRecognizer;
        private bool timerShouldContinue = true;
        private List<CImage> startUpImages;

        public AvatarPage()
        {
            InitializeComponent();
            logic = new AvatarPageLogic();

            startUpImages = new List<CImage>()
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms)
            };
            tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += OnTouch;
        }

        /// <summary>
        /// When the page is appearing on the screen
        /// </summary>
        protected override void OnAppearing()
        {
            currentRoomId = DataStore.GetValue(DataStoreKeys.Keys.Room);
            Task t = Task.Run(async () => await UpdateRoomName()); //Updates the rooms name
            t.Wait(); //Makes sure the name have been retrived before continuing
            //Such that when we open the pages, the starup images is added to the screen and the timer begins
            AddOverlay(startUpImages);
            Task.Run(async ()=> await RequestImages());

            timerShouldContinue = true;
            Device.StartTimer(Constants.avatarUpdateTime, () => OnTimer());
        }   

        /// <summary>
        /// When the page is disappearing from the screen, we should stop rendering
        /// </summary>
        protected override void OnDisappearing()
        {
            timerShouldContinue = false;
        }

        private bool OnTimer ()
        {
            if (timerShouldContinue && DependencyService.Get<IDeviceService>().GetScreenState())
            {
                Task.Run(async () => await RequestImages());
            }
            return timerShouldContinue;
        }

        private void AddOverlay(List<CImage> images)
        {
            CachedImage i = images[0].GetImage();
            i.GestureRecognizers.Add(tapGestureRecognizer);
            i.HorizontalOptions = LayoutOptions.FillAndExpand;
            i.VerticalOptions = LayoutOptions.FillAndExpand;
            i.Aspect = Aspect.Fill;
            List<CachedImage> tempList = new List<CachedImage>();
            List<CImage> temp = images.Skip(1).ToList();
            foreach (var image in temp)
            {
                CachedImage ci = image.GetImage();
                ci.InputTransparent = true;
                ci.VerticalOptions = LayoutOptions.FillAndExpand;
                ci.HorizontalOptions = LayoutOptions.FillAndExpand;

                ImageType t = image.Type;

                switch (t)
                {
                    case ImageType.Character:
                    case ImageType.Arms:
                    case ImageType.CO2:
                    case ImageType.UV:
                    case ImageType.Noise:
                    case ImageType.ColdSweatFire:
                    case ImageType.Sunglasses:
                    case ImageType.Frozen:
                        ci.Aspect = Aspect.AspectFit;
                        break;
                    default:
                        ci.Aspect = Aspect.Fill;
                        break;
                }

                tempList.Add(ci);
            }

            Device.BeginInvokeOnMainThread(() =>
            {
                layout.Children.Clear();
                layout.Children.Add(i, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);

                foreach (var image in tempList)
                {
                    layout.Children.Add(image, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
                }
            });
        }

        private async void OnTouch(object sender, EventArgs args)
        {
            //WIP should show small popup with the current issues
            //DependencyService.Get<IDisplayService>().ShowDialog("'Ola", "This is WIP");
            await Navigation.PushPopupAsync(new IEQIssuesPage());
        }

        private async Task RequestImages()
        {
            List<CImage> temp = await logic.GetAvatar(await SensorData.Get(currentRoomId), DateTime.Now);
            AddOverlay(temp);
        }

        private async Task UpdateRoomName()
        {
            Room temp = await Room.Get(currentRoomId);

            Device.BeginInvokeOnMainThread(() => Title = temp.RoomNumber);
        }

        private async void PickerIconPress(object sender, EventArgs args)
        {
            List<Room> rooms = await Room.GetList();

            //Used for the callback when an item has been chosen or not
            void OnSearchListItemPicked(bool b, Room r)
            {

                if (b)
                {
                    Title = r.RoomNumber;
                    currentRoomId = r.Id;
                    OnTimer();
                }
            }

            //Displays the room selector dialog 
            DependencyService.Get<IDisplayService>().ShowSearchListDialog(rooms, AppResources.choose_room, AppResources.cancel, AppResources.example_room, OnSearchListItemPicked);
        }
    }
}
