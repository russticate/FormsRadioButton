using System;

namespace FormsRadioButton
{
    public class RadioItemToggledEventArgs : EventArgs
    {
        public RadioItem SelectedItem { get; }

        public RadioItemToggledEventArgs(RadioItem selectedItem)
        {
            SelectedItem = selectedItem;     
        }
    }
}
