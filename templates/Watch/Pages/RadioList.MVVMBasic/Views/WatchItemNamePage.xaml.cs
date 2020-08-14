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
        }

        // Called when the radio cell is changed.
        private void OnRadioChanged(object sender, CheckedChangedEventArgs e)
        {
            // TODO: Insert code to handle a list radio changed event.

            // RadioCell is only supported by CircularUI.
            // var radioCell = (RadioCell)sender;
            // Logger.Info($"{radioCell.Text}'s radio is {e.Value}");
        }
    }
}
