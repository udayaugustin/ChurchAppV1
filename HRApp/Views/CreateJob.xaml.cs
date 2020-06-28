using System;
using SQLite;
using Xamarin.Forms;

namespace HRApp.Views
{
    public partial class CreateJob : ContentPage
    {
        private SQLiteAsyncConnection connection;

        public CreateJob()
        {
            InitializeComponent();
            connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        private void GoToJobListing(object sender, EventArgs e)
        {
            Navigation.PushAsync(new JobListPage());
        }

        private async void Save(object sender, EventArgs e)
        {
            var job = new Job
            {
                JobTitle = JobTitle.Text,
                OpenPositions = OpenPositions.Text,
                RequiredExperience = RequiredExperience.Text,
                SkillSet = SkillSet.Text,
                ExpectedNoticePeriod = ExpectedNoticePeriod.Text,
                JobDescription = JobDescription.Text
            };

            await connection.InsertAsync(job);

            await Navigation.PushAsync(new JobListPage());
        }
    }
}
