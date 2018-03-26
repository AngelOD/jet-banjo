using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
