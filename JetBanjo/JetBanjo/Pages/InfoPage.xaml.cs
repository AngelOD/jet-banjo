using JetBanjo.Resx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBanjo.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using JetBanjo.Utils;

namespace JetBanjo.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoPage : CContentPage
    {
        private ObservableCollection<TextInfoPage> collection = new ObservableCollection<TextInfoPage>();


        public InfoPage()
        {
            InitializeComponent();
            infoListView.ItemsSource = collection;


            infoListView.ItemSelected += (sender, e) =>
            {
                if (infoListView.SelectedItem == null)
                    return;

                Navigation.PushAsync((TextInfoPage)infoListView.SelectedItem);
                infoListView.SelectedItem = null;
            };

            AddMenuItem(AppResources.q_indoor_climate);
            AddMenuItem(AppResources.q_climate_causes);
            AddMenuItem(AppResources.q_climate_effects);
            AddMenuItem(AppResources.q_co2);
            AddMenuItem(AppResources.q_humidity);
            AddMenuItem(AppResources.q_temperature);
            AddMenuItem(AppResources.q_voc);
            AddMenuItem(AppResources.q_light);
            AddMenuItem(AppResources.q_sound);
        }

        private void AddMenuItem(string str)
        {
            string[] q = str.Split(':');
            collection.Add(new TextInfoPage(q[0], q[1]));
        }
    }
}