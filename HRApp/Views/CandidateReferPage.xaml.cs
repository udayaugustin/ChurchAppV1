using System;
using System.Collections.Generic;
using System.Net.Http;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using SQLite;
using Xamarin.Forms;

namespace HRApp.Views
{
    public partial class CandidateReferPage : ContentPage
    {
        HttpClient httpClient;
        private SQLiteAsyncConnection connection;
        FileData fileData;

        public CandidateReferPage()
        {
            InitializeComponent();
            
            httpClient = new HttpClient();
            connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        private async void Save(object sender, EventArgs e)
        {
            var record = new CandidateReferral
            {
                Name = Name.Text,
                Phone = Phone.Text,
                ApplyingRole = ApplyingRole.Text,
                YearsOfExperience = YearsOfExp.Text,
                CurrentCompany = CurrentCompany.Text,
                CurrentLocation = CurrentLocation.Text,
                OpenForRelocation = OpenForRelocation.Text,
                CreatedDate = DateTime.Now.Date
            };

            await connection.InsertAsync(record);
        }

        private async void ChooseFile(object sender, EventArgs e)
        {
            try
            {
                var url = "http://uthayakumarbooks.com/Mail/UdayApi.php";

                var status1 = await httpClient.PostAsync(url, new StringContent("uday"));

                fileData = await CrossFilePicker.Current.PickFile();
                if (fileData == null)
                    return; // user canceled file picking
                var name = "Uday";

                string fileName = fileData.FileName;

                //string contents = System.Text.Encoding.UTF8.GetString(fileData.DataArray);
                //httpClient.DefaultRequestHeaders.Add("Accept", "application/x-www-form-urlencoded");

                using (var content = new MultipartFormDataContent())
                {
                    content.Add(new StreamContent(fileData.GetStream()), "file", "file_" + DateTime.Now.ToString("d-MMM-yyyy-HH:mm:ss") + fileName);
                    content.Add(new StringContent(name), "Mobile");

                    var status = await httpClient.PostAsync(url, content);
                    var response = await status.Content.ReadAsStringAsync();
                }

                System.Console.WriteLine("File name chosen: " + fileName);
                //System.Console.WriteLine("File data: " + contents);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception choosing file: " + ex.ToString());
            }
        }

        private void NotifyTeamViaMail()
        {

        }
    }
}
