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
    public partial class Filters : ContentPage
    {

        private List<FilterType> FilterTypes= new List<FilterType>();
        private List<FilterDetail> CategoryFilterDetails = new List<FilterDetail>();
        private List<FilterDetail> ContractorFilterDetails = new List<FilterDetail>();
        
        public Filters()
        {
            BindingContext = this;
            InitializeComponent();
            DummyDataInitialization();
            FilterTypeListView.ItemsSource = FilterTypes;
            CheckBoxListView.ItemsSource = CategoryFilterDetails;
        }

        private void DummyDataInitialization()
        {
            CategoryFilterDetails.Add(new FilterDetail() { Title = "Category Checkbox 1" });
            CategoryFilterDetails.Add(new FilterDetail() { Title = "Category Checkbox 2" });
            CategoryFilterDetails.Add(new FilterDetail() { Title = "Category Checkbox 3" });
            CategoryFilterDetails.Add(new FilterDetail() { Title = "Category Checkbox 4" });
            CategoryFilterDetails.Add(new FilterDetail() { Title = "Category Checkbox 5" });

            ContractorFilterDetails.Add(new FilterDetail() { Title = "Contractor Checkbox 1" });
            ContractorFilterDetails.Add(new FilterDetail() { Title = "Contractor Checkbox 2" });
            ContractorFilterDetails.Add(new FilterDetail() { Title = "Contractor Checkbox 3" });
            ContractorFilterDetails.Add(new FilterDetail() { Title = "Contractor Checkbox 4" });
            ContractorFilterDetails.Add(new FilterDetail() { Title = "Contractor Checkbox 5" });

            FilterTypes.Add(new FilterType() { Type = "CATEGORY" });
            FilterTypes.Add(new FilterType() { Type = "CONTRACTOR" });
            //FilterTypes.Add(new FilterType() { Type = "STAGE" });
            //FilterTypes.Add(new FilterType() { Type = "STATUS" });
        }

        private void FilterTypeListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var SelectedItem = (FilterType)e.Item;
            if (SelectedItem.Type == "CONTRACTOR")
                CheckBoxListView.ItemsSource = ContractorFilterDetails;
            else if (SelectedItem.Type == "CATEGORY")
                CheckBoxListView.ItemsSource = CategoryFilterDetails;

        }
    }
}