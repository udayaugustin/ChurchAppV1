using System;
using Android.Content;
using Android.Graphics.Drawables;
using HRApp.CustomControls;
using HRApp.Droid.CustomRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace HRApp.Droid.CustomRenderer
{
    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var customControl = (CustomEntry)Element;
                if (customControl.HasTransparentBorder)
                {
                    ApplyBorder();

                }
                else
                {
                    var gradientBackground = new GradientDrawable();
                    gradientBackground.SetShape(ShapeType.Rectangle);

                    gradientBackground.SetStroke(2, Color.FromHex("#50B1FF").ToAndroid());
                    Control.SetBackground(gradientBackground);
                }
            }
        }

        private void ApplyBorder()
        {
            var gradientBackground = new GradientDrawable();
            gradientBackground.SetShape(ShapeType.Rectangle);

            gradientBackground.SetStroke(0, Color.Transparent.ToAndroid());
            Control.SetBackground(gradientBackground);
        }
    }
}
