using Rg.Plugins.Popup.Services;
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
    public partial class SearchMultipleDialoge
    {
        private List<FilterDetail> SampleList= new List<FilterDetail>();
        private List<FilterDetail>  SearchedList= new List<FilterDetail>();
        public SearchMultipleDialoge()
        {
            BindingContext = this;
            InitializeComponent();
            DummyDataInitialization();
            listView.ItemsSource = SampleList;
        }

        private void DummyDataInitialization()
        {
            SampleList = new List<FilterDetail>();
            for (int i = 1; i <= 15; i++)
            {
                SampleList.Add(new FilterDetail() { Title = "Option " + i ,IsChecked=false});
            }

        }

        private async void listView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            bool UpdatedCheck = false;
            var SelectedItem = (FilterDetail)e.Item;
            if (SelectedItem.IsChecked)
                UpdatedCheck = false;
            else
                UpdatedCheck = true;
            SampleList.FirstOrDefault(x => x.Title == SelectedItem.Title).IsChecked = UpdatedCheck;
            listView.ItemsSource = null;
            if (SearchedList.Count > 0)
            {
                SearchedList.FirstOrDefault(x => x.Title == SelectedItem.Title).IsChecked = UpdatedCheck;
                listView.ItemsSource = SearchedList;
            }
            else
                listView.ItemsSource = SampleList;

        }
        
        private void Search_Clicked(object sender, EventArgs e)
        {
            if (EntSearch.Text.Length > 0)
            {
                SearchedList = SampleList.FindAll(x => x.Title.ToLower().Contains(EntSearch.Text.ToLower()));
                if (SearchedList.Count > 0)
                {
                    listView.ItemsSource = null;
                    listView.ItemsSource = SearchedList;
                }
                else
                {
                    listView.ItemsSource = null;
                    listView.ItemsSource = SampleList;
                }
            }
            else
            {
                listView.ItemsSource = null;
                listView.ItemsSource = SampleList;
            }
        }

        private async void BtnSave_Clicked(object sender, EventArgs e)
        {
            List<FilterDetail> FilterList = new List<FilterDetail>();
            foreach (var item in SampleList)
            {
                if (item.IsChecked)
                {
                    FilterList.Add(item);
                }
            }
            MessagingCenter.Send(FilterList, "SelectedOption");
            await PopupNavigation.Instance.PopAsync();
        }
        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }
    }

}