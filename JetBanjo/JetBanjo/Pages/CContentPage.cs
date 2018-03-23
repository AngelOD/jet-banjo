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

        /// <summary>
        /// Such that all our pages implements our history behaviour.
        /// </summary>
        /// <returns></returns>
        protected override bool OnBackButtonPressed()
        {
            //Acces apps master page and go back to the previous page 
            ((App)App.Current).MasterPage.PreviousPage();
            return true;
        }

    }
}