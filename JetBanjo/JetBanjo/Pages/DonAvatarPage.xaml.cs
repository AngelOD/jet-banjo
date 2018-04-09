using JetBanjo.Utils.DependencyService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JetBanjo.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DonAvatarPage : CContentPage
	{
        private Image currentTopLayer;
        private TapGestureRecognizer tapGestureRecognizer;


        public DonAvatarPage ()
		{
			InitializeComponent ();

            tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += OnTouch;
            AddOverlay();
        }


        public void AddOverlay()
        {
            //WIP
            var i2 = new Image { Source = ImageSource.FromResource("JetBanjo.Resources.donfbred.png"), InputTransparent = true, HorizontalOptions = LayoutOptions.FillAndExpand  };
            var i1 = new Image { Source = ImageSource.FromResource("JetBanjo.Resources.roed.png"), HorizontalOptions = LayoutOptions.FillAndExpand, Aspect= Aspect.Fill };
            i1.GestureRecognizers.Add(tapGestureRecognizer); ;
            AddLayer(i1);
            AddLayer(i2);
        }


        private void AddLayer(Image image)
        {
            layout.Children.Add(image, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
        }

        public void OnTouch(object sender, EventArgs args)
        {
            DependencyService.Get<IDisplayService>().ShowDialog("hej", "dwada");
        }
    }
}