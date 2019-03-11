using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace FormsRadioButton
{
    public class RadioItems : ObservableCollection<RadioItem>
    {
        public RadioItems()
        {
            CollectionChanged += RadioItemsCollectionChanged;
        }

        void RadioItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (RadioItem radioItem in e.NewItems)
                {
                    radioItem.PropertyChanged += RadioItemToggled;
                }
            }

            if (e.OldItems != null)
            {
                foreach (RadioItem radioItem in e.OldItems)
                {
                    radioItem.PropertyChanged -= RadioItemToggled;
                }
            }
        }

        bool busy;
        int highestSelectedIndex;

        void RadioItemToggled(object sender, PropertyChangedEventArgs e)
        {
            if (busy) return;
            busy = true;

            if (sender is RadioItem toggledRadioItem)
            {
                var indexOfSelectedItem = IndexOf(toggledRadioItem);

                if (indexOfSelectedItem > highestSelectedIndex)
                {
                    highestSelectedIndex = indexOfSelectedItem;
                }

                foreach (var radioItem in this)
                {
                    if (toggledRadioItem != radioItem)
                    {
                        radioItem.PropertyChanged -= RadioItemToggled;
                        radioItem.Toggled = false;
                        radioItem.PropertyChanged += RadioItemToggled;
                    }
                }
            }

            busy = false;
        }
    }
}
