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

        private IEQIssuesPage ieqPage;

        public AvatarPage()
        {
            InitializeComponent();
            logic = new AvatarPageLogic();

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
                i.Aspect = Aspect.Fill;

                layout.Children.Add(i, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);

                List<CImage> temp = images.Skip(1).ToList();
                foreach (var image in temp)
                {
                    CachedImage ci = image.GetImage();
                    ci.InputTransparent = true;
                    ci.HorizontalOptions = LayoutOptions.FillAndExpand;
                    ci.Aspect = Aspect.AspectFill;
                    layout.Children.Add(ci, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
                }
            });
        }

        private async void OnTouch(object sender, EventArgs args)
        {
            //WIP should show small popup with the current issues
            //DependencyService.Get<IDisplayService>().ShowDialog("'Ola", "This is WIP");

            if(ieqPage == null)
            {
                ieqPage = new IEQIssuesPage();
            }
            await Navigation.PushModalAsync(ieqPage);
        }

        private async Task RequestImages()
        {
            List<CImage> temp = await logic.GetAvatar(await SensorData.Get(), DateTime.Now);
            AddOverlay(temp);
        }
    }
}