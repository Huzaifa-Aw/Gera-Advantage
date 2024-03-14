using GeraAdvantage.SQLServices;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GeraAdvantage
{
    public partial class App : Application
    {
        private static SQLiteService sQLiteService;
        public static SQLiteService SQLiteService
        {
            get
            {
                if (sQLiteService == null)
                {
                    sQLiteService = new SQLiteService();
                }
                return sQLiteService;
            }
        }
        public App()
        {
            InitializeComponent();
            DependencyService.Get<ISQLite>().GetConnectionWithCreateDatabase();
            MainPage = new NavigationPage(new Login_Page());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
