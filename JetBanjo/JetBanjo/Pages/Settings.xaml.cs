﻿using JetBanjo.Utils;
using JetBanjo.Utils.DependencyService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JetBanjo.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Settings : CContentPage
	{
		public Settings ()
		{
			InitializeComponent ();
		}


        public void test(object sender, EventArgs args)
        {
            DataStore.RemoveValue("roomTest"); 

        }
    }
}