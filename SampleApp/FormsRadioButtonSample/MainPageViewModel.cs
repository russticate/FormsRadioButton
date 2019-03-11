using System.Linq;
using System.Windows.Input;
using FormsRadioButton;
using Xamarin.Forms;

namespace FormsRadioButtonSample
{
    public class MainPageViewModel
    {
        public MainPageViewModel()
        {
            RadioItems = new RadioItems();

            for (int i = 0; i < 5; i++)
            {
                RadioItems.Add(new RadioItem
                {
                    Text = i.ToString(),
                    Toggled = false
                });
            }
        }

        public RadioItems RadioItems  { get; set; }

        readonly ICommand manualGetCommand;
        public ICommand ManualGetCommand => manualGetCommand ?? new Command(OnManualGetCommandExecuted);

        private async void OnManualGetCommandExecuted(object obj)
        {
            var selectedRadioItem = RadioItems.FirstOrDefault(x => x.Toggled == true);

            if (selectedRadioItem == null)
            {
                await Application.Current?.MainPage.DisplayAlert("Sadface.gif", "You gotta select something bro.", "Ok man thanks");
            }

            else
            {
                await Application.Current?.MainPage.DisplayAlert("Hi :)", $"Manual selection is item: {selectedRadioItem.Text}", "Cool, thanks");
            }
        }
    }
}
