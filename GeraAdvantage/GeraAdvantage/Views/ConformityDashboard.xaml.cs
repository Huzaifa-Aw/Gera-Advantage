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
    public partial class ConformityDashboard : ContentPage
    {
        private List<Project> projectsList;
        public ConformityDashboard()
        {
            InitializeComponent();
            DummyDataInitialization();
            DefineGridLayout();
        }

        private void DummyDataInitialization()
        {
            projectsList = new List<Project>();
            projectsList.Add(new Project { Title = "Mocca", TotalNCCount = 12, OpenNCCount = 1, Severity = "Medium" });
            projectsList.Add(new Project { Title = "Espresso", TotalNCCount = 6, OpenNCCount = 43, Severity = "Extreme Severe" });
            projectsList.Add(new Project { Title = "Latte", TotalNCCount = 2, OpenNCCount = 5, Severity = "Severe" });
            projectsList.Add(new Project { Title = "Americano", TotalNCCount = 12, OpenNCCount = 1, Severity = "Medium" });
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
                    var GridCellLayout = new StackLayout
                    {
                        Style= (Style)Application.Current.Resources["ConformityCellLayout"]
                    };
                    var TotalCountView = new StackLayout
                    {
                        
                        Style= (Style)Application.Current.Resources["ConformityTotalCount"]
                    };
                    var StatusView = new StackLayout
                    {
                        Style = (Style)Application.Current.Resources["ConformityStatusView"]

                    };
                    var lbTC = new Label
                    {
                        Text = "Total Count",
                        Style = (Style)Application.Current.Resources["ConformityDashboardTLabel"]

                    };
                    var lbTotalCount = new Label
                    {
                        Text = product.TotalNCCount.ToString(),
                        FontAttributes = FontAttributes.Bold,
                        Style = (Style)Application.Current.Resources["ConformityDashboardTLabel"]
                    };
                    var lbStatus = new Label
                    {
                        Text = product.Severity,
                        Style = (Style)Application.Current.Resources["ConformityDashboardSLabel"]
                    };

                    TotalCountView.Children.Add(lbTC);
                    TotalCountView.Children.Add(lbTotalCount);

                    StatusView.Children.Add(lbStatus);

                    GridCellLayout.Children.Add(TotalCountView);
                    GridCellLayout.Children.Add(StatusView);

                    var tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.Tapped += async (s, e) =>
                    {
                        int nRow = Grid.GetRow((BindableObject)s);
                        int nCol = Grid.GetColumn((BindableObject)s);

                        int projID = 2 * nRow + nCol;
                        await DisplayAlert("Title", projectsList[projID].Title, "OK");
                    };
                    GridCellLayout.GestureRecognizers.Add(tapGestureRecognizer);
                    DashboardGLayout.Children.Add(GridCellLayout, columnIndex, rowIndex);
                }
            }
        }
    }
}
