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
using static GeraAdvantage.Utils.Entities;

namespace GeraAdvantage.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateSnaglist : ContentPage
    {

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
        private string _UnitTypePick;

        public string UnitTypePick
        {
            get => _UnitTypePick;
            set
            {
                if (value == _UnitTypePick)
                {
                    return;
                }
                _UnitTypePick = value;
                OnPropertyChanged(nameof(UnitTypePick));
            }
        }
        private string _UnitNumberPick;

        public string UnitNumberPick
        {
            get => _UnitNumberPick;
            set
            {
                if (value == _UnitNumberPick)
                {
                    return;
                }
                _UnitNumberPick = value;
                OnPropertyChanged(nameof(UnitNumberPick));
            }
        }
        public long  BuildingPickIndex, FloorPickIndex, UnitTypePickIndex,
               UnitNumberPickIndex;
        public CreateSnaglist()
        {
            InitializeComponent();
            BindingContext = this;
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

        private async void UnitType_Clicked(object sender, EventArgs e)
        {
            SQLConfig Config = new SQLConfig();
            List<UnitType> List = Config.GetItems<UnitType>().ToList();
            await PopupNavigation.Instance.PushAsync(new SearchDialoge(List.Select(x => x.Title).ToList()));
            MessagingCenter.Subscribe<string>(this, "SelectedOption",
                                (value) =>
                                {
                                    if (value.Length > 0)
                                    {
                                        var Option = List.FirstOrDefault(x => x.Title == value);
                                        UnitTypePick = Option.Title;
                                        UnitTypePickIndex = Convert.ToInt64(Option.Id);
                                    }
                                    MessagingCenter.Unsubscribe<string>(this, "SelectedOption");
                                });

        }
        private async void UnitNumber_Clicked(object sender, EventArgs e)
        {

            if ((UnitTypePick ?? "").Length > 0)
            {
                SQLConfig Config = new SQLConfig();
                var List = Config.GetItems<UnitType>().Where(x => x.ParentUnitTypeId == UnitTypePickIndex).ToList();
                await PopupNavigation.Instance.PushAsync(new SearchDialoge(List.Select(x => x.Title).ToList()));
                MessagingCenter.Subscribe<string>(this, "SelectedOption",
                                    (value) =>
                                    {
                                        if (value.Length > 0)
                                        {
                                            var Option = List.FirstOrDefault(x => x.Title == value);
                                            UnitNumberPick = Option.Title;
                                            UnitNumberPickIndex = Convert.ToInt64(Option.Id);
                                        }
                                        MessagingCenter.Unsubscribe<string>(this, "SelectedOption");
                                    });
               
            }
        }


        private async void BtnSelectRoom_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SnaglistRoomSelection("Project Name", BuildingPick,FloorPick,UnitTypePick,UnitNumberPick)) ;
        }

        
    }
}