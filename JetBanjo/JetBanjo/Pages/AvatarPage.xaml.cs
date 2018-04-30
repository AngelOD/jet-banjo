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

namespace JetBanjo.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AvatarPage : CContentPage
	{
        private IAvatarLogic logic;
        private string currentRoomId;
        private TapGestureRecognizer tapGestureRecognizer;

        public AvatarPage()
        {
            InitializeComponent();
            logic = new AvatarPageLogic();

            currentRoomId = DataStore.GetValue(DataStoreKeys.Keys.Room);
            Task t = Task.Run(async ()=> await UpdateRoomName());
            t.Wait();
            List<CImage> startUpImages = new List<CImage>()
            {
                new CImage("basic-classroom.png", ImageType.Background),
                new CImage("child-no-arms.png", ImageType.Character),
                new CImage("child-arms-down.png",ImageType.Arms)
            };
            AddOverlay(startUpImages);
            OnTimer();
            Device.StartTimer(new TimeSpan(0, 0, 5), () => OnTimer());

            tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += OnTouch;
        }

        private bool OnTimer ()
        {
            Task.Run(async ()=> await RequestImages());
            return true;
        }

        private void AddOverlay(List<CImage> images)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                layout.Children.Clear();
                CachedImage i = images[0].GetImage();
                i.GestureRecognizers.Add(tapGestureRecognizer);
                i.HorizontalOptions = LayoutOptions.FillAndExpand;
                i.VerticalOptions = LayoutOptions.FillAndExpand;
                i.Aspect = Aspect.Fill;

                layout.Children.Add(i, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);

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

                    layout.Children.Add(ci, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
                }
            });
        }

        private void OnTouch(object sender, EventArgs args)
        {
            //WIP should show small popup with the current issues
            DependencyService.Get<IDisplayService>().ShowDialog("'Ola", "This is WIP");
        }

        private async Task RequestImages()
        {
            List<CImage> temp = await logic.GetAvatar(await SensorData.Get(currentRoomId), DateTime.Now);
            AddOverlay(temp);
        }

        private async Task UpdateRoomName()
        {
            Room temp = await Room.Get(currentRoomId);

            Title = temp.RoomNumber;
        }

        private async void PickerIconPress(object sender, EventArgs args)
        {
            List<Room> rooms = await Room.GetList();

            string result = await DisplayActionSheet(AppResources.choose_room, AppResources.cancel, null, rooms.Select(r => r.RoomNumber).ToArray());
            if(result != null && rooms != null && !result.Equals(AppResources.cancel))
            {
                Room temp = rooms.Find(r => r.RoomNumber.Equals(result));
                Console.WriteLine(temp.Id);
                Title = temp.RoomNumber;
                currentRoomId = temp.Id;
                OnTimer();
            }
                
        }
    }
}