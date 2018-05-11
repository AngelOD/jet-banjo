using JetBanjo.Resx;
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
        public string Question { get; set; }
        public string Text { get; set; }

        public TextInfoPage()
        {
            InitializeComponent();
        }

        public TextInfoPage(string header, string text)
        {
            InitializeComponent();
            Question = header;
            Text = text;
            Title = header;
            pageText.HorizontalOptions = LayoutOptions.FillAndExpand;
            pageText.VerticalOptions = LayoutOptions.FillAndExpand;
            pageText.HorizontalTextAlignment = TextAlignment.Start;
            pageText.Text = text;
        }

        public override string ToString()
        {
            return Question;
        }

        protected override bool OnBackButtonPressed()
        {
            Navigation.PopAsync();
            return true;
        }
    }
}
