using HRApp.Views;
using SQLite;
using Xamarin.Forms;

namespace HRApp
{
    public partial class App : Application
    {        
        private SQLiteAsyncConnection connection;        

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            //MainPage = new NavigationPage(new VideoList());
            /*(MainPage as MasterDetailPage).Detail = new NavigationPage(new CreateJob());*/
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            /*connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            connection.CreateTableAsync<CandidateReferral>();
            connection.CreateTableAsync<Job>();*/
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
