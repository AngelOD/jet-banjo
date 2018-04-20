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
                CachedImage i = images[0].GetImage();
                i.GestureRecognizers.Add(tapGestureRecognizer);
                i.HorizontalOptions = LayoutOptions.FillAndExpand;
                i.Aspect = Aspect.Fill;

                layout.Children.Add(i, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
                List<CImage> temp = images.Skip(1).ToList();
                foreach (var image in temp)
                {
                    CachedImage ci = image.GetImage();
                    ci.InputTransparent = true;
                    ci.HorizontalOptions = LayoutOptions.FillAndExpand;
                    layout.Children.Add(ci, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
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
            List<CImage> temp = await logic.GetAvatar(await SensorData.Get(), DateTime.Now);
            foreach (var item in temp)
            {
                Console.WriteLine(item);
            }
            AddOverlay(temp);
        }
    }
}