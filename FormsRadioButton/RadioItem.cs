using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FormsRadioButton
{
    public class RadioItem : INotifyPropertyChanged
    {
        public string Text { get; set; }

        bool toggled;
        public bool Toggled
        {
            get => toggled;
            set
            {
                if (toggled != value)
                {
                    toggled = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
