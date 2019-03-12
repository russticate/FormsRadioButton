using FormsRadioButton;
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
            NotifyViaEvent.Toggled += NotifyViaEvent_Toggled;
        }

        void NotifyViaEvent_Toggled(object sender, ToggledEventArgs e)
        {
            if (sender is Switch eventSwitch)
            {
                if (eventSwitch.IsToggled)
                {
                    FormsRadioButton.ItemToggled += FormsRadioButton_ItemToggled;
                }

                else
                {
                    FormsRadioButton.ItemToggled -= FormsRadioButton_ItemToggled;
                }

                ManualSelectButton.IsEnabled = !eventSwitch.IsToggled;
            }
        }

        // You could always use a behavior to forward this event to a command if you wanted to go full MVVM.
        async void FormsRadioButton_ItemToggled(object sender, RadioItemToggledEventArgs e)
        {
            await Application.Current?.MainPage.DisplayAlert("Hi :)", $"Manual selection is item: {e.SelectedItem.Text}", "Cool, thanks");
        }
    }
}
