using GeraAdvantage.SQLServices;
using GeraAdvantage.Utils;
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
    public partial class NCManagement : ContentPage
    {
        public NCManagement()
        {
            InitializeComponent();
           //    SQLConfig sql_SC = new SQLConfig();
           // var NCs = sql_SC.GetItems<NC>();
           //string AlertMsg=string.Empty;
           // foreach (var item in NCs)
           // {
           //     AlertMsg +="Id:"+ item.Id + "\n";
           //     AlertMsg += "NCCode:" + item.NCCode + "\n";
           //     AlertMsg += "ProjectId:" + item.ProjectId + "\n";
           //     AlertMsg += "IsPotential:" + item.IsPotential + "\n";
           //     AlertMsg += "BuildingId:" + item.BuildingId + "\n";
           //     AlertMsg += "FloorId:" + item.FloorId + "\n";
           //     AlertMsg += "UnitTypeId:" + item.UnitTypeId + "\n";
           //     AlertMsg += "UnitId:" + item.UnitId + "\n";
           //     AlertMsg += "RoomTypeId:" + item.RoomTypeId + "\n";
           //     AlertMsg += "CategoryId:" + item.CategoryId + "\n";
           //     AlertMsg += "SubCategoryId:" + item.SubCategoryId + "\n";
           //     AlertMsg += "RootCauseId:" + item.RootCauseId + "\n";
           //     AlertMsg += "SeverityId:" + item.SeverityId + "\n";
           //     AlertMsg += "ContractorId:" + item.ContractorId + "\n";
           //     AlertMsg += "EngineerId:" + item.EngineerId + "\n";
           //     AlertMsg += "DeadlineDate:" + item.DeadlineDate + "\n";
           //     AlertMsg += "CreatedBy:" + item.CreatedBy + "\n";
           //     AlertMsg += "CreatedOn:" + item.CreatedOn + "\n";
           //     AlertMsg += "UpdatedBy:" + item.UpdatedBy + "\n";
           //     AlertMsg += "UpdatedOn:" + item.UpdatedOn + "\n";
           //     AlertMsg += "StatusId:" + item.StatusId + "\n";
           //     AlertMsg += "IsChecklistLinked:" + item.IsChecklistLinked + "\n";
           //     AlertMsg += "CorrectiveAction:" + item.CorrectiveAction + "\n";
           //     AlertMsg += "PrevenctiveAction:" + item.PrevenctiveAction + "\n\n\n\n\n\n\n";
           //    // AlertMsg += "Id:" + item.Image + "\n\n\n";
           // }
           // DisplayAlert("Current NC/C Details", AlertMsg, "OK");
        }

        private async void NonConformity_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NonConformityFiltersTemplate());
        }
        private async void ConformityDetails_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ConformityDetails());
        }
    }
}