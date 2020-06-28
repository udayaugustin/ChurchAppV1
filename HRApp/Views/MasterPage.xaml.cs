using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HRApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : MasterDetailPage
    {
        MasterDetailPage mainPage;
        public MasterPage()
        {
            InitializeComponent();

            SetupMenu();            
        }

        public void SetupMenu()
        {
            var menuList = new List<MenuItem>
            {
                new MenuItem{ Title = "Create Job", IsAdminMenu= true, IsEmployeeMenu = false, Image = "money.png" },
                new MenuItem{ Title = "Referal List", IsAdminMenu = true, IsEmployeeMenu = false, Image = "component.png"},
                new MenuItem{ Title = "Job Openings", IsAdminMenu = true, IsEmployeeMenu = true, Image = "component.png"},
                new MenuItem{ Title = "Refer a Candidate", IsAdminMenu = false, IsEmployeeMenu=true, Image = "component.png"},
                new MenuItem{ Title = "Your Referal", IsAdminMenu = false,  IsEmployeeMenu=true, Image = "component.png"},
                new MenuItem{ Title= "Signout", IsAdminMenu = true, IsEmployeeMenu = true, Image = "signout.png"}
            };

            if (Application.Current.Properties["LoggedInUserType"].ToString() == "Admin")
            {
                listView.ItemsSource = menuList.Where(m => m.IsAdminMenu == true).ToList();
            }
            else
            {
                listView.ItemsSource = menuList.Where(m => m.IsEmployeeMenu == true).ToList();
            }            
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            mainPage = Application.Current.MainPage as MasterDetailPage;
            var menu = e.Item as MenuItem;
            switch (menu.Title)
            {
                case "Create Job":
                    mainPage.Detail = new NavigationPage(new CreateJob());
                    break;

                case "Referal List":
                    mainPage.Detail = new NavigationPage(new AdminAllReferalList());
                    break;

                case "Job Openings":
                    mainPage.Detail = new NavigationPage(new JobListPage());
                    break;

                case "Report":
                    mainPage.Detail = new NavigationPage(new JobListPage());
                    break;

                case "Refer a Candidate":
                    mainPage.Detail = new NavigationPage(new CandidateReferPage());
                    break;

                case "Your Referal":
                    mainPage.Detail = new NavigationPage(new AdminAllReferalList());
                    break;

                case "Signout":                    
                    mainPage.Detail = new NavigationPage(new LoginPage());
                    break;

            }

            mainPage.IsPresented = false;
        }

        private void Synch(object sender, EventArgs e)
        {
            //mainPage = Application.Current.MainPage as MasterDetailPage;
            //mainPage.Detail = new NavigationPage(new SyncData());
        }
    }
}
