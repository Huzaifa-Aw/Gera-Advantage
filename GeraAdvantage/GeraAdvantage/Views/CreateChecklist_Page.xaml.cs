using GeraAdvantage.SQLServices;
using GeraAdvantage.Utils;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GeraAdvantage.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateChecklist_Page : ContentPage, INotifyPropertyChanged
    {

        private string _sampleText;
        private int ChecklistTypeId;

        public string SamplePick
        {
            get => _sampleText;
            set
            {
                if (value == _sampleText)
                {
                    return;
                }
                _sampleText = value;
                OnPropertyChanged(nameof(SamplePick));
            }
        }
        private string _BuildingPick;

        public string BuildingPick
        {
            get => _BuildingPick;
            set
            {
                if (value == _BuildingPick)
                {
                    return;
                }
                _BuildingPick = value;
                OnPropertyChanged(nameof(BuildingPick));
            }
        }
        private string _FloorPick;

        public string FloorPick
        {
            get => _FloorPick;
            set
            {
                if (value == _FloorPick)
                {
                    return;
                }
                _FloorPick = value;
                OnPropertyChanged(nameof(FloorPick));
            }
        }
        private string _FlatTypePick;

        public string FlatTypePick
        {
            get => _FlatTypePick;
            set
            {
                if (value == _FlatTypePick)
                {
                    return;
                }
                _FlatTypePick = value;
                OnPropertyChanged(nameof(FlatTypePick));
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
        private string _MemberPick;

        public string MemberPick
        {
            get => _MemberPick;
            set
            {
                if (value == _MemberPick)
                {
                    return;
                }
                _MemberPick = value;
                OnPropertyChanged(nameof(MemberPick));
            }
        }
        private string _RoomPick;

        public string RoomPick
        {
            get => _RoomPick;
            set
            {
                if (value == _RoomPick)
                {
                    return;
                }
                _RoomPick = value;
                OnPropertyChanged(nameof(RoomPick));
            }
        }
        private string _ContractorPick;

        public string ContractorPick
        {
            get => _ContractorPick;
            set
            {
                if (value == _ContractorPick)
                {
                    return;
                }
                _ContractorPick = value;
                OnPropertyChanged(nameof(ContractorPick));
            }
        }
        public long SamplePickIndex, BuildingPickIndex, FloorPickIndex, FlatTypePickIndex,
                    RoomPickIndex, CategoryPickIndex, ContractorPickIndex, MemberPickIndex;

        public CreateChecklist_Page(int checklistTypeId)
        {
            InitializeComponent();
            ChecklistTypeId = checklistTypeId;
            BindingContext = this;

        }
        private async void BtnView_Clicked(object sender, EventArgs e)
        {
            if (CategoryPickIndex > 0)
            {
                await Navigation.PushAsync(new ViewCheckList(ChecklistTypeId, (int)CategoryPickIndex));
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            SQLConfig Config = new SQLConfig();
            var List = Config.GetItems<Building>().ToList();
            await PopupNavigation.Instance.PushAsync(new SearchDialoge(List.Select(x => x.Title).ToList()));
            MessagingCenter.Subscribe<string>(this, "SelectedOption",
                                (value) =>
                                {
                                    if (value.Length > 0)
                                    {
                                        var Option = List.FirstOrDefault(x => x.Title == value);
                                        SamplePick = Option.Title;
                                    }
                                        MessagingCenter.Unsubscribe<string>(this, "SelectedOption");
                                });
        }
        private async void Building_Clicked(object sender, EventArgs e)
        {
            SQLConfig Config = new SQLConfig();
            var List = Config.GetItems<Building>().ToList();
            await PopupNavigation.Instance.PushAsync(new SearchDialoge(List.Select(x => x.Title).ToList()));
            MessagingCenter.Subscribe<string>(this, "SelectedOption",
                                (value) =>
                                {
                                    if (value.Length > 0)
                                    {
                                        var Option = List.FirstOrDefault(x => x.Title == value);
                                        BuildingPick = Option.Title;
                                        BuildingPickIndex = Convert.ToInt64(Option.Id);
                                    }
                                        MessagingCenter.Unsubscribe<string>(this, "SelectedOption");
                                });

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

        private async void Floor_Clicked(object sender, EventArgs e)
        {
            SQLConfig Config = new SQLConfig();
            var List = Config.GetItems<Floor>().ToList();
            await PopupNavigation.Instance.PushAsync(new SearchDialoge(List.Select(x => x.Title).ToList()));
            MessagingCenter.Subscribe<string>(this, "SelectedOption",
                                (value) =>
                                {
                                    if (value.Length > 0)
                                    {
                                        var Option = List.FirstOrDefault(x => x.Title == value);
                                        FloorPick = Option.Title;
                                        FloorPickIndex = Convert.ToInt64(Option.Id);
                                    }
                                        MessagingCenter.Unsubscribe<string>(this, "SelectedOption");
                                });

        }

        private async void Flat_Clicked(object sender, EventArgs e)
        {
            SQLConfig Config = new SQLConfig();
            var List = Config.GetItems<UnitType>().ToList();
            await PopupNavigation.Instance.PushAsync(new SearchDialoge(List.Select(x => x.Title).ToList()));
            MessagingCenter.Subscribe<string>(this, "SelectedOption",
                                (value) =>
                                {
                                    if (value.Length > 0)
                                    {
                                        var Option = List.FirstOrDefault(x => x.Title == value);
                                        FlatTypePick = Option.Title;
                                        FlatTypePickIndex = Convert.ToInt64(Option.Id);
                                    }
                                        MessagingCenter.Unsubscribe<string>(this, "SelectedOption");
                                });

        }

        private async void Room_Clicked(object sender, EventArgs e)
        {
            SQLConfig Config = new SQLConfig();
            var List = Config.GetItems<RoomType>().ToList();
            await PopupNavigation.Instance.PushAsync(new SearchDialoge(List.Select(x => x.Title).ToList()));
            MessagingCenter.Subscribe<string>(this, "SelectedOption",
                                (value) =>
                                {
                                    if (value.Length > 0)
                                    {
                                        var Option = List.FirstOrDefault(x => x.Title == value);
                                        RoomPick = Option.Title;
                                        RoomPickIndex = Convert.ToInt64(Option.Id);
                                    }
                                        MessagingCenter.Unsubscribe<string>(this, "SelectedOption");
                                });
        }
        private async void Member_Clicked(object sender, EventArgs e)
        {
            SQLConfig Config = new SQLConfig();
            var List = Config.GetItems<User>().ToList();
            await PopupNavigation.Instance.PushAsync(new SearchDialoge(List.Select(x => x.UserName).ToList()));
            MessagingCenter.Subscribe<string>(this, "SelectedOption",
                                (value) =>
                                {
                                    if (value.Length > 0)
                                    {
                                        var Option = List.FirstOrDefault(x => x.UserName == value);
                                        MemberPick = Option.UserName;
                                        MemberPickIndex = Convert.ToInt64(Option.Id);
                                    }
                                        MessagingCenter.Unsubscribe<string>(this, "SelectedOption");
                                });

        }
        private async void Contractor_Clicked(object sender, EventArgs e)
        {
            SQLConfig Config = new SQLConfig();
            var List = Config.GetItems<User>().ToList();
            await PopupNavigation.Instance.PushAsync(new SearchDialoge(List.Select(x => x.UserName).ToList()));
            MessagingCenter.Subscribe<string>(this, "SelectedOption",
                                (value) =>
                                {
                                    if (value.Length > 0)
                                    {
                                        var Option = List.FirstOrDefault(x => x.UserName == value);
                                        ContractorPick = Option.UserName;
                                        ContractorPickIndex = Convert.ToInt64(Option.Id);
                                    }
                                        MessagingCenter.Unsubscribe<string>(this, "SelectedOption");
                                });

        }
    }
}