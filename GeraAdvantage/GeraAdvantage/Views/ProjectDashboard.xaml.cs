using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static GeraAdvantage.Utils.Entities;

namespace GeraAdvantage.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProjectDashboard : ContentPage
    {
        private ObservableCollection<ConformityPie> PieData1, PieData2;
        private SfChart ConfortmityChart, NonConfotmityChart;

        private void Picker_Focused(object sender, FocusEventArgs e)
        {

        }

        public ProjectDashboard()
        {
            InitializeComponent();
            ConfortmityChart = new SfChart();
            NonConfotmityChart = new SfChart();
            PieData1 = new ObservableCollection<ConformityPie>()
            {
            new ConformityPie(){Title="Acceptable",Count=1 },
            new ConformityPie(){Title="NoStatus",Count=1 },
            //new PieData(){ Month="Apr", Target=57 },
            //new PieData(){ Month="May", Target=48 },
            };
            PieData2 = new ObservableCollection<ConformityPie>()
            {
            new ConformityPie(){Title="Medium",Count=11 },
            new ConformityPie(){Title="Extreme Severity",Count=1 },
            new ConformityPie(){Title="Severe",Count=3 },
            //new PieData(){ Month="Apr", Target=57 },
            //new PieData(){ Month="May", Target=48 },
            };

            PieSeries pieSeries = new PieSeries()
            {
                ItemsSource = PieData1,
                XBindingPath = "Title",
                YBindingPath = "Count",
                CircularCoefficient = 0.5,

            };   
            PieSeries pieSeries2 = new PieSeries()
            {
                ItemsSource = PieData2,
                XBindingPath = "Title",
                YBindingPath = "Count",
                CircularCoefficient = 0.5,

            };
            pieSeries.DataMarker = new ChartDataMarker();
            pieSeries2.DataMarker = new ChartDataMarker();
            ConfortmityChart.Legend = new ChartLegend();
            NonConfotmityChart.Legend = new ChartLegend();
            pieSeries.DataMarker.LabelContent = LabelContent.Percentage;
            pieSeries2.DataMarker.LabelContent = LabelContent.Percentage;
            ConfortmityChart.Series.Add(pieSeries);
            NonConfotmityChart.Series.Add(pieSeries2);

            ConformityChartLayout.Children.Add(ConfortmityChart);
           NonConformityChartLayout.Children.Add(NonConfotmityChart);

            ConformityGrid.ItemsSource = PieData1;
            NonConformityGrid.ItemsSource = PieData2;
        }
    }
}