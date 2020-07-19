using System;
using System.Collections.Generic;
using HRApp.Model;
using Xamarin.Forms;

namespace HRApp.Views
{
    public partial class VideoDetailPage : ContentPage
    {
        public VideoDetailPage(Video video)
        {
            InitializeComponent();

            Title = video.Title;
            webView.Source = video.Url.AbsoluteUri;
        }
    }
}
