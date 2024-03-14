using GeraAdvantage.SQLServices;
using GeraAdvantage.Utils;
using System;
using System.Collections;
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
    public partial class NCList : ContentPage
    {
        private  List<NC> _NCsList;
        private  List<NC> CsList;
        private  List<NCDisplayModel> _NCsDisplayList= new List<NCDisplayModel>();

        public NCList()
        {
            BindingContext = this;
            InitializeComponent();
            GetNCsFromSQL();
            listView.ItemsSource = _NCsDisplayList;
        }

        private void GetNCsFromSQL()
        {
            NCSQLServices ncServices = new NCSQLServices();
            GlobalSQLServices sQLServices = new GlobalSQLServices();
            _NCsList = ncServices.GetNCs();
            
            foreach (var item in _NCsList)
            {
                var DisplayNC = new NCDisplayModel();
                DisplayNC.Id=item.Id;

                DisplayNC.Title = sQLServices.GetProject(item.ProjectId.ToString()).Name;
                DisplayNC.Building = sQLServices.GetBuilding(item.BuildingId.ToString()).Title;
                DisplayNC.Floor = sQLServices.GetFloor(item.FloorId.ToString()).Title;
                DisplayNC.Category = sQLServices.GetCategory(item.CategoryId.ToString()).Title;
                DisplayNC.CreatedBy = sQLServices.GetUser(item.CreatedBy.ToString()).UserName+" "+item.CreatedOn.ToShortDateString();
                DisplayNC.UpdatedBy = sQLServices.GetUser(item.UpdatedBy.ToString()).UserName+ " " + item.UpdatedOn.ToShortDateString();
                DisplayNC.Cstatus = sQLServices.GetNCStatus(item.StatusId.ToString()).Title;
                DisplayNC.ProjDate = item.DeadlineDate.ToString();
                DisplayNC.Deadline = item.DeadlineDate.ToShortDateString();
                DisplayNC.IsPast=Convert.ToDateTime(item.DeadlineDate) < DateTime.Today;
                _NCsDisplayList.Add(DisplayNC);
            }
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var SelectedItem = (NCDisplayModel)e.Item;
            await Navigation.PushAsync(new NCDetails(SelectedItem.Id));
        }

    }
}