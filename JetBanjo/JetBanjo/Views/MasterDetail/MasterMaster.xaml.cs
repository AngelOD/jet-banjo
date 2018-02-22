using JetBanjo.Resources;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JetBanjo.Views.MasterDetail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterMaster : ContentPage
    {
        public ListView ListView;

        public MasterMaster()
        {
            InitializeComponent();

            BindingContext = new MasterMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MasterMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterMenuItem> MenuItems { get; set; }

            public MasterMasterViewModel()
            {
                MenuItems = new ObservableCollection<MasterMenuItem>(new[]
                {
                    new MasterMenuItem { Id = 0, Title = AppResources.main },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }
    }
}