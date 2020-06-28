using Xamarin.Forms;

namespace HRApp.CustomControls
{
    public class CustomEntry : Entry
    {

        public static BindableProperty HasTransparentBorderProperty
      = BindableProperty.Create(nameof(HasTransparentBorder), typeof(bool), typeof(CustomEditor), true);

        public bool HasTransparentBorder
        {
            get { return (bool)GetValue(HasTransparentBorderProperty); }
            set { SetValue(HasTransparentBorderProperty, value); }
        }
    }
}

