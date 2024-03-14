using GeraAdvantage.SQLServices;
using GeraAdvantage.Utils;
using GeraAdvantage.Views;
using GeraAdvantage.WebServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GeraAdvantage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GeraProjects_Page : ContentPage
    {
        private GlobalWebServices globalWebServices = new GlobalWebServices();
        private NCSQLServices ncServices = new NCSQLServices();
        private List<Project> projectsList;
        private string LoggedUserId;
        public GeraProjects_Page(string userId)
        {
            InitializeComponent();
            LoggedUserId = userId;
            InitializeData();
            //DummyDataInitialization();
            //DefineGridLayout();
        }

        private async void InitializeData()
        {
            projectsList= await globalWebServices.GetProjectsbyUser(LoggedUserId).ConfigureAwait(false);
            await Task.Run(async () =>
            {
                await Device.InvokeOnMainThreadAsync(() =>
                {
                    DefineGridLayout();
                });
            });
        }

        private void DummyDataInitialization()
        {
            //projectsList = new List<Project>();
            //projectsList.Add(new Project { Title = "Mocca", TotalNCCount = 12, OpenNCCount = 1 });
            //projectsList.Add(new Project { Title = "Espresso", TotalNCCount = 6, OpenNCCount = 43 });
            //projectsList.Add(new Project { Title = "Latte", TotalNCCount = 2, OpenNCCount = 5 });
            //projectsList.Add(new Project { Title = "Americano", TotalNCCount = 12, OpenNCCount = 1 });
            //projectsList.Add(new Project { Title = "Arabica", TotalNCCount = 9, OpenNCCount = 4 });
        }

        private void DefineGridLayout()
        {

            var rowlimit = projectsList.Count / 2 + (projectsList.Count % 2 == 0 ? 0 : 1);

            var productIndex = 0;
            for (int rowIndex = 0; rowIndex < rowlimit; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < 2; columnIndex++)
                {
                    if (productIndex >= projectsList.Count)
                    {
                        break;
                    }
                    var product = projectsList[productIndex];
                    productIndex += 1;
                   var _NCsList = ncServices.GetNCs();

                    var GridCellLayout = new StackLayout
                    {
                        Style = (Style)Application.Current.Resources["ProjectCellLayout"]
                    };
                    var frame = new StackLayout
                    {
                        Style = (Style)Application.Current.Resources["ProjectframeLayout"]
                    };
                    var image = new Image
                    {
                        Source = "noimage.png",
                        Style = (Style)Application.Current.Resources["ProjectImage"]

                    };
                    var innerlayout = new StackLayout
                    {
                        Style = (Style)Application.Current.Resources["ProjectInnerLayout"]
                    };
                    var Titlelabel = new Label
                    {
                        Text = product.Name,
                        Style = (Style)Application.Current.Resources["ProjectLabel"]
                    };

                    var TotalNClabel = new Label
                    {
                        
                        //Text = "Total NCs: " + product.TotalNCCount.ToString(),
                        Text = "Total NCs: " +_NCsList.Count.ToString(),
                        Style = (Style)Application.Current.Resources["ProjectLabel"]

                    };
                    var OpenNClabel = new Label
                    {
                        //Text = "Open NCs: " + product.OpenNCCount.ToString(),
                        Text = "Open NCs: " + _NCsList.Count.ToString(),
                        Style = (Style)Application.Current.Resources["ProjectLabel"]

                    };
                    innerlayout.Children.Add(Titlelabel);
                    innerlayout.Children.Add(TotalNClabel);
                    innerlayout.Children.Add(OpenNClabel);
                    frame.Children.Add(image);
                    GridCellLayout.Children.Add(frame);
                    GridCellLayout.Children.Add(innerlayout);

                    var tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.Tapped += async (s, e) =>
                    {
                        int nRow = Grid.GetRow((BindableObject)s);
                        int nCol = Grid.GetColumn((BindableObject)s);

                        int projID = 2 * nRow + nCol;
                        //await DisplayAlert("Title", projectsList[projID].Name, "OK");
                        await Navigation.PushAsync(new ProjectDetails_Page(projectsList[projID].Id));
                    };
                    GridCellLayout.GestureRecognizers.Add(tapGestureRecognizer);
                    projectsGLayout.Children.Add(GridCellLayout, columnIndex, rowIndex);
                }
            }
        }

        private async void MyProfile_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StakeholderDetail("My Profile", true));
        }

        private async void Logout_Clicked(object sender, EventArgs e)
        {
            ClearPreferences();
            await Navigation.PopAsync();
        }

        private void ClearPreferences()
        {
            Preferences.Set("UserName", String.Empty);
            Preferences.Set("Password", String.Empty);
        }
    }
}