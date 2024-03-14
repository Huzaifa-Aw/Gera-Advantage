using GeraAdvantage.SQLServices;
using GeraAdvantage.Utils;
using GeraAdvantage.Views;
using GeraAdvantage.WebServices;
using ModernHttpClient;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static GeraAdvantage.Utils.Entities;
using Project = GeraAdvantage.Utils.Project;

namespace GeraAdvantage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login_Page : ContentPage
    {
        private string _password=string.Empty;
        private string _username = string.Empty;

        public string Password
        {
            get => _password;
            set
            {
                if (value == _password)
                {
                    return;
                }
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string Username
        {
            get => _username;
            set
            {
                if (value == _username)
                {
                    return;
                }
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        public Login_Page()
        {
            string LicKey = "NjUwOTUxQDMyMzAyZTMxMmUzMGhyWkZGSW9hWVdTTkZid2FucFBDV3dKWVh0NnpOa1pLVFB5QmpDcW5jTjg9";
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(LicKey);
            BindingContext = this;
            InitializeComponent();
            InitializeComponentAPIData();
            //CheckPreferences();
            //InitializeTempSQLData();
          //  Username = "qa";
           // Password = "gera@123";
        }

        private async void CheckPreferences()
        {
            try
            {
                string username = Preferences.Get("UserName", string.Empty);
                string password = Preferences.Get("Password", string.Empty);
                if (username == string.Empty || password == string.Empty)
                {
                    return ;
                }
                else
                {
                    GlobalWebServices webServices = new GlobalWebServices();
                    var LoggedIn = await webServices.Login(username, password, "123");
                    if (LoggedIn.UserRoleId != null)
                    {
                        await Task.Run(async () =>
                        {
                            await Device.InvokeOnMainThreadAsync(() =>
                            {
                                Navigation.PushAsync(new GeraProjects_Page(LoggedIn.Id));
                            });
                        });
                    }
                }
            }
            catch (Exception ex)
            {

             await  DisplayAlert("ERROR", ex.Message, "OK");

            }
        }

        private async void InitializeComponentAPIData()
        {
            try
            {

                MainLayout.IsVisible = false;
                WaitingDialog.IsVisible = true;

                GlobalWebServices webServices = new GlobalWebServices();
                SQLConfig sqlConfig = new SQLConfig();

                var RCs = await webServices.SyncGlobalData().ConfigureAwait(false);

                CheckPreferences();
                await Task.Run(async () =>
                {
                    await Device.InvokeOnMainThreadAsync(() =>
                    {
                        MainLayout.IsVisible = true;
                        WaitingDialog.IsVisible = false;
                    });
                });

            }
            catch (Exception ex)
            {
                await Task.Run(async () =>
                {
                    await Device.InvokeOnMainThreadAsync(() =>
                    {
                        MainLayout.IsVisible = true;
                        WaitingDialog.IsVisible = false;
                    });
                });
                //DisplayAlert("ERROR", ex.Message, "OK");
            }

        }

        private async void InitializeTempSQLData()

        {
            try
            {
                SQLConfig sqlConfig = new SQLConfig();
                sqlConfig.DeleteAll<UserRole>("UserRole");

                if (!sqlConfig.GetItems<UserRole>().Any())
                {
                    sqlConfig.DeleteAllData();
                    sqlConfig.DeleteAll<User>("User");
                    sqlConfig.Insert(new User() { Id = "1", UserName = "Test User" });
                    sqlConfig.Insert(new User() { Id = "2", UserName = "Test Contractor" });

                    sqlConfig.DeleteAll<UserRole>("UserRole");
                    sqlConfig.Insert(new UserRole() { Id = "1", Title = "Site Engineer" });
                    sqlConfig.Insert(new UserRole() { Id = "2", Title = "QA" });
                    sqlConfig.Insert(new UserRole() { Id = "3", Title = "Contractor" });


                    sqlConfig.DeleteAll<City>("City");
                    sqlConfig.Insert(new City() { Id = "1", Name = "Pune" });
                    sqlConfig.Insert(new City() { Id = "2", Name = "Goa" });
                    sqlConfig.Insert(new City() { Id = "3", Name = "Mumbai" });


                    sqlConfig.DeleteAll<Project>("Project");
                    sqlConfig.Insert(new Project() { Id = "1", Name = "Osis", CityId = 1, Address = "Shivaji Nagar, Pune" });
                    sqlConfig.Insert(new Project() { Id = "2", Name = "EmerLand", CityId = 1, Address = "Chinchvar, Pune" });



                    sqlConfig.DeleteAll<Floor>("Floor");
                    sqlConfig.Insert(new Floor() { Id = "1", Title = "First Floor", FloorNo = 1 });
                    sqlConfig.Insert(new Floor() { Id = "2", Title = "Second Floor", FloorNo = 2 });
                    sqlConfig.Insert(new Floor() { Id = "3", Title = "Basement", FloorNo = -1 });
                    sqlConfig.Insert(new Floor() { Id = "4", Title = "Ground Floor", FloorNo = 0 });


                    sqlConfig.DeleteAll<RoomType>("RoomType");
                    sqlConfig.Insert(new RoomType() { Id = "1", Title = "Bedroom" });
                    sqlConfig.Insert(new RoomType() { Id = "2", Title = "Hall" });
                    sqlConfig.Insert(new RoomType() { Id = "3", Title = "Bedroom Balcony" });
                    sqlConfig.Insert(new RoomType() { Id = "4", Title = "Lift Room" });
                    sqlConfig.Insert(new RoomType() { Id = "5", Title = "Toilet" });

                    sqlConfig.DeleteAll<StatusGroup>("StatusGroup");
                    sqlConfig.Insert(new StatusGroup() { Id = "1", Title = "Open" });
                    sqlConfig.Insert(new StatusGroup() { Id = "2", Title = "In Progress" });
                    sqlConfig.Insert(new StatusGroup() { Id = "3", Title = "Completed" });
                    sqlConfig.Insert(new StatusGroup() { Id = "4", Title = "Rejected" });
                    sqlConfig.Insert(new StatusGroup() { Id = "5", Title = "Cancelled" });

                    sqlConfig.DeleteAll<NCStatus>("NCStatus");
                    sqlConfig.Insert(new NCStatus() { Id = "1", Title = "Open", StatusGroupId = 1 });
                    sqlConfig.Insert(new NCStatus() { Id = "2", Title = "In Progress", StatusGroupId = 2 });
                    sqlConfig.Insert(new NCStatus() { Id = "3", Title = "Completed", StatusGroupId = 3 });
                    sqlConfig.Insert(new NCStatus() { Id = "4", Title = "Cancelled", StatusGroupId = 5 });
                    sqlConfig.Insert(new NCStatus() { Id = "5", Title = "Completed by Other Contractor", StatusGroupId = 3 });
                    sqlConfig.Insert(new NCStatus() { Id = "6", Title = "Work Done", StatusGroupId = 2 });

                    sqlConfig.DeleteAll<NCStatusRole>("NCStatusRole");
                    sqlConfig.Insert(new NCStatusRole() { Id = "1", NCStatusId = 1, UserRoleId = 1 });
                    sqlConfig.Insert(new NCStatusRole() { Id = "2", NCStatusId = 2, UserRoleId = 3 });
                    sqlConfig.Insert(new NCStatusRole() { Id = "3", NCStatusId = 3, UserRoleId = 1 });
                    sqlConfig.Insert(new NCStatusRole() { Id = "4", NCStatusId = 3, UserRoleId = 2 });

                    sqlConfig.DeleteAll<Category>("Category");
                    sqlConfig.Insert(new Category() { Id = "0", Title = " ", ParentCategoryId = 0 });
                    sqlConfig.Insert(new Category() { Id = "1", Title = "Terra Wall", ParentCategoryId = 0 });
                    sqlConfig.Insert(new Category() { Id = "2", Title = "Structural Glazing", ParentCategoryId = 0 });
                    sqlConfig.Insert(new Category() { Id = "3", Title = "Safety", ParentCategoryId = 0 });
                    sqlConfig.Insert(new Category() { Id = "4", Title = "Damage/Impact to others work", ParentCategoryId = 1 });
                    sqlConfig.Insert(new Category() { Id = "5", Title = "Face Stone not proper", ParentCategoryId = 1 });
                    sqlConfig.Insert(new Category() { Id = "6", Title = "Safety Helmet Color Identity not Followed", ParentCategoryId = 3 });
                    sqlConfig.Insert(new Category() { Id = "7", Title = "Safety net for height work", ParentCategoryId = 3 });

                    sqlConfig.DeleteAll<Severity>("Severity");
                    sqlConfig.Insert(new Severity() { Id = "1", Title = "Medium" });
                    sqlConfig.Insert(new Severity() { Id = "2", Title = "Mild" });
                    sqlConfig.Insert(new Severity() { Id = "3", Title = "Severe" });
                    sqlConfig.Insert(new Severity() { Id = "4", Title = "Aesthetically Severe" });
                    sqlConfig.Insert(new Severity() { Id = "5", Title = "Functional Severe" });

                    sqlConfig.DeleteAll<RootCause>("RootCause");
                    sqlConfig.Insert(new RootCause() { Id = "1", Title = "Did not supervise" });
                    sqlConfig.Insert(new RootCause() { Id = "2", Title = "Allowed Bad material" });
                    sqlConfig.Insert(new RootCause() { Id = "3", Title = "Lack of knowledge" });
                    sqlConfig.Insert(new RootCause() { Id = "4", Title = "Improper supporting system" });
                    sqlConfig.Insert(new RootCause() { Id = "5", Title = "Checklist not implemented" });

                    sqlConfig.DeleteAll<StructuralMember>("StructuralMember");
                    sqlConfig.Insert(new StructuralMember() { Id = "1", Title = "Tie beam" });
                    sqlConfig.Insert(new StructuralMember() { Id = "2", Title = "Starecase" });
                    sqlConfig.Insert(new StructuralMember() { Id = "3", Title = "Stub Column" });
                    sqlConfig.Insert(new StructuralMember() { Id = "4", Title = "Column" });

                    sqlConfig.DeleteAll<UnitType>("UnitType");
                    sqlConfig.Insert(new UnitType() { Id = "1", Title = "Shop", ParentUnitTypeId = 0 });
                    sqlConfig.Insert(new UnitType() { Id = "2", Title = "Flate", ParentUnitTypeId = 0 });
                    sqlConfig.Insert(new UnitType() { Id = "3", Title = "Office", ParentUnitTypeId = 0 });
                    sqlConfig.Insert(new UnitType() { Id = "4", Title = "Parking", ParentUnitTypeId = 0 });
                    sqlConfig.Insert(new UnitType() { Id = "5", Title = "2 BHK", ParentUnitTypeId = 2 });
                    sqlConfig.Insert(new UnitType() { Id = "6", Title = "3 BHK", ParentUnitTypeId = 2 });
                    sqlConfig.Insert(new UnitType() { Id = "7", Title = "Entrance Lobby", ParentUnitTypeId = 0 });

                    sqlConfig.DeleteAll<UnitTypeRoom>("UnitTypeRoom");
                    sqlConfig.Insert(new UnitTypeRoom() { Id = "1", UnitTypeId = 5, RoomTypeId = 1 });
                    sqlConfig.Insert(new UnitTypeRoom() { Id = "2", UnitTypeId = 5, RoomTypeId = 2 });
                    sqlConfig.Insert(new UnitTypeRoom() { Id = "3", UnitTypeId = 3, RoomTypeId = 5 });
                    sqlConfig.Insert(new UnitTypeRoom() { Id = "4", UnitTypeId = 7, RoomTypeId = 5 });

                    sqlConfig.DeleteAll<Building>("Building");
                    sqlConfig.Insert(new Building() { Id = "1", Title = "B-Building", ProjectId = 1 });
                    sqlConfig.Insert(new Building() { Id = "2", Title = "A-Building", ProjectId = 1 });
                    sqlConfig.Insert(new Building() { Id = "3", Title = "Parijat", ProjectId = 2 });
                    sqlConfig.Insert(new Building() { Id = "4", Title = "Gulmohar", ProjectId = 2 });

                    sqlConfig.DeleteAll<BuildingFloor>("BuildingFloor");
                    sqlConfig.Insert(new BuildingFloor() { Id = "1", BuildingId = 1, FloorId = 1 });
                    sqlConfig.Insert(new BuildingFloor() { Id = "2", BuildingId = 1, FloorId = 2 });
                    sqlConfig.Insert(new BuildingFloor() { Id = "3", BuildingId = 1, FloorId = 3 });
                    sqlConfig.Insert(new BuildingFloor() { Id = "4", BuildingId = 2, FloorId = 1 });
                    sqlConfig.Insert(new BuildingFloor() { Id = "5", BuildingId = 2, FloorId = 2 });

                    sqlConfig.DeleteAll<BuildingUnit>("BuildingUnit");
                    sqlConfig.Insert(new BuildingUnit() { Id = "1", BuildingFloorId = 1, Title = "B01", UnitTypeId = 6 });
                    sqlConfig.Insert(new BuildingUnit() { Id = "2", BuildingFloorId = 1, Title = "B02", UnitTypeId = 5 });
                    sqlConfig.Insert(new BuildingUnit() { Id = "3", BuildingFloorId = 1, Title = "B03", UnitTypeId = 5 });
                    sqlConfig.Insert(new BuildingUnit() { Id = "4", BuildingFloorId = 2, Title = "A01", UnitTypeId = 6 });
                    sqlConfig.Insert(new BuildingUnit() { Id = "5", BuildingFloorId = 2, Title = "A02", UnitTypeId = 5 });
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "OK");
            }

        }

        private async void btnlogin_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (Username.Length==0)
                    throw new Exception("Username cannot be empty.");
                if (Password.Length == 0)
                    throw new Exception("Password cannot be empty.");
                GlobalWebServices webServices = new GlobalWebServices();
                User LoggedUser = new User();
                LoggedUser= await webServices.Login(Username, Password, "123").ConfigureAwait(false);
                //var LoggedIn = await webServices.GetUsers().ConfigureAwait(false);
                if (LoggedUser.UserRoleId!=null)
                {
                    CreateSession(Username, Password);
                    await Task.Run(async () =>
                    {
                        await Device.InvokeOnMainThreadAsync(() =>
                        {
                             Navigation.PushAsync(new GeraProjects_Page(LoggedUser.Id));
                        });
                    });
                }

            }
            catch (Exception ex)
            {
                await Task.Run(async () =>
                {
                    await Device.InvokeOnMainThreadAsync(async() =>
                    {
                        await DisplayAlert("ERROR", ex.Message, "OK");
                        Username=string.Empty;
                        Password=string.Empty;
                    });
                });
            }
        }
        public void CreateSession( string Username, string Password)
        {
            Preferences.Set("UserName", Username);
            Preferences.Set("Password", Password);
        }
    }
}