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
            
        }

        public void DismissDialog()
        {
            
        }

        public void DismissInputDialog()
        {
            
        }

        public void ShowActivityIndicator()
        {

        }
        public void ShowInputDialog(string title, string text, string ok, string hint, Action<string> callback)
        {
          
        }

        public void ShowInputDialog(string title, string text, string ok, string hint, string placeholder, Action<string> callback)
        {
            
        }

        public void ShowInputDialog(string title, string text, string ok, string cancel, string hint, Action<bool, string> callback)
        {
        
        }

        public void ShowInputDialog(string title, string text, string ok, string cancel, string hint, string placeholder, Action<bool, string> callback)
        {
           
        }

        public void ShowToast(string text, bool isLong)
        {
            
        }
    }
}