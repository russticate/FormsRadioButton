using System;
using Xamarin.Forms;

namespace FormsRadioButton
{
    public class FormsRadioButton : ContentView
    {
        ListView list;

        public FormsRadioButton()
        {
            BuildList();
            Content = list;
            list.BindingContextChanged += OnListBindingContextChanged;          
        }
  
        private void OnListBindingContextChanged(object sender, EventArgs e)
        {
            list.BindingContextChanged -= OnListBindingContextChanged;
            var radioItems = ((ListView)sender).ItemsSource as RadioItems;
            radioItems.ItemToggled += (radioItem, _) => OnItemToggled(radioItem as RadioItem);
        }

        void BuildList()
        {
            list = new ListView
            {
                SelectionMode = ListViewSelectionMode.None,
                SeparatorColor = Color.Transparent,
                ItemTemplate = new DataTemplate(typeof(SwitchCell))
            };

            list.SetBinding(ListView.ItemsSourceProperty, new Binding(nameof(RadioItems)));
            list.ItemTemplate.SetBinding(SwitchCell.TextProperty, nameof(RadioItem.Text));
            list.ItemTemplate.SetBinding(SwitchCell.OnProperty, nameof(RadioItem.Toggled));
        }

        public static BindableProperty RadioItemsProperty =
            BindableProperty.Create(nameof(RadioItems), typeof(RadioItems), typeof(FormsRadioButton));
           
        public RadioItems RadioItems
        {
            get => (RadioItems)GetValue(RadioItemsProperty);
            set => SetValue(RadioItemsProperty, value);
        }

        public event EventHandler<RadioItemToggledEventArgs> ItemToggled;

        void OnItemToggled(RadioItem selectedRadioItem)
        {
            ItemToggled?.Invoke(this, new RadioItemToggledEventArgs(selectedRadioItem));
        }
    }
}
