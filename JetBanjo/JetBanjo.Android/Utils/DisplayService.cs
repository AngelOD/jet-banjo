using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using JetBanjo.Utils.DependencyService;
using JetBanjo.Resx;
using Xamarin.Forms;
using Android.Graphics;
using Xamarin.Forms.Platform.Android;
using JetBanjo.Utils;
using JetBanjo.Droid.Utils;

[assembly: Xamarin.Forms.Dependency(typeof(DisplayService))]
namespace JetBanjo.Droid.Utils
{
    public class DisplayService : IDisplayService
    {
        private static AlertDialog iconDialog;

        public void ShowDialog(string title, string text, ImageSource source)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(Android.App.Application.Context);
            Drawable icon = new BitmapDrawable(GetImageFromImageSource(source, Android.App.Application.Context));
            builder.SetIcon(icon);
            builder.SetTitle(title);
            builder.SetMessage(text);
            builder.SetPositiveButton(Translator.Translate("ok"), ((x, y) => { DismissDialog(); }) );
            builder.SetCancelable(false);
            iconDialog = builder.Create();
            iconDialog.Show();
        }

        public void ShowDialog(string title, string text)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(Forms.Context);
            builder.SetTitle(title);
            builder.SetMessage(text);
            builder.SetCancelable(false);
            builder.SetPositiveButton(Translator.Translate("ok"), ((x, y) => { DismissDialog(); }));
            iconDialog = builder.Create();
            iconDialog.Show();
        }

        public void DismissDialog()
        {
            if (iconDialog != null)
            {
                iconDialog.Dismiss();
            }
        }




        private Bitmap GetImageFromImageSource(ImageSource imageSource, Context context)
        {
            IImageSourceHandler handler;

            if (imageSource is FileImageSource)
            {
                handler = new FileImageSourceHandler();
            }
            else if (imageSource is StreamImageSource)
            {
                handler = new StreamImagesourceHandler();
            }
            else if (imageSource is UriImageSource)
            {
                handler = new ImageLoaderSourceHandler();
            }
            else
            {
                throw new NotImplementedException();
            }

            var bitmap = handler.LoadImageAsync(imageSource, context);

            return bitmap.Result;
        }
    }
}