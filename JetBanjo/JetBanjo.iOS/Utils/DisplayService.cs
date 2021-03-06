﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Foundation;
using JetBanjo.iOS.Utils;
using JetBanjo.Utils;
using JetBanjo.Utils.DependencyService;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(DisplayService))]
namespace JetBanjo.iOS.Utils
{
    public class DisplayService : IDisplayService
    {

        private static UIAlertController dialog;
        private static UIAlertController inputDialog;
        private static UIActivityIndicatorView activityIndicator;
        private static UIAlertController activityDialog;
        private static UIAlertController toast;
        private static UIAlertController searchListDialog;

        public void ShowDialog(string title, string text)
        {
            ShowDialog(title, text, null, null);
        }

        public void ShowDialog(string title, string text, ImageSource source)
        {
            ShowDialog(title, text, source, null);
        }

        public void ShowDialog(string title, string text, Action callback)
        {
            ShowDialog(title, text, null, callback);
        }

        public void ShowDialog(string title, string text, ImageSource source, Action callback)
        {
            dialog = UIAlertController.Create(title, text, UIAlertControllerStyle.Alert); //Creates a AlertController from the title and text
            if (source != null) //If the image source is not null, load the image and adds it to the controller
                dialog.View.AddSubview(new UIImageView(GetImageFromImageSourceAsync(source)));
            if (callback != null)
            { //If the callback is not null, we create an ok button, when pressed execute the callback
                var action = UIAlertAction.Create(Translator.Translate("ok"), UIAlertActionStyle.Default, ((a) => { callback(); }));
                dialog.AddAction(action); //Add it to the controller
            }
            GetTopViewController().PresentViewController(dialog, true, null); //Show the dialog
        }

        public void DismissDialog()
        {
            dialog?.DismissViewController(true, null);
        }

        public void ShowActivityIndicator()
        {
            activityDialog = UIAlertController.Create("", "", UIAlertControllerStyle.Alert);
            activityDialog.View.Opaque = false;
            activityDialog.View.Alpha = 0;
            activityIndicator = new UIActivityIndicatorView(activityDialog.View.Bounds);
            activityIndicator.AutoresizingMask = UIViewAutoresizing.All;
            activityIndicator.ActivityIndicatorViewStyle = UIActivityIndicatorViewStyle.Gray;
            activityIndicator.StartAnimating();
            activityDialog.View.AddSubview(activityIndicator);
            GetTopViewController().PresentViewController(activityDialog, true, null);
        }

        public void DismissActivityIndicator()
        {
            activityDialog?.DismissViewController(true, null);
        }

        public void ShowInputDialog(string title, string text, string ok, string hint, Action<string> callback)
        {
            ShowInputDialog(title, text, ok, null, hint, null, (b, s) => { callback(s); });
        }

        public void ShowInputDialog(string title, string text, string ok, string hint, string placeholder, Action<string> callback)
        {
            ShowInputDialog(title, text, ok, null, hint, placeholder, (b, s) => { callback(s); });
        }

        public void ShowInputDialog(string title, string text, string ok, string cancel, string hint, Action<bool, string> callback)
        {
            ShowInputDialog(title, text, ok, cancel, hint, null, callback);
        }

        public void ShowInputDialog(string title, string text, string ok, string cancel, string hint, string placeholder, Action<bool, string> callback)
        {
            inputDialog = UIAlertController.Create(title, text, UIAlertControllerStyle.Alert);
            UITextField input = null;

            inputDialog.AddTextField((textField) =>
                {
                    input = textField;

                    input.Placeholder = hint;
                    if (placeholder != null)
                        input.Text = placeholder;
                    input.AutocorrectionType = UITextAutocorrectionType.No;
                    input.KeyboardType = UIKeyboardType.Default;
                    input.ReturnKeyType = UIReturnKeyType.Done;
                    input.ClearButtonMode = UITextFieldViewMode.WhileEditing;
                });
            inputDialog.AddAction(UIAlertAction.Create(ok, UIAlertActionStyle.Default, (x) =>
                {
                    callback(true, input.Text);
                }));
            if (cancel != null)
                inputDialog.AddAction(UIAlertAction.Create(cancel, UIAlertActionStyle.Cancel, (x) =>
                    {
                        callback(false, input.Text);
                    }));
            GetTopViewController().PresentViewController(inputDialog, true, null);
        }

        public void DismissInputDialog()
        {
            inputDialog?.DismissViewController(true, null);
        }

        public void ShowToast(string text, bool isLong)
        {
            double seconds = 2.0;
            if (isLong)
                seconds = 3.5;

            var alertDelay = NSTimer.CreateScheduledTimer(seconds, (obj) =>
            {
                toast.DismissViewController(true, null);
            });
            toast = UIAlertController.Create(null, text, UIAlertControllerStyle.Alert);
            GetTopViewController().PresentViewController(toast, true, null);
        }


        private UIImage GetImageFromImageSourceAsync(ImageSource imageSource)
        {
            IImageSourceHandler handler = null;

            if (imageSource is FileImageSource)
            {
                handler = new FileImageSourceHandler();
            }
            else if (imageSource is StreamImageSource)
            {
                handler = new StreamImagesourceHandler(); // sic
            }
            else if (imageSource is UriImageSource)
            {
                handler = new ImageLoaderSourceHandler(); // sic
            }
            else
            {
                throw new NotImplementedException();
            }

            var image = Task.Run<UIImage>(() => handler.LoadImageAsync(imageSource)).Result;

            return image;
        }

        private static UIViewController GetTopViewController()
        {
            var vc = UIApplication.SharedApplication.KeyWindow.RootViewController;
            while (vc.PresentedViewController != null)
                vc = vc.PresentedViewController;
            return vc;
        }

        public void ShowSearchListDialog<T>(List<T> input, string title, string cancel, string hint, Action<bool, T> callback) where T : class
        {
            throw new NotImplementedException();
        }

        public void DismissSearchListDialog()
        {
            throw new NotImplementedException();
        }
    }
}