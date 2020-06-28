using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HRApp.Views
{
    public partial class JobDetails : ContentPage
    {
        public JobDetails(Job job)
        {
            InitializeComponent();

            if(Application.Current.Properties["LoggedInUserType"].ToString() == "Admin")
            {
                ReferCandidateButton.IsVisible = false;
            }

            JobTitle.Text = job.JobTitle;
            OpenPositions.Text = "No of Positions : "+job.OpenPositions;
            RequiredExperience.Text = "Required Experience : " + job.RequiredExperience + " Years";
            SkillSet.Text = "SkillSet : " + job.SkillSet;
            ExpectedNoticePeriod.Text = "Expected Notice Period : " + job.ExpectedNoticePeriod + " Days";
            JobDescriptionValue.Text = job.JobDescription;            
        }

        private void Refer(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CandidateReferPage());
        }
    }
}
