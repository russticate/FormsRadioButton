using System;

namespace FormsRadioButton
{
    public class RadioItemToggledEventArgs : EventArgs
    {
        public RadioItem SelectedItem { get; }
        public int SelectedIndex { get; }

        public RadioItemToggledEventArgs(RadioItem selectedItem, int selectedIndex)
        {
            SelectedItem = selectedItem;
            SelectedIndex = selectedIndex;
        }
    }
}
