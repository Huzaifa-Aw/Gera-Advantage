using GeraAdvantage.SQLServices;
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
    public partial class SnaglistRoomSelection : ContentPage
    {
        private string _projectName = string.Empty;
        public string ProjectName
        {
            get => _projectName;
            set
            {
                if (value == _projectName)
                {
                    return;
                }
                _projectName = value;
                OnPropertyChanged(nameof(ProjectName));
            }
        }
        private string _building = string.Empty;
        public string Building
        {
            get => _building;
            set
            {
                if (value == _building)
                {
                    return;
                }
                _building = value;
                OnPropertyChanged(nameof(Building));
            }
        }
        private string _floor = string.Empty;
        public string Floor
        {
            get => _floor;
            set
            {
                if (value == _floor)
                {
                    return;
                }
                _floor = value;
                OnPropertyChanged(nameof(Floor));
            }
        }
        private string _unittype = string.Empty;
        public string UnitType
        {
            get => _unittype;
            set
            {
                if (value == _unittype)
                {
                    return;
                }
                _unittype = value;
                OnPropertyChanged(nameof(UnitType));
            }
        }
        private string _unitNumber = string.Empty;
        public string UnitNo
        {
            get => _unitNumber;
            set
            {
                if (value == _unitNumber)
                {
                    return;
                }
                _unitNumber = value;
                OnPropertyChanged(nameof(UnitNo));
            }
        }

        internal List<FilterDetail> SampleList { get; private set; }

        public SnaglistRoomSelection(string projectName, string buildingPick, string floorPick, string unitTypePick, string unitNumberPick)
        {
            BindingContext = this;
            InitializeComponent();
            ProjectName = projectName;
            Building = buildingPick;
            Floor = floorPick;
            UnitType = unitTypePick;
            UnitNo = unitNumberPick;
            DataInitialization();
            listView.ItemsSource = SampleList;

        }

        private void DataInitialization()
        {
            SQLConfig Config = new SQLConfig();
            var List = Config.GetItems<RoomType>().ToList();
            SampleList = new List<FilterDetail>();
            foreach (var item in List)
            {
                SampleList.Add(new FilterDetail() {Id=item.Id, Title = item.Title });
            }
        }
        private async void listView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var SelectedItem = (FilterDetail)e.Item;
            //MessagingCenter.Send<string>(SelectedItem.Title, "
            //");
            //await .PopAsync();
        }

        private async void OpenButton_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var item = (FilterDetail)button.BindingContext;
            await Navigation.PushAsync(new ViewSnaglist(item.Id, ProjectName, Building, Floor, UnitType, UnitNo));
            MessagingCenter.Subscribe<string>(this, "SelectedOption",
                                (value) =>
                                {
                                    //if (value.Length > 0)
                                    //{
                                    //    var Option = List.FirstOrDefault(x => x.Title == value);
                                    //    FloorPick = Option.Title;
                                    //    FloorPickIndex = Convert.ToInt64(Option.Id);
                                    //}
                                    MessagingCenter.Unsubscribe<string>(this, "SelectedOption");
                                });
        }

        //private void Search_Clicked(object sender, EventArgs e)
        //{
        //    if (EntSearch.Text.Length > 0)
        //    {
        //        var SearchedList = SampleList.FindAll(x => x.Title.ToLower().Contains(EntSearch.Text.ToLower()));
        //        if (SearchedList.Count > 0)
        //        {
        //            listView.ItemsSource = null;
        //            listView.ItemsSource = SearchedList;
        //        }
        //        else
        //        {
        //            listView.ItemsSource = null;
        //            listView.ItemsSource = SampleList;
        //        }
        //    }
        //    else
        //    {
        //        listView.ItemsSource = null;
        //        listView.ItemsSource = SampleList;
        //    }
        //}
    }

}
