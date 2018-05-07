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
	public partial class TextInfoPage : CContentPage
	{
		public TextInfoPage ()
		{
			InitializeComponent();
		}
        public TextInfoPage(string header, string text)
        {
            InitializeComponent();
            pageHeader.Text = header;
            pageText.Text = text;
        }
	}
}