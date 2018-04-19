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

namespace JetBanjo.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AvatarPage : CContentPage
	{
        private IAvatarLogic logic;

        private TapGestureRecognizer tapGestureRecognizer;
 
        public AvatarPage()
        {
            InitializeComponent();
            logic = new AvatarPageLogic();

            Timer timer = new Timer(5000)
            {
                AutoReset = true
            };

            tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += OnTouch;

            timer.Start();

            timer.Elapsed += async (s,e) => { await RequestImages(s, e); };
        }

        private void AddOverlay(List<CImage> images)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                layout.Children.Clear();
                images[0].GestureRecognizers.Add(tapGestureRecognizer);
                images[0].HorizontalOptions = LayoutOptions.FillAndExpand;
                images[0].Aspect = Aspect.Fill;

                layout.Children.Clear();
                layout.Children.Add(images[0], new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
                List<CImage> temp = images.Skip(1).ToList();
                foreach (var image in temp)
                {
                    image.InputTransparent = true;
                    image.HorizontalOptions = LayoutOptions.FillAndExpand;
                    layout.Children.Add(image, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
                }
            });
        }

        private void OnTouch(object sender, EventArgs args)
        {
            //WIP should show small popup with the current issues
            DependencyService.Get<IDisplayService>().ShowDialog("'Ola", "This is WIP");
        }

        private async Task RequestImages(object s, EventArgs a)
        {

            SensorData inputSensorData = new SensorData() { Temperature = 20, Humidity = 35.2, CO2 = 900, UV = 2, Lux = 500, dB = 50, VOC = 0 };
            DateTime inputTime = new DateTime(2018, 4, 16);
            AddOverlay(await logic.GetAvatar(inputSensorData, inputTime));
        }
    }
}