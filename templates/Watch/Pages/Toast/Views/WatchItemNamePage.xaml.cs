using System;

using Xamarin.Forms;
using Tizen.Wearable.CircularUI.Forms;

using Param_RootNamespace.Resources;

namespace Param_RootNamespace.Views
{
    public partial class WatchItemNamePage : ContentPage
    {
        public WatchItemNamePage()
        {
            InitializeComponent();
        }

        // Toast automatically expires after 2 seconds.
        // Users can tap the screen to close a toast before it disappears automatically.
        private void OnToastClicked(object sender, EventArgs e)
        {
            Toast.DisplayText(string.Format(AppResources.WatchItemNamePageToastMessage, 2));
        }

        // Toast will automatically disappear after the time set in delay.
        private void OnToastWithDelayClicked(object sender, EventArgs e)
        {
            Toast.DisplayText(string.Format(AppResources.WatchItemNamePageToastMessage, 5), 5000);
        }

        // Displays toast containing an Icon and a text.
        private void OnToastWithIconClicked(object sender, EventArgs e)
        {
            Toast.DisplayIconText(string.Format(AppResources.WatchItemNamePageToastMessage, 2), new FileImageSource { File = "WatchItemNameSample.png" });
        }
    }
}
