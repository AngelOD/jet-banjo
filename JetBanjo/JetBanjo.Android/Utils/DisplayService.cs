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
        private static AlertDialog searchList;


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
            iconDialog?.Dismiss();
            iconDialog = null;
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
            indicator?.Dismiss();
            indicator = null;
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
            inputDialog?.Dismiss();
            inputDialog = null;
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
        /// Displays a searchable list dialog.
        /// </summary>
        /// <typeparam name="T">The type of the list and object in the callback</typeparam>
        /// <param name="input">The list of objects to choose from</param>
        /// <param name="title">The title of the dialog</param>
        /// <param name="cancel">The text for the cancel button, can be null</param>
        /// <param name="hint">The text for the hint, can be null</param>
        /// <param name="callback">The method to be called when an item from the list is chosen or cancel have been pressed. 
        /// The first parameter is true if an item have been selected or false if cancel has been pressed
        /// The second parameter is the item if selected or null if cancel have been pressed </param>
        public void ShowSearchListDialog<T>(List<T> input, string title, string cancel, string hint, Action<bool, T> callback) where T : class 
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(MainActivity.Context);
            LinearLayout layout = new LinearLayout(MainActivity.Context); //Creates a linearlayout to hold the edittext and listview
            layout.Focusable = true; //Sets such that this layout can be focused
            layout.FocusableInTouchMode = true; //Needed for the layout to get focus before edittext
            layout.DescendantFocusability = DescendantFocusability.BeforeDescendants; //Needed for the layout to get focus before edittext
            layout.SetGravity(GravityFlags.Center); //Sets such that the edittext and listview should be centered in the layout
            layout.Orientation = Orientation.Vertical; //Such that the edittext and listview is stacked vertical.
            layout.SetPadding(64, 0, 64, 32); //Sets the padding for the content
            EditText userInput = new EditText(MainActivity.Context);
            userInput.SetMinimumWidth(500); //Sets the minimum width of the edittext field
            userInput.Gravity = GravityFlags.CenterHorizontal; //Sets such that the text is centered horizontal

            Android.Widget.ListView listView = new Android.Widget.ListView(MainActivity.Context);
            ArrayAdapter<T> adapter = new ArrayAdapter<T>(MainActivity.Context, Android.Resource.Layout.SimpleListItem1, input);
            listView.Adapter = adapter;
            listView.ItemClick += (sender, args) => { DismissSearchListDialog(); HideKeyboard(userInput); callback(true, adapter.GetItem(args.Position)); }; //When an item is clicked return it to the caller
            userInput.TextChanged += (sender, args) => { adapter.Filter.InvokeFilter(userInput.Text); }; //When the edittext text changes filter the listview
            listView.SetPadding(0, 16, 0, 0); //Adds some padding between the edittext and listview

            if (!string.IsNullOrWhiteSpace(hint))
                userInput.Hint = hint;
            userInput.InputType = Android.Text.InputTypes.ClassText;
            layout.AddView(userInput); //Adds the edittext to the layout
            layout.AddView(listView);
            if (!string.IsNullOrWhiteSpace(title))
                builder.SetTitle(title);
            builder.SetView(layout); //Sets the layout to be the view of the dialog
            layout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent); //Sets the hight and width of the layout
            if (!string.IsNullOrWhiteSpace(cancel))
                builder.SetNegativeButton(cancel, ((sender, args) => { DismissSearchListDialog(); HideKeyboard(userInput); callback(false, null); }));
            searchList = builder.Create();
            searchList.Show();
        }

        /// <summary>
        /// Dismisses the searchable list dialog
        /// </summary>
        public void DismissSearchListDialog()
        {
            searchList?.Dismiss();
            searchList = null;
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