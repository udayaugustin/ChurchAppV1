using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using HRApp.Model;
using Xamarin.Forms;

namespace HRApp.Views
{
    public partial class VideoList : ContentPage
    {
        private string video_list_url = "http://uthayakumarbooks.com/vpmchurch/video/video_list_api.php";

        public VideoList()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var client = new HttpClient();
            var data = await client.GetStringAsync(video_list_url);

            var video_list = Video.FromJson(data);
            var meeting = video_list.ToList().FirstOrDefault();
            listview.ItemsSource = video_list.ToList();
        }

        private async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            var video = (sender as Button).BindingContext as Video;
            await Application.Current.MainPage.Navigation.PushAsync(new VideoDetailPage(video));
        }
    }
}
