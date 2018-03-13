using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace JetBanjo.Utils.DependencyService
{
    public interface IDisplayService
    {
        void ShowDialog(string title, string text, ImageSource source);

        void ShowDialog(string title, string text);

        void DismissDialog();
    }
}
