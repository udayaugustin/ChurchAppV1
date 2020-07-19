using System;
using System.Collections.Generic;
using HRApp.Model;
using Xamarin.Forms;

namespace HRApp.Views
{
    public partial class YoutubePage : ContentPage
    {
        public YoutubePage()
        {
            InitializeComponent();
        }

        private void ListViewOnItemTapped(object sender, ItemTappedEventArgs itemTappedEventArgs)
        {
            var youtubeItem = itemTappedEventArgs.Item as YoutubeItem;
            //Application.Current.MainPage.Navigation.PushAsync(new VideoDetailPage("https://www.youtube.com/watch?v=" + youtubeItem?.VideoId));

            // You can use Plugin.Share nuget package to open video in browser
            //CrossShare.Current.OpenBrowser("https://www.youtube.com/watch?v=" + youtubeItem?.VideoId);
        }
    }
}
