using GeraAdvantage.SQLServices;
using GeraAdvantage.Utils;
using GeraAdvantage.WebServices;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static GeraAdvantage.Utils.Entities;

namespace GeraAdvantage.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewSnaglist : ContentPage, INotifyPropertyChanged, INotifyCollectionChanged
    {
        private List<MultileOps> List;

        private List<MultileOps> _opsList
        {
            get => List;
            set
            {
                if (value == List)
                {
                    return;
                }
                List = value;
                OnPropertyChanged(nameof(_opsList));
            }
        }
        MultileOps SeletedItem;
        RoomType SelectedRoom;

        public event NotifyCollectionChangedEventHandler CollectionChanged;
        private string _room = string.Empty;
        public string Room
        {
            get => _room;
            set
            {
                if (value == _room)
                {
                    return;
                }
                _room = value;
                OnPropertyChanged(nameof(Room));
            }
        }
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
        private string _CategoryPick;
        public string CategoryPick
        {
            get => _CategoryPick;
            set
            {
                if (value == _CategoryPick)
                {
                    return;
                }
                _CategoryPick = value;
                OnPropertyChanged(nameof(CategoryPick));
            }
        }

        private string _severityPick;
        public string SeverityPick
        {
            get => _severityPick;
            set
            {
                if (value == _severityPick)
                {
                    return;
                }
                _severityPick = value;
                OnPropertyChanged(nameof(SeverityPick));
            }
        }
        private long CategoryPickIndex, SeverityPickIndex;

        public ViewSnaglist(string RoomId, string projectName, string buildingPick, string floorPick, string unitTypePick, string unitNumberPick)
        {
            BindingContext = this;
            InitializeComponent();
            GlobalSQLServices sQLServices = new GlobalSQLServices();
            SelectedRoom = sQLServices.GetRoom(RoomId);
            Room = SelectedRoom.Title;
            ProjectName = projectName;
            Building = buildingPick;
            Floor = floorPick;
            UnitType = unitTypePick;
            UnitNo = unitNumberPick;

            //InitializeData();
            InitializeDummyData();
            listView.ItemsSource = _opsList;
            LCount.Text = _opsList.Count.ToString();
        }

        //private async void InitializeData()
        //{
        //    try
        //    {

        //        ChecklistSQLServices sQLServices = new ChecklistSQLServices();
        //        var Stages = sQLServices.GetCheckListStages(ChecklistTypeId);
        //        foreach (var item in Stages)
        //        {
        //            switch (Stages.IndexOf(item))
        //            {
        //                case 0:
        //                    lblFirstBanner.Text = item.Title;
        //                    break;
        //                case 1:
        //                    lblSecondBanner.Text = item.Title;
        //                    break;
        //                case 2:
        //                    lblThirdBanner.Text = item.Title;
        //                    break;
        //                default:
        //                    break;
        //            }
        //        }

        //        GlobalWebServices globalWeb = new GlobalWebServices();
        //        var checkpoints = await globalWeb.GetCheckListStatusUserRolesAsync(ChecklistTypeId, CategoryId).ConfigureAwait(false);

        //    }
        //    catch (Exception ex)
        //    {
        //        DisplayAlert("Error", ex.Message, "OK");
        //    }
        //}

        private void InitializeDummyData()
        {
            _opsList = new List<MultileOps>();
            _opsList.Add(new MultileOps() { Title = "1- This is sample", isfour = false, isthree = true, ConverttoNC = false, SEComment = false, AddImage = false, btnYes = false, btnNo = false, btnNA = false, btnA = false, btnAWC = false, btnR = false, Severity = String.Empty });
            _opsList.Add(new MultileOps() { Title = "2- This is sample", isfour = true, isthree = false, ConverttoNC = false, SEComment = false, AddImage = true, btnYes = false, btnNo = false, btnNA = false, btnA = false, btnAWC = false, btnR = false, Severity = String.Empty });
            _opsList.Add(new MultileOps() { Title = "3- This is sample", isfour = false, isthree = true, ConverttoNC = false, SEComment = false, AddImage = false, btnYes = false, btnNo = false, btnNA = false, btnA = false, btnAWC = false, btnR = false, Severity = String.Empty });
            _opsList.Add(new MultileOps() { Title = "4- This is sample", isfour = true, isthree = false, ConverttoNC = false, SEComment = false, AddImage = true, btnYes = false, btnNo = false, btnNA = false, btnA = false, btnAWC = false, btnR = false, Severity = String.Empty });
            _opsList.Add(new MultileOps() { Title = "5- This is sample", isfour = false, isthree = true, ConverttoNC = false, SEComment = false, AddImage = true, btnYes = false, btnNo = false, btnNA = false, btnA = false, btnAWC = false, btnR = false, Severity = String.Empty });
            _opsList.Add(new MultileOps() { Title = "6- This is sample", isfour = true, isthree = false, ConverttoNC = false, SEComment = false, AddImage = false, btnYes = false, btnNo = false, btnNA = false, btnA = false, btnAWC = false, btnR = false, Severity = String.Empty });
            _opsList.Add(new MultileOps() { Title = "7- This is sample", isfour = false, isthree = true, ConverttoNC = false, SEComment = false, AddImage = false, btnYes = false, btnNo = false, btnNA = false, btnA = false, btnAWC = false, btnR = false, Severity = String.Empty });
        }
        private async void BtnOK_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ReviewQuestion());
        }
        private void PictureButton_Clicked(object sender, EventArgs e)
        {

            var frame = new StackLayout
            {
                Style = (Style)Application.Current.Resources["ProjectframeLayout"]
            };
            var image = new Image
            {
                Source = "noimage.png",
                Style = (Style)Application.Current.Resources["ProjectImage"]

            };

        }
        private void Button_Clicked(object sender, EventArgs e)
        {

            var button = (Button)sender;
            var item = (MultileOps)button.BindingContext;
            var index = _opsList.IndexOf(item);

            switch (button.Text)
            {
                case "Yes":
                    _opsList[index].ConverttoNC = false;
                    _opsList[index].SEComment = false;
                    _opsList[index].AddImage = false;

                    _opsList[index].btnAWC = false;
                    _opsList[index].btnA = false;
                    _opsList[index].btnNA = false;
                    _opsList[index].btnNo = false;
                    _opsList[index].btnR = false;
                    _opsList[index].btnYes = true;
                    break;
                case "No":
                    _opsList[index].ConverttoNC = false;
                    _opsList[index].SEComment = false;
                    _opsList[index].AddImage = false;

                    _opsList[index].btnAWC = false;
                    _opsList[index].btnA = false;
                    _opsList[index].btnNA = false;
                    _opsList[index].btnNo = true;
                    _opsList[index].btnR = false;
                    _opsList[index].btnYes = false;
                    break;
                case "NA":
                    _opsList[index].ConverttoNC = false;
                    _opsList[index].SEComment = false;
                    _opsList[index].AddImage = false;

                    _opsList[index].btnAWC = false;
                    _opsList[index].btnA = false;
                    _opsList[index].btnNA = true;
                    _opsList[index].btnNo = false;
                    _opsList[index].btnR = false;
                    _opsList[index].btnYes = false;
                    break;
                case "A":
                    _opsList[index].ConverttoNC = false;
                    _opsList[index].SEComment = false;
                    _opsList[index].AddImage = false;

                    _opsList[index].btnAWC = false;
                    _opsList[index].btnA = true;
                    _opsList[index].btnNA = false;
                    _opsList[index].btnNo = false;
                    _opsList[index].btnR = false;
                    _opsList[index].btnYes = false;
                    break;
                case "AWC":
                    _opsList[index].ConverttoNC = false;
                    _opsList[index].SEComment = true;
                    _opsList[index].AddImage = false;


                    _opsList[index].btnAWC = true;
                    _opsList[index].btnA = false;
                    _opsList[index].btnNA = false;
                    _opsList[index].btnNo = false;
                    _opsList[index].btnR = false;
                    _opsList[index].btnYes = false;

                    break;
                case "R":
                    _opsList[index].ConverttoNC = true;
                    _opsList[index].SEComment = false;
                    _opsList[index].AddImage = false;

                    _opsList[index].btnAWC = false;
                    _opsList[index].btnA = false;
                    _opsList[index].btnNA = false;
                    _opsList[index].btnNo = false;
                    _opsList[index].btnR = true;
                    _opsList[index].btnYes = false;
                    break;
                default:
                    _opsList[index].ConverttoNC = false;
                    _opsList[index].SEComment = false;
                    _opsList[index].AddImage = false;


                    break;




            }
            listView.ItemsSource = null;
            listView.ItemsSource = _opsList;
        }
        private async void Category_Clicked(object sender, EventArgs e)
        {

            SQLConfig Config = new SQLConfig();
            var List = Config.GetItems<Category>().ToList();
            await PopupNavigation.Instance.PushAsync(new SearchDialoge(List.Select(x => x.Title).ToList()));
            MessagingCenter.Subscribe<string>(this, "SelectedOption",
                                (value) =>
                                {
                                    if (value.Length > 0)
                                    {
                                        var Option = List.FirstOrDefault(x => x.Title == value);
                                        CategoryPick = Option.Title;
                                        CategoryPickIndex = Convert.ToInt64(Option.Id);
                                    }
                                    MessagingCenter.Unsubscribe<string>(this, "SelectedOption");
                                });
        }
        private async void Severity_Clicked(object sender, EventArgs e)
        {
            SQLConfig Config = new SQLConfig();
            var List = Config.GetItems<Severity>().ToList();
            await PopupNavigation.Instance.PushAsync(new SearchDialoge(List.Select(x => x.Title).ToList()));
            MessagingCenter.Subscribe<string>(this, "SelectedOption",
                                (value) =>
                                {
                                    if (value.Length > 0)
                                    {
                                        var Option = List.FirstOrDefault(x => x.Title == value);
                                        SeverityPick = Option.Title;
                                        SeverityPickIndex = Convert.ToInt64(Option.Id);
                                    }
                                    MessagingCenter.Unsubscribe<string>(this, "SelectedOption");
                                });

        }
        private async void ListSeverity_Clicked(object sender, EventArgs e)
        {
            SQLConfig Config = new SQLConfig();
            var List = Config.GetItems<Severity>().ToList();
            await PopupNavigation.Instance.PushAsync(new SearchDialoge(List.Select(x => x.Title).ToList()));
            var button = (Button)sender;
            var item = (MultileOps)button.BindingContext;
            var index = _opsList.IndexOf(item);

            MessagingCenter.Subscribe<string>(this, "SelectedOption",
                                (value) =>
                                {
                                    if (value.Length > 0)
                                    {
                                        var Option = List.FirstOrDefault(x => x.Title == value);
                                        _opsList[index].Severity = value;
                                        listView.ItemsSource = null;
                                        listView.ItemsSource = _opsList;
                                    }
                                    MessagingCenter.Unsubscribe<string>(this, "SelectedOption");
                                });

        }

        private void listView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            SeletedItem = (MultileOps)e.Item;
        }
    }

}