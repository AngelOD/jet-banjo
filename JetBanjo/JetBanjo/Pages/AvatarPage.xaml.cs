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
            InitializeAvatar();

            timer.Start();

            timer.Elapsed += RequestImages;
        }

        private void InitializeAvatar()
        {
            //WIP
            //Should start with a request for images
            var background = new Image { Source = ImageSource.FromResource("JetBanjo.Resources.roed.png"), HorizontalOptions = LayoutOptions.FillAndExpand, Aspect = Aspect.Fill };
            var avatar = new Image { Source = ImageSource.FromResource("JetBanjo.Resources.donfbred.png"), InputTransparent = true, HorizontalOptions = LayoutOptions.FillAndExpand };

            background.GestureRecognizers.Add(tapGestureRecognizer);

            AddLayer(background);
            AddLayer(avatar);
        }

        private void AddOverlay(Image background, List<Image> images)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                layout.Children.Clear();

                background.GestureRecognizers.Add(tapGestureRecognizer);
                AddLayer(background);

                foreach (var image in images)
                {
                    AddLayer(image);
                }
            });
        }
        
        private void AddLayer(Image image)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                layout.Children.Add(image, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
            });
        }

        private void OnTouch(object sender, EventArgs args)
        {
            //WIP should show small popup with the current issues
            DependencyService.Get<IDisplayService>().ShowDialog("'Ola", "This is WIP");
        }

        private async void RequestImages(object s, EventArgs a)
        {
            //WIP
            //SHOULD Request images from AvatarLogic logic
            var i1 = new Image { Source = ImageSource.FromResource("JetBanjo.Resources.badair.png"), HorizontalOptions = LayoutOptions.FillAndExpand, Aspect = Aspect.Fill };
            var i2 = new Image { Source = ImageSource.FromResource("JetBanjo.Resources.error.png"), InputTransparent = true, HorizontalOptions = LayoutOptions.FillAndExpand };
            List<Image> ilist = new List<Image>();

            ilist.Add(i2);

            AddOverlay(i1, ilist);
        }
    }
}