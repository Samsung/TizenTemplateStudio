using System;

using Xamarin.Forms;

namespace Param_RootNamespace.Views
{
    public partial class WatchItemNamePage : ContentPage
    {
        public WatchItemNamePage()
        {
            InitializeComponent();
        }

        // Called when the plus button is clicked.
        private void OnPlusButtonClicked(object sender, EventArgs args)
        {
            // TODO: Insert code to handle the CircleProgressBarSurfaceItem.
            if (progressBar.Value < 1)
            {
                progressBar.Value += 0.01;
            }
        }

        // Called when the minus button is clicked.
        private void OnMinusButtonClicked(object sender, EventArgs args)
        {
            // TODO: Insert code to handle the CircleProgressBarSurfaceItem.
            if (progressBar.Value > 0)
            {
                progressBar.Value -= 0.01;
            }
        }
    }
}
