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
    public partial class UpdateQuestion : ContentPage
    {
        public UpdateQuestion()
        {
            InitializeComponent();
            OptionTitle.Text = "1-This is Sample Text";
            isthreelayout.IsVisible = true;
            isfourlayout.IsVisible = false;
            
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            var Btn = (Button)sender;
            Btn.BorderColor = Color.DodgerBlue;
            switch (Btn.Text)
            {
                case "AWC":
                   ConverttoNCLayout.IsVisible = false;
                    SECommentLayout.IsVisible = true;
                    break;
                case "R":
                    ConverttoNCLayout.IsVisible = true;
                    SECommentLayout.IsVisible = false;
                    break;
                default:
                    ConverttoNCLayout.IsVisible = false;
                    SECommentLayout.IsVisible = false;
                    break;
            }
        }
    }
}