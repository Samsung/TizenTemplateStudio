using System;

using Xamarin.Forms;

using Tizen.Wearable.CircularUI.Forms;

using Param_RootNamespace.Services;

namespace Param_RootNamespace.Views
{
    public partial class WatchItemNamePage : ContentPage
    {
        public WatchItemNamePage()
        {
            InitializeComponent();

            // Initialize sample data and set ItemsSource in ListView.
            // TODO: Change ItemsSource with your own data.
            listView.ItemsSource = SampleDataService.AllColors();
        }

        // Called when the switch is changed by a click.
        private void OnSwitchChanged(object sender, ToggledEventArgs e)
        {
            // TODO: Insert code to handle the item's switch.

            // Gets the bound item using switch's BindingContext and the switch state.
            // var switchCell = (SwitchCell)sender;
            // Logger.Info($"Item : {switchCell.BindingContext}");
            // Logger.Info($"Switch set : {e.Value});
        }

        // Called once when an item is selected.
        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // TODO: Insert code to handle a list item selected event.
            // Logger.Info($"Selected Color : {e.SelectedItem}");
        }

        // Called every time an item is tapped.
        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            // TODO: Insert code to handle a list item tapped event.
            // Logger.Info($"Tapped Color : {e.Item}");
        }
    }
}
