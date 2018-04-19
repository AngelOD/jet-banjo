using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using JetBanjo.iOS.Utils;
using JetBanjo.Utils.DependencyService;
using UIKit;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(DisplayService))]
namespace JetBanjo.iOS.Utils
{
    public class DisplayService : IDisplayService
    {
        public void DismissActivityIndicator()
        {
            throw new NotImplementedException();
        }

        public void DismissDialog()
        {
            throw new NotImplementedException();
        }

        public void DismissInputDialog()
        {
            throw new NotImplementedException();
        }

        public void ShowActivityIndicator()
        {
            throw new NotImplementedException();
        }

        public void ShowDialog(string title, string text, ImageSource source)
        {
            UIAlertView alert = new UIAlertView()
            {
                Title = "alert title",
                Message = "this is a simple alert"
            };
            alert.AddButton("Ok");
            alert.Show();
            throw new NotImplementedException();
        }

        public void ShowDialog(string title, string text)
        {
            throw new NotImplementedException();
        }

        public void ShowDialog(string title, string text, ImageSource source, Action callback)
        {
            throw new NotImplementedException();
        }

        public void ShowDialog(string title, string text, Action callback)
        {
            throw new NotImplementedException();
        }

        public void ShowInputDialog(string title, string text, string ok, string hint, Action<string> callback)
        {
            throw new NotImplementedException();
        }

        public void ShowInputDialog(string title, string text, string ok, string hint, string placeholder, Action<string> callback)
        {
            throw new NotImplementedException();
        }

        public void ShowInputDialog(string title, string text, string ok, string cancel, string hint, Action<bool, string> callback)
        {
            throw new NotImplementedException();
        }

        public void ShowInputDialog(string title, string text, string ok, string cancel, string hint, string placeholder, Action<bool, string> callback)
        {
            throw new NotImplementedException();
        }

        public void ShowToast(string text, bool isLong)
        {
            throw new NotImplementedException();
        }
    }
}