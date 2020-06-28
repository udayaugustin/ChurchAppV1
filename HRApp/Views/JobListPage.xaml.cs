using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;

namespace HRApp.Views
{
    public partial class JobListPage : ContentPage
    {
        private SQLiteAsyncConnection connection;
        private List<Job> jobList;


        public JobListPage()
        {
            InitializeComponent();

            connection = DependencyService.Get<ISQLiteDb>().GetConnection();

            /*jobListView.ItemsSource = new List<JobListing>
            {
            new JobListing { JobTitle = ".NET Developer with 4Yr Exp", Positions = "4 Positions", SkillSet = "C#, MVC, SQL Server, Angular" },
            new JobListing { JobTitle = ".NET Developer with 4Yr Exp", Positions = "4 Positions", SkillSet = "C#, MVC, SQL Server, Angular" },
            new JobListing { JobTitle = ".NET Developer with 4Yr Exp", Positions = "4 Positions", SkillSet = "C#, MVC, SQL Server, Angular" },
            new JobListing { JobTitle = ".NET Developer with 4Yr Exp", Positions = "4 Positions", SkillSet = "C#, MVC, SQL Server, Angular" }
            };*/

            GetData();
        }

        private async Task GetData()
        {
            jobList = new List<Job>();
            jobList = await connection.Table<Job>()
                .OrderByDescending(j => j.Id)
                .ToListAsync();

            jobListView.ItemsSource = null;
            jobListView.ItemsSource = jobList;
        }

        private void GoToJobDetails(object sender, EventArgs e)
        {
            var job = (sender as Button).CommandParameter as Job; 
            Navigation.PushAsync(new JobDetails(job));
        }
        

    }
}
