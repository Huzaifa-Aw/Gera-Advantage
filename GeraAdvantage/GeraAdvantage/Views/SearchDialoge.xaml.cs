using Rg.Plugins.Popup.Pages;
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
    public partial class SearchDialoge
    {
        private List<FilterDetail> SampleList;
        public SearchDialoge(List<string> _OptionsList)
        {
            BindingContext = this;
            InitializeComponent();
            DataInitialization(_OptionsList);

            listView.ItemsSource = SampleList;
        }
        protected override bool OnBackgroundClicked()
        {

            MessagingCenter.Send<string>("", "SelectedOption");
            PopupNavigation.Instance.PopAsync();
            return base.OnBackgroundClicked();

        }
      
        private void DataInitialization(List<string> _Options)
        {
            SampleList = new List<FilterDetail>();
            foreach (var item in _Options)
            {
                SampleList.Add(new FilterDetail() { Title = item });
            }
        }

        private async void listView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var SelectedItem = (FilterDetail)e.Item;
            MessagingCenter.Send<string>(SelectedItem.Title, "SelectedOption");
            await PopupNavigation.Instance.PopAsync();
        }

        private void Search_Clicked(object sender, EventArgs e)
        {
            if (EntSearch.Text.Length > 0)
            {
                var SearchedList = SampleList.FindAll(x => x.Title.ToLower().Contains(EntSearch.Text.ToLower()));
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
    }
}