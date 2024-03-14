using GeraAdvantage.Models;
using GeraAdvantage.SQLServices;
using GeraAdvantage.Utils;
using GeraAdvantage.ViewModels;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GeraAdvantage.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NonConformity : ContentPage, INotifyPropertyChanged
    {
        public NC model;
        public char[] spearator = { ' ' };
        private string _sampleText;
        private string AvailableImage;

        public long SamplePickIndex, BuildingPickIndex, FloorPickIndex, FlatTypePickIndex, SidePickIndex,
                    RoomPickIndex, CategoryPickIndex, SubCategoryPickIndex, ContractorPickIndex, ResposiblePickIndex, RootCausePickIndex, ProposedSeverityPickIndex, SeverityPickIndex;
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
        private string _rootCause;

        public string RootCausePick
        {
            get => _rootCause;
            set
            {
                if (value == _rootCause)
                {
                    return;
                }
                _rootCause = value;
                OnPropertyChanged(nameof(RootCausePick));
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
        private string _proposedseverityPick;

        public string ProposedSeverityPick
        {
            get => _proposedseverityPick;
            set
            {
                if (value == _proposedseverityPick)
                {
                    return;
                }
                _proposedseverityPick = value;
                OnPropertyChanged(nameof(ProposedSeverityPick));
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
        private string _SubCategoryPick;

        public string SubCategoryPick
        {
            get => _SubCategoryPick;
            set
            {
                if (value == _SubCategoryPick)
                {
                    return;
                }
                _SubCategoryPick = value;
                OnPropertyChanged(nameof(SubCategoryPick));
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
        private string _ResposiblePick;

        public string ResponsiblePick
        {
            get => _ResposiblePick;
            set
            {
                if (value == _ResposiblePick)
                {
                    return;
                }
                _ResposiblePick = value;
                OnPropertyChanged(nameof(ResponsiblePick));
            }
        }


        public NonConformity()
        {
            InitializeComponent();
            model = new NC();
            BindingContext = this;
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
                                        SamplePickIndex = Convert.ToInt64(Option.Id);
                                    }
                                        MessagingCenter.Unsubscribe<string>(this, "SelectedOption");
                                });
        }
        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new UploadImageDialoge());
            MessagingCenter.Subscribe<FileResult>(this, "ImageDialoge",
                                                    async (value) =>
                                                    {
                                                        AvailableImage = UtilServices.ConvertImagetoBase64Text(value).Result;
                                                        MessagingCenter.Unsubscribe<FileResult>(this, "ImageDialoge");
                                                        var Stream = await value.OpenReadAsync();
                                                        SelectedImage.Source = ImageSource.FromStream(() => Stream);
                                                    });
        }
        private async void Save_Clicked(object sender, EventArgs e)
        {
            model.NCCode = "NC";
            model.BuildingId = BuildingPickIndex;
            model.FloorId = FloorPickIndex;
            model.UnitTypeId = FlatTypePickIndex;
            model.UnitId = FlatTypePickIndex;
            model.RoomTypeId = RoomPickIndex;
            model.CategoryId = CategoryPickIndex;
            model.SubCategoryId = SubCategoryPickIndex;
            model.EngineerId = ResposiblePickIndex;
            model.SeverityId = SeverityPickIndex;
            model.RootCauseId = RootCausePickIndex;
            model.IsPotential = IsPotentialChkBx.IsChecked;
            model.ProjectId = 1;
            model.ContractorId = ContractorPickIndex;
            //model.Image = AvailableImage; TBD
            model.CorrectiveAction = CorrectiveActionEnt.Text;
            model.PrevenctiveAction = PreventiceActionEnt.Text;
            model.CreatedBy = ResposiblePickIndex;
            model.CreatedOn = DateTime.Now;
            model.UpdatedBy = ResposiblePickIndex;
            model.UpdatedOn = DateTime.Now;
            model.StatusId = 0;
            model.DeadlineDate = DateTime.Now.AddDays(10);

            NCSQLServices ncServices = new NCSQLServices();

            //bool res = DependencyService.Get<ISQLite>().SaveNCAndC(model);
            //bool res =true;
            if (ncServices.SaveNC(model))
            {
                await Application.Current.MainPage.DisplayAlert("Message", "Data Save Successfully", "Ok");
                ResetForm();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Message", "Data Failed To Save", "Ok");
            }
        }

        private void ResetForm()
        {
            BuildingPick = String.Empty;
            FloorPick = String.Empty;
            FlatTypePick = String.Empty;
            RoomPick = String.Empty;
            CategoryPick = String.Empty;
            ContractorPick = String.Empty;
            ResponsiblePick = String.Empty;
            AvailableImage = String.Empty;
            RootCausePick = String.Empty;
            ProposedSeverityPick = String.Empty;
            SeverityPick = String.Empty;
            AvailableImage = String.Empty;
            SelectedImage.Source = null;
            CorrectiveActionEnt.Text = String.Empty;
            PreventiceActionEnt.Text = String.Empty;
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
        //private async void Side_Clicked(object sender, EventArgs e)
        //{
        //    string parameter = "Side";
        //    await PopupNavigation.Instance.PushAsync(new SearchDialoge(parameter));
        //    MessagingCenter.Subscribe<string>(this, "Side",
        //                                     (value) =>
        //                                     {
        //                                         SidePick = value;
        //                                         SidePickIndex = Convert.ToInt64(SidePick.Split(spearator)[1]);
        //                                         MessagingCenter.Unsubscribe<string>(this, "Side");
        //                                     });

        //}
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
        private async void SubCategory_Clicked(object sender, EventArgs e)
        {

            if ((CategoryPick??"").Length>0)
            {
                SQLConfig Config = new SQLConfig();
                var List = Config.GetItems<Category>().Where(x => x.ParentCategoryId == CategoryPickIndex).ToList();
                await PopupNavigation.Instance.PushAsync(new SearchDialoge(List.Select(x => x.Title).ToList()));
                MessagingCenter.Subscribe<string>(this, "SelectedOption",
                                    (value) =>
                                    {
                                        if (value.Length > 0)
                                        {
                                            var Option = List.FirstOrDefault(x => x.Title == value);
                                            SubCategoryPick = Option.Title;
                                            SubCategoryPickIndex = Convert.ToInt64(Option.Id);
                                        }
                                            MessagingCenter.Unsubscribe<string>(this, "SelectedOption");
                                    });
            }
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
        private async void Resposible_Clicked(object sender, EventArgs e)
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
                                        ResponsiblePick = Option.UserName;
                                        ResposiblePickIndex = Convert.ToInt64(Option.Id);
                                    }
                                        MessagingCenter.Unsubscribe<string>(this, "SelectedOption");
                                });

        }
        private async void RootCause_Clicked(object sender, EventArgs e)
        {
            SQLConfig Config = new SQLConfig();
            var List = Config.GetItems<RootCause>().ToList();
            await PopupNavigation.Instance.PushAsync(new SearchDialoge(List.Select(x => x.Title).ToList()));
            MessagingCenter.Subscribe<string>(this, "SelectedOption",
                                (value) =>
                                {
                                    if (value.Length > 0)
                                    {
                                        var Option = List.FirstOrDefault(x => x.Title == value);
                                        RootCausePick = Option.Title;
                                        RootCausePickIndex = Convert.ToInt64(Option.Id);
                                    }
                                        MessagingCenter.Unsubscribe<string>(this, "SelectedOption");
                                });

        }
        private async void ProposedSeverity_Clicked(object sender, EventArgs e)
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
                                        ProposedSeverityPick = Option.Title;
                                        ProposedSeverityPickIndex = Convert.ToInt64(Option.Id);
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
    }
}