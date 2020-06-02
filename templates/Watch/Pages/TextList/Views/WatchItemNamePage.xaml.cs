using System;

using Xamarin.Forms;

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

        // Called once when an item is selected.
        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //  TODO: Insert code to handle a list item selected event.
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
