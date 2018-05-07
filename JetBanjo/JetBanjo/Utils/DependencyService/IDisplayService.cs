using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JetBanjo.Utils.DependencyService
{
    public interface IDisplayService
    {
        /// <summary>
        /// Displays a dialog with a title, text and icon
        /// </summary>
        /// <param name="title">The title of the dialog</param>
        /// <param name="text">The text of the dialog</param>
        /// <param name="source">The image source for the icon</param>
        void ShowDialog(string title, string text, ImageSource source);

        /// <summary>
        /// Displays a dialog with a title and text
        /// </summary>
        /// <param name="title">The title of the dialog</param>
        /// <param name="text">The text of the dialog</param>
        void ShowDialog(string title, string text);

        /// <summary>
        /// Displays a dialog with a title, text and icon
        /// </summary>
        /// <param name="title">The title of the dialog</param>
        /// <param name="text">The text of the dialog</param>
        /// <param name="source">The image source for the icon</param>
        /// <param name="callback">The callback when the users press ok</param>
        void ShowDialog(string title, string text, ImageSource source, Action callback);

        /// <summary>
        /// Displays a dialog with a title and text
        /// </summary>
        /// <param name="title">The title of the dialog</param>
        /// <param name="text">The text of the dialog</param>
        /// <param name="callback">The callback when the users press ok</param>
        void ShowDialog(string title, string text, Action callback);

        /// <summary>
        /// Dismisses the text / icon dialog
        /// </summary>
        void DismissDialog();

        /// <summary>
        /// Displays an activity indicator that cannot be dismissed by the user
        /// </summary>
        void ShowActivityIndicator();

        /// <summary>
        /// Dismisses the activity indicator
        /// </summary>
        void DismissActivityIndicator();

        /// <summary>
        /// Displays a dialog with a title, text and a text input
        /// </summary>
        /// <param name="title">The title of the dialog</param>
        /// <param name="text">The text of the dialog</param>
        /// <param name="ok">The text for the positive button</param>
        /// <param name="hint">The placeholder of the input text field</param>
        /// <param name="callback">Callback method to be called when the positive button is pressed</param>
        void ShowInputDialog(string title, string text, string ok, string hint, Action<string> callback);

        /// <summary>
        /// Displays a dialog with a title, text and a text input
        /// </summary>
        /// <param name="title">The title of the dialog</param>
        /// <param name="text">The text of the dialog</param>
        /// <param name="ok">The text for the positive button</param>
        /// <param name="hint">The placeholder of the input text field</param>
        /// <param name="placeholder">The placeholder of the input text field</param>
        /// <param name="callback">Callback method to be called when the positive button is pressed</param>
        void ShowInputDialog(string title, string text, string ok, string hint, string placeholder, Action<string> callback);

        /// <summary>
        /// Displays a dialog with a title, text and a text input
        /// </summary>
        /// <param name="title">The title of the dialog</param>
        /// <param name="text">The text of the dialog</param>
        /// <param name="ok">The text for the positive button</param>
        /// <param name="cancel">The text for the negative button</param>
        /// <param name="hint">The hint of the input text field</param>
        /// <param name="callback">Callback method to be called when either the positive or negative button is pressed</param>
        void ShowInputDialog(string title, string text, string ok, string cancel, string hint, Action<bool, string> callback);

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
        void ShowInputDialog(string title, string text, string ok, string cancel, string hint, string placeholder, Action<bool,string> callback);

        /// <summary>
        /// Dismisses the text input dialog
        /// </summary>
        void DismissInputDialog();

        /// <summary>
        /// Displays a short (default) toast
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="isLong">If the toast should be long</param>
        void ShowToast(string text, bool isLong);

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
        void ShowSearchListDialog<T>(List<T> input, string title, string cancel, string hint, Action<bool, T> callback) where T : class;

        /// <summary>
        /// Dismisses the searchable list dialog
        /// </summary>
        void DismissSearchListDialog();
    }
}
