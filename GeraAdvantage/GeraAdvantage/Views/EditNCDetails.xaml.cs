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
    public partial class EditNCDetails : ContentPage
    {
        private List<string> _sampleText;

        public List<string> SampleText
        {
            get => _sampleText;
            set
            {
                if (value == _sampleText)
                {
                    return;
                }
                _sampleText = value;
                OnPropertyChanged(nameof(SampleText));
            }
        }


        public EditNCDetails()
        {
            BindingContext = this;
            InitializeComponent();
            SampleText = new List<string>()
            {
                        "New York",
                        "London",
                        "Mumbai",
                        "Chicago"
            };
        }

    }
}