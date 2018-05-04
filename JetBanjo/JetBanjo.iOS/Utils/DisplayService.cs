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
        private static UIActivityIndicatorView activityIndicator;

        public void ShowDialog(string title, string text, ImageSource source, Action callback)
        {
            Console.WriteLine("Test 1");
            void Display()
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
            if (dialog != null)
            {
                dialog.DismissViewController(true, () =>
                {
                    Display();
                });
            }
            else
            {
                Display();
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
            dialog?.DismissViewController(true, () => { });
        }

        public void DismissDialog()
        {
            Console.WriteLine("Test 7");
            dialog?.DismissViewController(true, () => { });
        }

        public void DismissInputDialog()
        {
            Console.WriteLine("Test 8");
            dialog?.DismissViewController(true, () => { });
        }
        public void ShowActivityIndicator()
        {
            Console.WriteLine("Test 9");
            void Display()
            {
                dialog = UIAlertController.Create("", "", UIAlertControllerStyle.Alert);
                dialog.View.Opaque = false;
                dialog.View.Alpha = 0;
                activityIndicator = new UIActivityIndicatorView(dialog.View.Bounds);
                activityIndicator.AutoresizingMask = UIViewAutoresizing.All;
                activityIndicator.ActivityIndicatorViewStyle = UIActivityIndicatorViewStyle.Gray;
                activityIndicator.StartAnimating();
                dialog.View.AddSubview(activityIndicator);
                UIApplication.SharedApplication.Windows[0].RootViewController.PresentViewController(dialog, true, () => { });
            }
            if (dialog != null)
            {
                dialog.DismissViewController(true, () =>
                {
                    Display();
                });
            }
            else
            {
                Display();
            }
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
            void Display()
            {
                dialog = UIAlertController.Create(title, text, UIAlertControllerStyle.Alert);
                UITextField input = null;

                dialog.AddTextField((textField) =>
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
                dialog.AddAction(UIAlertAction.Create(ok, UIAlertActionStyle.Default, (x) =>
                {
                    callback(true, input.Text);
                }));
                if (cancel != null)
                    dialog.AddAction(UIAlertAction.Create(cancel, UIAlertActionStyle.Cancel, (x) =>
                    {
                        callback(false, input.Text);
                    }));
                UIApplication.SharedApplication.Windows[0].RootViewController.PresentViewController(dialog, true, () => { });
            }
            if (dialog != null)
            {
                dialog.DismissViewController(true, () =>
                {
                    Display();
                });
            }
            else
            {
                Display();
            }
        }

        public void ShowToast(string text, bool isLong)
        {
            Console.WriteLine("Test 14");
            void Display()
            {
                double seconds = 2.0;
                if (isLong)
                    seconds = 3.5;

                var alertDelay = NSTimer.CreateScheduledTimer(seconds, (obj) => {
                    dialog.DismissViewController(true, () => { });
                });
                dialog = UIAlertController.Create(null, text, UIAlertControllerStyle.Alert);
                UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(dialog, true, null);
            }
            if (dialog != null)
            {
                dialog.DismissViewController(true, () =>
                {
                    Display();
                });
            }
            else
            {
                Display();
            }
        }
    }
}