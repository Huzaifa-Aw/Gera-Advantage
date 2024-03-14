using GeraAdvantage.SQLServices;
using GeraAdvantage.Utils;
using GeraAdvantage.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GeraAdvantage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProjectDetails_Page : ContentPage
    {
        private List<CheckListType> CheckListTypes;
        private string _projectId= string.Empty;
        public ProjectDetails_Page(string projectId)
        {
            InitializeComponent();
            _projectId = projectId;
            InitializeChecklists();
        }

        private void InitializeChecklists()
        {
            ChecklistSQLServices checklistSQLServices = new ChecklistSQLServices();
            CheckListTypes = checklistSQLServices.GetChecklistTypes();
            if (CheckListTypes.Count > 0)
            {
                listView.ItemsSource = CheckListTypes;
                listView.HeightRequest = CheckListTypes.Count * 60;
            }
        }


        private async void StakeHolders_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StakeHoldersList());
        }
        private async void PotentialNCManagement_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NCList());
        }
        private async void NCList_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NonConformityFiltersTemplate());
        }
        private async void ConformityDashboard_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ConformityDashboard());
        }
        private async void NCDashboard_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NCDashboard());
        }
        private async void BtnCreateNC_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateNC());
        }
        private async void NCManagement_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NCManagement());
        }
        //private async void BtnChecklist_Tapped(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new Checklists_Page());
        //}
        private async void BtnSnaglist_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateSnaglist());
        }
        private async void ProjectDashboard_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProjectDashboard());
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("asd", "asd", "asd");
        }

        private async void listView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var SelectedItem = (CheckListType)e.Item;
            await Navigation.PushAsync(new Checklists_Page(SelectedItem.Title, Convert.ToInt32(SelectedItem.Id)));

        }
    }
}