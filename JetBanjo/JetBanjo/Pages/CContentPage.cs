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
        public CContentPage()
        {
            Style = (Style) Application.Current.Resources["DefaultPageStyle"];
        }

        protected override bool OnBackButtonPressed()
        {
            ((App)App.Current).Master.GoBack();
            return true;
        }
    }
}