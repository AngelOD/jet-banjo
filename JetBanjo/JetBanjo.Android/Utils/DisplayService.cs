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
        //Private instances of dialogs 
        private static AlertDialog iconDialog;
        private static AlertDialog inputDialog;
        private static Dialog indicator;


        /// <summary>
        /// Displays a dialog with a title, text and icon
        /// </summary>
        /// <param name="title">The title of the dialog</param>
        /// <param name="text">The text of the dialog</param>
        /// <param name="source">The image source for the icon</param>
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

        /// <summary>
        /// Displays a dialog with a title and text
        /// </summary>
        /// <param name="title">The title of the dialog</param>
        /// <param name="text">The text of the dialog</param>
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

        /// <summary>
        /// Dismisses the text / icon dialog
        /// </summary>
        public void DismissDialog()
        {
            if (iconDialog != null)
            {
                iconDialog.Dismiss();
                iconDialog = null;
            }
        }


        /// <summary>
        /// Displays an activity indicator that cannot be dismissed by the user
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
        /// Dismisses the activity indicator
        /// </summary>
        public void DismissActivityIndicator()
        {
            if (indicator != null)
            {
                indicator.Dismiss();
                indicator = null;
            }
        }


        /// <summary>
        /// Displays a dialog with a title, text and a text input
        /// </summary>
        /// <param name="title">The title of the dialog</param>
        /// <param name="text">The text of the dialog</param>
        /// <param name="ok">The text for the positive button</param>
        /// <param name="placeholder">The placeholder of the input text field</param>
        /// <param name="callback">Callback method to be called when the positive button is pressed</param>
        public void ShowInputDialog(string title, string text, string ok, string placeholder, Action<string> callback)
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
            builder.SetPositiveButton(ok, ((sender, args) => { inputDialog.Dismiss();  callback(userInput.Text); }));
            inputDialog = builder.Create();
            inputDialog.Show();
        }

        /// <summary>
        /// Displays a dialog with a title, text and a text input
        /// </summary>
        /// <param name="title">The title of the dialog</param>
        /// <param name="text">The text of the dialog</param>
        /// <param name="ok">The text for the positive button</param>
        /// <param name="cancel">The text for the negative button</param>
        /// <param name="placeholder">The placeholder of the input text field</param>
        /// <param name="callback">Callback method to be called when either the positive or negative button is pressed</param>
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

        /// <summary>
        /// Dismisses the text input dialog
        /// </summary>
        public void DismissInputDialog()
        {
            if (inputDialog != null)
            {
                inputDialog.Dismiss();
                inputDialog = null;
            }
        }

        /// <summary>
        /// Returns a bitmap from the image source
        /// </summary>
        /// <param name="imageSource">The ImageSource for the image</param>
        /// <param name="context">The context</param>
        /// <returns>A bitmap</returns>
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
                //Any other kind of source handler which has been added to android or are not supported will throw this exception 
                throw new NotImplementedException();
            }

            var bitmap = Task.Run<Bitmap>(()=> handler.LoadImageAsync(imageSource, context)).Result;

            return bitmap;
        }

    }
}