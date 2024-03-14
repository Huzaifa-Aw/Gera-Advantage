using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static GeraAdvantage.Utils.Entities;

namespace GeraAdvantage.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NonConformityFiltersTemplate : ContentPage
    {
        private List<Project> filterDetails;

        public NonConformityFiltersTemplate()
        {
            BindingContext = this;
            InitializeComponent();
            DummyDataInitialization();
            listView.ItemsSource = filterDetails;
        }

        private void DummyDataInitialization()
        {
            filterDetails = new List<Project>();
            filterDetails.Add(new Project { Title = "Mocca", TotalNCCount = 12, OpenNCCount = 1 ,ClosedNCCount=2});
            filterDetails.Add(new Project { Title = "Espresso", TotalNCCount = 6, OpenNCCount = 43, ClosedNCCount = 3 });
          
        }
        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new NCList());
        }

        private void TotalNCCount_Tapped(object sender, EventArgs e)
        {
                DisplayAlert("Total NC", "Tapped", "OK");
        }
        private void OpenNCCount_Tapped(object sender, EventArgs e)
        {
                DisplayAlert("Open NC", "Tapped", "OK");
            
        }
        private void ClosedNCCount_Tapped(object sender, EventArgs e)
        {
                DisplayAlert("Closed NC", "Tapped", "OK");
        }
    }
}