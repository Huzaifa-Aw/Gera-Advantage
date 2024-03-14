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
    public partial class ShowNCHistory : ContentPage
    {
        private List<NCHistory> _ncHistory;
        public ShowNCHistory()
        {
            BindingContext = this;
            InitializeComponent();
            DummyDataInitialization();
            listView.ItemsSource = _ncHistory;
        }
        private void DummyDataInitialization()
        {
            _ncHistory = new List<NCHistory>();
            _ncHistory.Add(new NCHistory {  Comment = "B-Bld -as - 0.1", UpdatedBy = "Test User", UpdatedAt = DateTime.Now.ToString(), Status = "Pending" });
            _ncHistory.Add(new NCHistory {  Comment = "B-Bld -as - 0.1", UpdatedBy = "Test User", UpdatedAt = DateTime.Now.ToString(), Status = "Pending" });
            _ncHistory.Add(new NCHistory {  Comment = "B-Bld -as - 0.1", UpdatedBy = "Test User", UpdatedAt = DateTime.Now.ToString(), Status = "Pending" });
            _ncHistory.Add(new NCHistory {  Comment = "B-Bld -as - 0.1", UpdatedBy = "Test User", UpdatedAt = DateTime.Now.ToString(), Status = "Pending" });
            _ncHistory.Add(new NCHistory {  Comment = "B-Bld -as - 0.1", UpdatedBy = "Test User", UpdatedAt = DateTime.Now.ToString(), Status = "Pending" });
        }
    }
}