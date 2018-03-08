using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static JetBanjo.Pages.MasterDetail.MasterMaster;

namespace JetBanjo.Pages.MasterDetail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : MasterDetailPage
    {
        //counter used for id for the pages that get registered
        private static int pageCounter = 0;
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
            Push(item.Page);

            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }

        /// <summary>
        /// Pushes the page to be the current detail and saves the old as history
        /// </summary>
        /// <param name="page">The page to show</param>
        private void Push(Page page)
        {
            history.Push(Detail);
            Detail = new NavigationPage(page);
        }

        /// <summary>
        /// Registers the page to the underlaying collection
        /// </summary>
        /// <param name="page">The page to be shown</param>
        /// <param name="name">The name / title of the page</param>
        public void Register(Page page, string name)
        {
            MasterMenuItem item = new MasterMenuItem(page)
            {
                Id = pageCounter,
                Title = name
            };
            pageCounter++;
            
            ((MasterMasterViewModel)MasterPage.BindingContext).MenuItems.Add(item);
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