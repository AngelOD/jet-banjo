using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JetBanjo.Views.MasterDetail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : MasterDetailPage
    {

        private Stack<Page> history = new Stack<Page>();

        public Master()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += OnItemSelected;

    }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterMenuItem;
            if (item == null)
                return;

            switch (item.Id)
            {
                case 0:
                    Main();
                    break;
                default:
                    break;
            }
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }

        private void Main()
        {
            history.Push(Detail);
            Detail = new NavigationPage(new MainPage());
        }


        /// <summary>
        /// Goes back to the previous page, if there is none mimizes the app
        /// </summary>
        public void GoBack()
        {
            if(history.Count > 0)
            {
                Detail = history.Pop();
            }
            else
            {
                App.Current.MainPage.SendBackButtonPressed(); //The app is minimized
            }
        }
    }
}