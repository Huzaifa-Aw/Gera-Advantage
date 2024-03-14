using GeraAdvantage.SQLServices;
using GeraAdvantage.WebServices;
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
    public partial class ViewCheckList : ContentPage, INotifyPropertyChanged, INotifyCollectionChanged
    {
        private int ChecklistTypeId;
        private int CategoryId;
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

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public ViewCheckList(int checklistTypeId,int categoryId)
        {
            BindingContext = this;
            InitializeComponent();
            ChecklistTypeId = checklistTypeId;
            CategoryId = categoryId;
            InitializeData();
            InitializeDummyData();
            listView.ItemsSource = _opsList;
            LCount.Text = _opsList.Count.ToString();
        }

        private async void InitializeData()
        {
            try
            {

                ChecklistSQLServices sQLServices = new ChecklistSQLServices();
                var Stages = sQLServices.GetCheckListStages(ChecklistTypeId);
                foreach (var item in Stages)
                {
                    switch (Stages.IndexOf(item))
                    {
                        case 0:
                            lblFirstBanner.Text = item.Title;
                            break;
                        case 1:
                            lblSecondBanner.Text = item.Title;
                            break;
                        case 2:
                            lblThirdBanner.Text = item.Title;
                            break;
                        default:
                            break;
                    }
                }

                GlobalWebServices globalWeb = new GlobalWebServices();
                var checkpoints = await globalWeb.GetCheckListStatusUserRolesAsync(ChecklistTypeId, CategoryId).ConfigureAwait(false);

            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private void InitializeDummyData()
        {
            _opsList = new List<MultileOps>();
            _opsList.Add(new MultileOps() { Title = "1- This is sample", isfour = false, isthree = true, ConverttoNC = false, SEComment = false, AddImage = false, btnYes = false, btnNo = false, btnNA = false, btnA = false, btnAWC = false, btnR = false ,Images= new List<ImageSource>()});
            _opsList.Add(new MultileOps() { Title = "2- This is sample", isfour = true, isthree = false, ConverttoNC = false, SEComment = false, AddImage = true, btnYes = false, btnNo = false, btnNA = false, btnA = false, btnAWC = false, btnR = false });
            _opsList.Add(new MultileOps() { Title = "3- This is sample", isfour = false, isthree = true, ConverttoNC = false, SEComment = false, AddImage = false, btnYes = false, btnNo = false, btnNA = false, btnA = false, btnAWC = false, btnR = false });
            _opsList.Add(new MultileOps() { Title = "4- This is sample", isfour = true, isthree = false, ConverttoNC = false, SEComment = false, AddImage = true, btnYes = false, btnNo = false, btnNA = false, btnA = false, btnAWC = false, btnR = false });
            _opsList.Add(new MultileOps() { Title = "5- This is sample", isfour = false, isthree = true, ConverttoNC = false, SEComment = false, AddImage = true, btnYes = false, btnNo = false, btnNA = false, btnA = false, btnAWC = false, btnR = false });
            _opsList.Add(new MultileOps() { Title = "6- This is sample", isfour = true, isthree = false, ConverttoNC = false, SEComment = false, AddImage = false, btnYes = false, btnNo = false, btnNA = false, btnA = false, btnAWC = false, btnR = false });
            _opsList.Add(new MultileOps() { Title = "7- This is sample", isfour = false, isthree = true, ConverttoNC = false, SEComment = false, AddImage = false, btnYes = false, btnNo = false, btnNA = false, btnA = false, btnAWC = false, btnR = false });
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
        private void listView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            SeletedItem = (MultileOps)e.Item;
        }
    }


}