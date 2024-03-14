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
    public partial class ReviewQuestion : ContentPage
    {
        
             private List<ReviewQ> _List=new List<ReviewQ>() {  };

        private List<ReviewQ> ReviewList
        {
            get => _List;
            set
            {
                if (value == _List)
                {
                    return;
                }
                _List = value;
                OnPropertyChanged(nameof(ReviewList));
            }
        }
        public ReviewQuestion()
        {
            InitializeComponent();
            InitializeDummyData();
            listView.ItemsSource = ReviewList;
        }

        private void InitializeDummyData()
        {
            ReviewList.Add(new ReviewQ() { Title = "1-Sample Question", BGColor = Color.Green, BtnText = "Yes" });
            ReviewList.Add(new ReviewQ() { Title = "2-Sample Question", BGColor = Color.Red, BtnText = "No" });
            ReviewList.Add(new ReviewQ() { Title = "3-Sample Question", BGColor = Color.Purple, BtnText = "NA" });
        }

        private async void listView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new UpdateQuestion());
        }
    }

   
}