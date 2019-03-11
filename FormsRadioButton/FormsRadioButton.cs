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
        }

        void BuildList()
        {
            list = new ListView
            {
                SelectionMode = ListViewSelectionMode.None,
                SeparatorColor = Color.Transparent,
                ItemTemplate = new DataTemplate(typeof(SwitchCell))
            };

            list.ItemTemplate.SetBinding(SwitchCell.TextProperty, nameof(RadioItem.Text));
            list.ItemTemplate.SetBinding(SwitchCell.OnProperty, nameof(RadioItem.Toggled));
        }

        public static BindableProperty RadioItemsProperty =
            BindableProperty.Create(nameof(RadioItems), typeof(RadioItems), typeof(FormsRadioButton), null,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: (bindable, _, items) => ((FormsRadioButton)bindable).list.ItemsSource = (RadioItems)items);
           
        public RadioItems RadioItems
        {
            get => (RadioItems)GetValue(RadioItemsProperty);
            set => SetValue(RadioItemsProperty, value);
        }
    }
}
