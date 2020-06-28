using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HRApp.Views
{
    public partial class LoginPage : ContentPage
    {
        const string AdminUserName= "admin@accionlabs.com";
        const string AdminPassword = "admin";

        const string EmployeeUserName = "emp@accionlabs.com";
        const string EmployeePassword = "admin";

        private bool IsLoginSuccess;

        public LoginPage()
        {
            InitializeComponent();
        }

        private void GoToCreateJob(object sender, EventArgs e)
        {
            if(Username.Text == AdminUserName && Password.Text == AdminPassword)
            {
                Application.Current.Properties["LoggedInUserType"] = "Admin";
                IsLoginSuccess = true;
            }
            else if(Username.Text == EmployeeUserName && Password.Text == EmployeePassword)
            {
                Application.Current.Properties["LoggedInUserType"] = "Employee";
                IsLoginSuccess = true;
            }

            if (IsLoginSuccess)
            {
                MasterPage fpm = new MasterPage();
                fpm.Detail = new NavigationPage(new JobListPage());
                Application.Current.MainPage = fpm;
            }            
        }
        
    }
}
