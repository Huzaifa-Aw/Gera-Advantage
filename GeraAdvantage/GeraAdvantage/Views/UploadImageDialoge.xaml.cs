using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GeraAdvantage.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UploadImageDialoge 
    {
        public UploadImageDialoge()
        {
            InitializeComponent();
        }

        private async void Camera_Tapped(object sender, EventArgs e)
        {
            var result = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions()
            {
                Title = "Please Select an Image."
            });
            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                //tempImage.Source = ImageSource.FromStream(() => stream);
                MessagingCenter.Send<FileResult>(result, "ImageDialoge");
            await PopupNavigation.Instance.PopAsync();

            }
        }
        private async void Gallery_Tapped(object sender, EventArgs e)
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions()
            {
                Title = "Please Select an Image."
            });
            if (result != null)
            {
                var stream = await result.OpenReadAsync();
                //tempImage.Source = ImageSource.FromStream(() => stream);
                MessagingCenter.Send<FileResult>(result, "ImageDialoge");
                await PopupNavigation.Instance.PopAsync();

            }
        }
    }
}