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
    public partial class StakeHoldersList : ContentPage
    {
        private List<StakeHolder> StakeHolders;
        public StakeHoldersList()
        {
            InitializeComponent();
            DummyDataInitialization();
            listView.ItemsSource = StakeHolders;
        }

        private void DummyDataInitialization()
        {
            StakeHolders = new List<StakeHolder>();
            StakeHolders.Add(new StakeHolder { Name = "Mocca", Designation = "B-Bld -as - 0.1" });
            StakeHolders.Add(new StakeHolder { Name = "Mocca", Designation = "B-Bld -as - 0.1" });
            StakeHolders.Add(new StakeHolder { Name = "Mocca", Designation = "B-Bld -as - 0.1" });
            StakeHolders.Add(new StakeHolder { Name = "Mocca", Designation = "B-Bld -as - 0.1" });
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new StakeholderDetail());
        }

        private void Search_Clicked(object sender, EventArgs e)
        {
            if (SearchEntry.IsVisible)
            {
                SearchEntry.Text = string.Empty;
                SearchEntry.IsVisible= false;
            }
            else
            {
                SearchEntry.IsVisible = true;
            }
        }
    }

    
}