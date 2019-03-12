using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using Xamarin.Forms;

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
                    radioItem.PropertyChanged += OnRadioItemToggled;
                }
            }

            if (e.OldItems != null)
            {
                foreach (RadioItem radioItem in e.OldItems)
                {
                    radioItem.PropertyChanged -= OnRadioItemToggled;
                }
            }
        }

        bool busy;
        int highestSelectedIndex;

        void OnRadioItemToggled(object sender, PropertyChangedEventArgs e)
        {
            if (busy) return;
            busy = true;

            if (sender is RadioItem toggledRadioItem)
            {
                highestSelectedIndex = IndexOf(toggledRadioItem) > highestSelectedIndex ? IndexOf(toggledRadioItem) : highestSelectedIndex;

                // I know which the highest selected index is, nothing can be togged after that so don't bother to loop any more than required.
                for (int i = 0; i < highestSelectedIndex + 1; i++)
                {
                    if (toggledRadioItem != this[i])
                    {
                        this[i].PropertyChanged -= OnRadioItemToggled;
                        this[i].Toggled = false;
                        this[i].PropertyChanged += OnRadioItemToggled;
                    }
                }

                highestSelectedIndex = IndexOf(toggledRadioItem) < highestSelectedIndex ? IndexOf(toggledRadioItem) : highestSelectedIndex;
                OnItemToggled(toggledRadioItem);
            }

            busy = false;
        }

        public event EventHandler ItemToggled;

        void OnItemToggled(RadioItem selectedItem)
        {
            ItemToggled?.Invoke(selectedItem, null);
        }
    }
}
