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
        private static UIAlertController toast;

        public void ShowDialog(string title, string text, ImageSource source, Action callback)
        {
            Console.WriteLine("Test 1");
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
            Console.WriteLine("Test 2");
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
            Console.WriteLine("Test 3");
            ShowDialog(title, text, source, null);
        }
        public void ShowDialog(string title, string text, Action callback)
        {
            Console.WriteLine("Test 4");
            ShowDialog(title, text, null, callback);
        }

        public void ShowDialog(string title, string text)
        {
            Console.WriteLine("Test 5");
            ShowDialog(title, text, null, null);
        }
        public void DismissActivityIndicator()
        {
            Console.WriteLine("Test 6");
            activitydialog?.DismissViewController(true, () => { });
        }

        public void DismissDialog()
        {
            Console.WriteLine("Test 7");
            dialog?.DismissViewController(true, () => { });
        }

        public void DismissInputDialog()
        {
            Console.WriteLine("Test 8");
            inputDialog?.DismissViewController(true, () => { });
        }

        public void ShowActivityIndicator()
        {
            Console.WriteLine("Test 9");
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
            Console.WriteLine("Test 10");
            ShowInputDialog(title, text, ok, null, hint, null, (b,s) => { callback(s); });
        }

        public void ShowInputDialog(string title, string text, string ok, string hint, string placeholder, Action<string> callback)
        {
            Console.WriteLine("Test 11");
            ShowInputDialog(title, text, ok, null, hint, placeholder, (b, s) => { callback(s); });

        }

        public void ShowInputDialog(string title, string text, string ok, string cancel, string hint, Action<bool, string> callback)
        {
            Console.WriteLine("Test 12");
            ShowInputDialog(title, text, ok, cancel, hint, null, callback);
        }

        public void ShowInputDialog(string title, string text, string ok, string cancel, string hint, string placeholder, Action<bool, string> callback)
        {
            Console.WriteLine("Test 13");
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
            Console.WriteLine("Test 14");
            double seconds = 2.0;
            if (isLong)
                seconds = 3.5;

                var alertDelay = NSTimer.CreateScheduledTimer(seconds, (obj) => {
                    toast.DismissViewController(true,()=> { });
                    });
                toast = UIAlertController.Create(null, text, UIAlertControllerStyle.Alert);
                UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(toast, true, null);
        }
    }
}