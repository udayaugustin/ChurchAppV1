using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;

namespace HRApp.Views
{
    public partial class AdminAllReferalList : ContentPage
    {
        private SQLiteAsyncConnection connection;
        private List<CandidateReferral> referalList;

        public AdminAllReferalList()
        {
            InitializeComponent();
            connection = DependencyService.Get<ISQLiteDb>().GetConnection();

            GetData();
        }

        private async Task GetData()
        {
            referalList = new List<CandidateReferral>();
            referalList = await connection.Table<CandidateReferral>().ToListAsync();

            listView.ItemsSource = null;
            listView.ItemsSource = referalList;
        }
    }
}
