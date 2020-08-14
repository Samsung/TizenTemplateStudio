using System;
using System.Windows.Input;

using Xamarin.Forms;
using Tizen.Wearable.CircularUI.Forms;

using Param_RootNamespace.Mvvm;
using Param_RootNamespace.Resources;

namespace Param_RootNamespace.ViewModels
{
    public partial class WatchItemNameViewModel : BaseViewModel
    {
        public WatchItemNameViewModel()
        {
            ClickToastCommand = new Command(() => ClickToast());
            ClickToastWithDelayCommand = new Command(() => ClickToastWithDelay());
            ClickToastWithIconCommand = new Command(() => ClickToastWithIcon());
        }

        public ICommand ClickToastCommand { get; private set; }
        public ICommand ClickToastWithDelayCommand { get; private set; }
        public ICommand ClickToastWithIconCommand { get; private set; }

        // Toast automatically expires after 2 seconds.
        // Users can tap the screen to close a toast before it disappears automatically.
        private void ClickToast()
        {
            Toast.DisplayText(string.Format(AppResources.WatchItemNamePageToastMessage, 2));
        }

        // Toast will automatically disappear after the time set in delay.
        private void ClickToastWithDelay()
        {
            Toast.DisplayText(string.Format(AppResources.WatchItemNamePageToastMessage, 5), 5000);
        }

        // Displays toast containing an Icon and a text.
        private void ClickToastWithIcon()
        {
            Toast.DisplayIconText(string.Format(AppResources.WatchItemNamePageToastMessage, 2), new FileImageSource { File = "WatchItemNameSample.png" });
        }
    }
}
