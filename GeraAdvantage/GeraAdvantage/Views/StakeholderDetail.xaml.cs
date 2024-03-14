using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GeraAdvantage.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StakeholderDetail : ContentPage
    {

        public StakeholderDetail()
        {
            InitializeComponent();
            btnEdit.IsVisible = false;
        }

        public StakeholderDetail(string title, bool isMyProfile)
         {
            InitializeComponent(); 
            PageTitle.Text = title;
            btnEdit.IsVisible = isMyProfile;
        }

        private void Phone_Clicked(object sender, EventArgs e) => CrossMessaging.Current.PhoneDialer.MakePhoneCall(lblPhone.Text);
        private void Mail_Clicked(object sender, EventArgs e) => Device.OpenUri(new Uri($"mailto:{lblMail.Text}"));

        private async void btnEdit_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfileEditor());
        }
    }
}