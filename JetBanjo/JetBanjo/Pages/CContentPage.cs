using JetBanjo.Pages.MasterDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace JetBanjo.Pages
{
	public abstract class CContentPage : ContentPage
    {

        protected override bool OnBackButtonPressed()
        {
            ((App)App.Current).Master.GoBack();
            return true;
        }
    }
}