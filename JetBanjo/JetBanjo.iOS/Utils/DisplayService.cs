using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private static UIAlertController activitydialog;
        private static UIActivityIndicatorView activityIndicator;
        private static UIAlertController inputDialog;

        public void ShowDialog(string title, string text, ImageSource source, Action callback)
        {
            dialog = UIAlertController.Create(title, text, UIAlertControllerStyle.Alert); //Creates a AlertController from the title and text
            if (source != null) //If the image source is not null, load the image and adds it to the controller
                dialog.View.AddSubview(new UIImageView(GetImageFromImageSourceAsync(source)));
                UIApplication.SharedApplication.Windows[0].RootViewController.PresentViewController(dialog, true, () => { }); //Show the dialog
            if (callback != null)   
            { //If the callback is not null, we create an ok button, when pressed execute the callback
                var action = UIAlertAction.Create(Translator.Translate("ok"), UIAlertActionStyle.Default, ((a) => { callback(); }));
                dialog.AddAction(action); //Add it to the controller
            }
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
        public void ShowDialog(string title, string text, ImageSource source)
        {
            ShowDialog(title, text, source, null);
        }
        public void ShowDialog(string title, string text, Action callback)
        {
            ShowDialog(title, text, null, callback);
        }

        public void ShowDialog(string title, string text)
        {
            ShowDialog(title, text, null, null);
        }
        public void DismissActivityIndicator()
        {
            activitydialog?.DismissViewController(true, () => { });
        }

        public void DismissDialog()
        {
            dialog?.DismissViewController(true, () => { });
        }

        public void DismissInputDialog()
        {
            inputDialog?.DismissViewController(true, () => { });
        }

        public void ShowActivityIndicator()
        {
            activitydialog = UIAlertController.Create("", "", UIAlertControllerStyle.Alert);
            activitydialog.View.Opaque = false;
            activitydialog.View.Alpha = 0;
            activityIndicator = new UIActivityIndicatorView(activitydialog.View.Bounds);
            activityIndicator.AutoresizingMask = UIViewAutoresizing.All;
            activityIndicator.ActivityIndicatorViewStyle = UIActivityIndicatorViewStyle.Gray;
            activityIndicator.StartAnimating();
            activitydialog.View.AddSubview(activityIndicator);
            UIApplication.SharedApplication.Windows[0].RootViewController.PresentViewController(activitydialog, true, () => { });
        }
        public void ShowInputDialog(string title, string text, string ok, string hint, Action<string> callback)
        {
            ShowInputDialog(title, text, ok, null, hint, null, (b,s) => { callback(s); });
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
                callback(true,input.Text);
            }));
            if(cancel != null)
                inputDialog.AddAction(UIAlertAction.Create(cancel, UIAlertActionStyle.Cancel, (x) =>
                {
                    callback(false, input.Text);
                }));
            UIApplication.SharedApplication.Windows[0].RootViewController.PresentViewController(inputDialog, true, () => { });
        }

        public void ShowToast(string text, bool isLong)
        {
            
        }
    }
}