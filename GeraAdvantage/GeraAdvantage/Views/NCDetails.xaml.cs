using GeraAdvantage.SQLServices;
using GeraAdvantage.Utils;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GeraAdvantage.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NCDetails : ContentPage
    {
        private string _sampleText;
        private NC NCDetail;

        public string SampleText
        {
            get => _sampleText;
            set
            {
                if (value == _sampleText)
                {
                    return;
                }
                _sampleText = value;
                OnPropertyChanged(nameof(SampleText));
            }
        }
        public NCDetails(string Id)
        {
            BindingContext = this;
            InitializeComponent();
            NCSQLServices ncServices = new NCSQLServices();
            NCDetail = ncServices.GetNCbyId(Id);
            PopulateData();
            SampleText = "This is Sample Text.";
        }

        private void PopulateData()
        {
            try
            {
                GlobalSQLServices sQLServices = new GlobalSQLServices();
                if (NCDetail!=null)
                {

                    NCNoEnt.Text = NCDetail.Id;
                    if (NCDetail.IsChecklistLinked)
                        ChecklistNoEnt.Text =  "Checklist No";
                    else
                        ChecklistNoEnt.Text = "N/A";
                    BuildingEnt.Text = sQLServices.GetBuilding(NCDetail.BuildingId.ToString()).Title;
                    FlatTypeEnt.Text = sQLServices.GetUnit(NCDetail.UnitId.ToString()).Title;
                    FloorEnt.Text = sQLServices.GetFloor(NCDetail.FloorId.ToString()).Title;
                    FlatNoEnt.Text = sQLServices.GetUnit(NCDetail.UnitId.ToString()).Title;
                    RoomEnt.Text = sQLServices.GetRoom(NCDetail.RoomTypeId.ToString()).Title;
                    CategoryEnt.Text = sQLServices.GetCategory(NCDetail.CategoryId.ToString()).Title;
                    SubCategoryEnt.Text = sQLServices.GetCategory(NCDetail.SubCategoryId.ToString()).Title;
                    RootCauseEnt.Text = sQLServices.GetRootCause(NCDetail.RootCauseId.ToString()).Title;
                    ProposedSeverityEnt.Text = sQLServices.GetSeverity(NCDetail.SeverityId.ToString()).Title;
                    SeverityEnt.Text = sQLServices.GetSeverity(NCDetail.SeverityId.ToString()).Title;
                    CreatedDateEnt.Text = NCDetail.CreatedOn.ToString();
                    DeadlineDateEnt.Text = NCDetail.DeadlineDate.ToShortDateString();
                    ContractorEnt.Text = sQLServices.GetUser(NCDetail.ContractorId.ToString()).UserName;
                    CreatedByEnt.Text = sQLServices.GetUser(NCDetail.CreatedBy.ToString()).UserName;
                    UpdatedByEnt.Text = sQLServices.GetUser(NCDetail.UpdatedBy.ToString()).UserName;
                    EngineerEnt.Text = sQLServices.GetUser(NCDetail.EngineerId.ToString()).UserName;
                    NCStatusEnt.Text = sQLServices.GetNCStatus(NCDetail.StatusId.ToString()).Title;


                    CorrectiveActionEnt.Text = NCDetail.CorrectiveAction;
                    PreventiveActionEnt.Text = NCDetail.PrevenctiveAction;
                    NCCommentEnt.Text = "N/A";
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async void ShowHistory_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShowNCHistory());
        }
        private async void AddPhoto_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new UploadImageDialoge());
        }

        private async void EditNCDetails_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditNCDetails());
        }
        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            List<string> StatusArray = new List<string>() { "Approved", "Open", "Not Approved", "Not possible to close", "Work done by contractor" };
            string Result = await DisplayActionSheet("Select Status",null, null, StatusArray.ToArray());
            if (Result != null)
            {
                SampleText = Result;
            }
        }
    }
}