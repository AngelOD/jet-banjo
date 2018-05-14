using System;
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
        private static int pageCounter = 0; //Counter used for id for the pages that get registered
        private Stack<Page> history = new Stack<Page>(); //History stack used for the back button on Android

        public Master()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += OnItemSelected;

        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Page page = null;
            var item = e.SelectedItem as MasterMenuItem;
            //If the item does not exist, which is a mistake
            if (item == null)
                return;
            //If the PageType exist we can create a new instance of the class
            if(item.PageType != null)
                page = (Page)Activator.CreateInstance(item.PageType);
            //If the Page is not null then we already have a page to push
            if (item.Page != null)
                page = item.Page;

            //If it is not the same page, push it
            if (page != null && !((NavigationPage) Detail).RootPage.Equals(page))
                Push(page);
                
            IsPresented = false; //Hides the master menu

            MasterPage.ListView.SelectedItem = null; //Reset the selected item back to null
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
        public void Register(Type page, string name)
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
        public void PreviousPage()
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