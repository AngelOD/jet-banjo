﻿using System;
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
using System.Threading.Tasks;
using Android.Support.V4.Content;

[assembly: Xamarin.Forms.Dependency(typeof(DisplayService))]
namespace JetBanjo.Droid.Utils
{
    public class DisplayService : IDisplayService
    {
        private static AlertDialog iconDialog;
        private static Dialog indicator;

        public void ShowDialog(string title, string text, ImageSource source)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(MainActivity.Context);
            Drawable icon = new BitmapDrawable(GetImageFromImageSourceAsync(source, Android.App.Application.Context));
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
            AlertDialog.Builder builder = new AlertDialog.Builder(MainActivity.Context);
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


        /// <summary>
        /// Show the progress indicator
        /// </summary>
        public void ShowActivityIndicator()
        {
            Android.Widget.ProgressBar pbar = new Android.Widget.ProgressBar(MainActivity.Context);
            pbar.IndeterminateDrawable.SetColorFilter(new Android.Graphics.Color(ContextCompat.GetColor(MainActivity.Context, Resource.Color.primary)), PorterDuff.Mode.SrcAtop); //Sets the color
            indicator = new Dialog(MainActivity.Context, Resource.Style.MyTheme_TransparentDialog); //Transperent theme
            indicator.RequestWindowFeature((int)WindowFeatures.NoTitle); //Removes the title
            indicator.SetContentView(pbar);
            indicator.Window.SetBackgroundDrawable(new ColorDrawable(Android.Graphics.Color.Transparent)); //Removes the background
            indicator.Window.ClearFlags(WindowManagerFlags.DimBehind); //Removes the dim behind the dialog
            indicator.SetCancelable(false);
            indicator.Show();
        }

        /// <summary>
        /// Removes the progress indicator from the screen
        /// </summary>
        public void DismissActivityIndicator()
        {
            if (indicator != null)
            {
                indicator.Dismiss();
            }
        }




        private Bitmap GetImageFromImageSourceAsync(ImageSource imageSource, Context context)
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

            var bitmap = Task.Run<Bitmap>(()=> handler.LoadImageAsync(imageSource, context)).Result;

            return bitmap;
        }
    }
}