using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JetBanjo.Views.MasterDetail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetail : ContentPage
    {
        /// <summary>
        /// This class needs to exist such that the MasterDetail Menu works
        /// </summary>
        public MasterDetail()
        {
            InitializeComponent();
        }
    }
}