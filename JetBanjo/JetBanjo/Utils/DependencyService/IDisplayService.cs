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
        /// <param name="placeholder">The placeholder of the input text field</param>
        /// <param name="callback">Callback method to be called when the positive button is pressed</param>
        void ShowInputDialog(string title, string text, string ok, string placeholder, Action<string> callback);

        /// <summary>
        /// Displays a dialog with a title, text and a text input
        /// </summary>
        /// <param name="title">The title of the dialog</param>
        /// <param name="text">The text of the dialog</param>
        /// <param name="ok">The text for the positive button</param>
        /// <param name="cancel">The text for the negative button</param>
        /// <param name="placeholder">The placeholder of the input text field</param>
        /// <param name="callback">Callback method to be called when either the positive or negative button is pressed</param>
        void ShowInputDialog(string title, string text, string ok, string cancel, string placeholder, Action<bool,string> callback);

        /// <summary>
        /// Dismisses the text input dialog
        /// </summary>
        void DismissInputDialog();
    }
}
