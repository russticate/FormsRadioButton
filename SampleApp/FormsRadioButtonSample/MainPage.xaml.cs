using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
