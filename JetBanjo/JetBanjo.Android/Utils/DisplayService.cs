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
using Android.Views.InputMethods;

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
        /// Displays a dialog with a title and text
        /// </summary>
        /// <param name="title">The title of the dialog</param>
        /// <param name="text">The text of the dialog</param>
        public void ShowDialog(string title, string text)
        {
            //Chain call
            ShowDialog(title, text, null, null);
        }

        /// <summary>
        /// Displays a dialog with a title, text and icon
        /// </summary>
        /// <param name="title">The title of the dialog</param>
        /// <param name="text">The text of the dialog</param>
        /// <param name="source">The image source for the icon</param>
        public void ShowDialog(string title, string text, ImageSource source)
        {
            ShowDialog(title, text, source, null);
        }


        /// <summary>
        /// Displays a dialog with a title and text
        /// </summary>
        /// <param name="title">The title of the dialog</param>
        /// <param name="text">The text of the dialog</param>
        /// <param name="callback">The callback when the users press ok</param>
        public void ShowDialog(string title, string text, Action callback)
        {
            //Chain call
            ShowDialog(title, text, null, callback);
        }

        /// <summary>
        /// Displays a dialog with a title, text and icon
        /// </summary>
        /// <param name="title">The title of the dialog</param>
        /// <param name="text">The text of the dialog</param>
        /// <param name="source">The image source for the icon</param>
        /// <param name="callback">The callback when the users press ok</param>
        public void ShowDialog(string title, string text, ImageSource source, Action callback)
        {
            if (iconDialog == null)
            {
                AlertDialog.Builder builder = new AlertDialog.Builder(MainActivity.Context);
                if (source != null)
                {
                    Drawable icon = new BitmapDrawable(GetImageFromImageSourceAsync(source, Android.App.Application.Context));
                    builder.SetIcon(icon);
                }
                if (!string.IsNullOrWhiteSpace(title))
                    builder.SetTitle(title);
                if (!string.IsNullOrWhiteSpace(text))
                    builder.SetMessage(text);
                builder.SetPositiveButton(Translator.Translate("ok"), ((x, y) => { DismissDialog(); callback?.Invoke(); })); //If there is a callback, invoke it
                builder.SetCancelable(false); //Such that it can not be cancled by clicking outside the dialog
                iconDialog = builder.Create();
                iconDialog.Show();
            }
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
            if (indicator == null)
            {
                Android.Widget.ProgressBar pbar = new Android.Widget.ProgressBar(MainActivity.Context);
                pbar.IndeterminateDrawable.SetColorFilter(new Android.Graphics.Color(ContextCompat.GetColor(MainActivity.Context, Resource.Color.primary)), PorterDuff.Mode.SrcAtop); //Sets the color
                indicator = new Dialog(MainActivity.Context, Resource.Style.MyTheme_TransparentDialog); //Transperent theme
                indicator.RequestWindowFeature((int)WindowFeatures.NoTitle); //Removes the title
                indicator.SetContentView(pbar);
                indicator.Window.SetBackgroundDrawable(new ColorDrawable(Android.Graphics.Color.Transparent)); //Removes the background
                indicator.Window.ClearFlags(WindowManagerFlags.DimBehind); //Removes the dim behind the dialog
                indicator.SetCancelable(false); //Such that it can not be cancled by clicking outside the indicator
                indicator.Show();
            }
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
        /// <param name="hint">The placeholder of the input text field</param>
        /// <param name="callback">Callback method to be called when the positive button is pressed</param>
        public void ShowInputDialog(string title, string text, string ok, string hint, Action<string> callback)
        {
            //Chain call. introduce a new action that take the two required parameters and just uses the string for the callback
            ShowInputDialog(title, text, ok, null, hint, null, ((b, s) => { callback(s); }));
        }


        /// <summary>
        /// Displays a dialog with a title, text and a text input
        /// </summary>
        /// <param name="title">The title of the dialog</param>
        /// <param name="text">The text of the dialog</param>
        /// <param name="ok">The text for the positive button</param>
        /// <param name="hint">The placeholder of the input text field</param>
        /// <param name="placeholder">The placeholder of the input text field</param>
        /// <param name="callback">Callback method to be called when the positive button is pressed</param>
        public void ShowInputDialog(string title, string text, string ok, string hint, string placeholder, Action<string> callback)
        {
            //Chain call. introduce a new action that take the two required parameters and just uses the string for the callback
            ShowInputDialog(title, text, ok, null, hint, placeholder, ((b, s) => { callback(s); }));
        }

        /// <summary>
        /// Displays a dialog with a title, text and a text input
        /// </summary>
        /// <param name="title">The title of the dialog</param>
        /// <param name="text">The text of the dialog</param>
        /// <param name="ok">The text for the positive button</param>
        /// <param name="cancel">The text for the negative button</param>
        /// <param name="hint">The hint of the input text field</param>
        /// <param name="callback">Callback method to be called when either the positive or negative button is pressed</param>
        public void ShowInputDialog(string title, string text, string ok, string cancel, string hint, Action<bool, string> callback)
        {
            //Chain call.
            ShowInputDialog(title, text, ok, cancel, hint, null, callback);
        }

        /// <summary>
        /// Displays a dialog with a title, text and a text input
        /// </summary>
        /// <param name="title">The title of the dialog</param>
        /// <param name="text">The text of the dialog</param>
        /// <param name="ok">The text for the positive button</param>
        /// <param name="cancel">The text for the negative button</param>
        /// <param name="hint">The hint of the input text field</param>
        /// <param name="placeholder">The placeholder of the input text field</param>
        /// <param name="callback">Callback method to be called when either the positive or negative button is pressed</param>
        public void ShowInputDialog(string title, string text, string ok, string cancel, string hint, string placeholder, Action<bool, string> callback)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(MainActivity.Context);
            LinearLayout layout = new LinearLayout(MainActivity.Context); //Creates a linearlayout to hold the edittext
            layout.Focusable = true; //Sets such that this layout can be focused
            layout.FocusableInTouchMode = true; //Needed for the layout to get focus before edittext
            layout.DescendantFocusability = DescendantFocusability.BeforeDescendants; //Needed for the layout to get focus before edittext
            layout.SetGravity(GravityFlags.Center); //Sets such that the edittext should be centered in the layout
            EditText userInput = new EditText(MainActivity.Context);
            userInput.SetMinimumWidth(500); //Sets the minimum width of the edittext field
            userInput.Gravity = GravityFlags.CenterHorizontal; //Sets such that the text is centered horizontal

            
            if(!string.IsNullOrWhiteSpace(hint))
                userInput.Hint = hint;
            if(!string.IsNullOrWhiteSpace(placeholder))
                userInput.Text = placeholder;
            userInput.InputType = Android.Text.InputTypes.NumberFlagDecimal | Android.Text.InputTypes.ClassNumber;
            userInput.FocusChange += ((sender, eventArgs) => { if (userInput.HasFocus) { userInput.Text = ""; ShowKeyboard(userInput); } }); //Clears the placeholder text
            layout.AddView(userInput); //Adds the edittext to the layout
            if(!string.IsNullOrWhiteSpace(title))
                builder.SetTitle(title);
            if(!string.IsNullOrWhiteSpace(text))
                builder.SetMessage(text);
            builder.SetView(layout); //Sets the layout to be the view of the dialog
            layout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent); //Sets the hight and width of the layout
            if (!string.IsNullOrWhiteSpace(ok))
                builder.SetPositiveButton(ok, ((sender, args) => { DismissInputDialog(); callback(true, userInput.Text); }));
            if (!string.IsNullOrWhiteSpace(cancel))
                builder.SetNegativeButton(cancel, ((sender, args) => { DismissInputDialog(); callback(false, null); }));
            builder.SetCancelable(false); //Such that it can not be cancled by clicking outside the dialog
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
        /// Displays a short (default) toast
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="isLong">If the toast should be long</param>
        public void ShowToast(string text, bool isLong)
        {
            if(isLong)
                Toast.MakeText(MainActivity.Context, text, ToastLength.Long).Show();
            else
                Toast.MakeText(MainActivity.Context, text, ToastLength.Short).Show();
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

        private void ShowKeyboard(Android.Views.View view)
        {
            view.RequestFocus();

            InputMethodManager inputMethodManager = MainActivity.Context.GetSystemService(Context.InputMethodService) as InputMethodManager;
            inputMethodManager.ShowSoftInput(view, ShowFlags.Forced);
            inputMethodManager.ToggleSoftInput(ShowFlags.Forced, HideSoftInputFlags.ImplicitOnly);
        }

        private void HideKeyboard(Android.Views.View view)
        {
            InputMethodManager inputMethodManager = MainActivity.Context.GetSystemService(Context.InputMethodService) as InputMethodManager;
            inputMethodManager.HideSoftInputFromWindow(view.WindowToken, HideSoftInputFlags.None);
        }

    }
}