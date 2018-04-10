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
using JetBanjo.Utils;

namespace JetBanjo.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AvatarPage : CContentPage
	{
        public enum AvatarType
        {
            Good, BadTemp, BadAir, BadSound
        };

        AvatarPageLogic logic;

        private Image background;
        private Image avatar;
        private Image overlayEffect;
        
        private Image currentTopLayer;
        private TapGestureRecognizer tapGestureRecognizer;
 
        public AvatarPage()
        {
            InitializeComponent();
            logic = new AvatarPageLogic();

            tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += OnTouch;
            InitializeAvatar();
        }

        //Should ask for given pictures
        private void InitializeAvatar()
        {
            background = new Image { Source = ImageSource.FromResource("JetBanjo.Resources.roed.png"), HorizontalOptions = LayoutOptions.FillAndExpand, Aspect = Aspect.Fill };
            avatar = new Image { Source = ImageSource.FromResource("JetBanjo.Resources.donfbred.png"), InputTransparent = true, HorizontalOptions = LayoutOptions.FillAndExpand };
            overlayEffect = new Image { Source = ImageSource.FromResource("JetBanjo.Resources.roed.png"), HorizontalOptions = LayoutOptions.FillAndExpand, IsVisible = false };

            background.GestureRecognizers.Add(tapGestureRecognizer);

            AddLayer(background);
            AddLayer(avatar);
            AddLayer(overlayEffect);
        }

        private void AddOverlay(Image _background, Image _avatar, Image _overlay)
        {
            //WIP needs to replace pictures
            replaceLayer(background, _background);
            replaceLayer(avatar, _avatar);
            replaceLayer(overlayEffect, _overlay);

            background.GestureRecognizers.Add(tapGestureRecognizer);
        }
        
        private void AddLayer(Image image)
        {
            layout.Children.Add(image, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
        }

        private void replaceLayer(Image removedImage, Image addedImage)
        {
            layout.Children.Remove(removedImage);
            layout.Children.Add(addedImage, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
        }


        private void OnTouch(object sender, EventArgs args)
        {
            //WIP
            DependencyService.Get<IDisplayService>().ShowDialog("'Ola", "This is WIP");
        }
    }
}