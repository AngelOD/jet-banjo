﻿using System;
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
            if (callback != null)   
            { //If the callback is not null, we create an ok button, when pressed execute the callback
                var action = UIAlertAction.Create(Translator.Translate("ok"), UIAlertActionStyle.Default, ((a) => { callback(); }));
                dialog.AddAction(action); //Add it to the controller
            }
            if (source != null) //If the image source is not null, load the image and adds it to the controller
                dialog.View.AddSubview(new UIImageView(GetImageFromImageSourceAsync(source)));
            UIApplication.SharedApplication.Windows[0].RootViewController.PresentViewController(dialog, true, () => { }); //Show the dialog
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
        public void ShowDialog(string title, string text, ImageSource source, Action callback)
        {
            UIAlertController alert = new UIAlertController()
            {
                title = "ale",
                text = "test",
            } 
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
        public void ShowDialog(string title, string text, Action callback)
        {
            throw new NotImplementedException();
        }

        public void ShowDialog(string title, string text)
        {
            UIAlertView alert = new UIAlertView()
            {
                Title = "alert title",
                Message = "this is a simple alert"
            };
            alert.AddButton("Ok");
            alert.Show();
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