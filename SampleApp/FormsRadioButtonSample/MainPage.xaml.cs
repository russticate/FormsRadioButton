using Xamarin.Forms;

namespace FormsRadioButtonSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(this, true);
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }
    }
}
