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
using System.Threading.Tasks;
using Android.Support.V4.Content;

[assembly: Xamarin.Forms.Dependency(typeof(DisplayService))]
namespace JetBanjo.Droid.Utils
{
    public class DisplayService : IDisplayService
    {
        private static AlertDialog iconDialog;
        private static AlertDialog inputDialog;
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
                iconDialog = null;
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
                indicator = null;
            }
        }


        public void ShowInputDialog(string title, string text, string ok, string placeholder, Action<string> callback)
        {
            var task = new TaskCompletionSource<string>();
            AlertDialog.Builder builder = new AlertDialog.Builder(MainActivity.Context);
            EditText userInput = new EditText(MainActivity.Context);

            string selectedInput = string.Empty;
            userInput.Text = placeholder;
            userInput.InputType = Android.Text.InputTypes.NumberFlagDecimal | Android.Text.InputTypes.ClassNumber;
            userInput.FocusChange += (sender, args) => { userInput.Text = ""; };
            builder.SetTitle(title);
            builder.SetMessage(text);
            builder.SetView(userInput);
            builder.SetPositiveButton(ok, ((sender, args) => { inputDialog.Dismiss();  callback(userInput.Text); }));
            inputDialog = builder.Create();
            inputDialog.Show();
        }


        public void ShowInputDialog(string title, string text, string ok, string cancel, string placeholder, Action<bool,string> callback)
        {
            var task = new TaskCompletionSource<string>();
            AlertDialog.Builder builder = new AlertDialog.Builder(MainActivity.Context);
            EditText userInput = new EditText(MainActivity.Context);

            string selectedInput = string.Empty;
            userInput.Hint = placeholder;
            userInput.InputType = Android.Text.InputTypes.NumberFlagDecimal | Android.Text.InputTypes.ClassNumber;
            builder.SetTitle(title);
            builder.SetMessage(text);
            builder.SetView(userInput);
            builder.SetPositiveButton(ok, ((sender, args) => { inputDialog.Dismiss(); callback(true, userInput.Text); }));
            builder.SetNegativeButton(cancel, ((sender, args) => { inputDialog.Dismiss(); callback(false, null); }));
            inputDialog = builder.Create();
            inputDialog.Show();
        }

        public void DismissInputDialog()
        {
            if (inputDialog != null)
            {
                inputDialog.Dismiss();
                inputDialog = null;
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