using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HRApp.Views
{
    public partial class VideoDetailPage : ContentPage
    {
        public VideoDetailPage(string videoUrl)
        {
            InitializeComponent();

            video.Source = videoUrl;
        }
    }
}
