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

        private void OnInformationPopupClicked(object sender, EventArgs e)
        {
            ShowInformationPopup();
        }

        // InformationPopup contains a text and a bottom button.
        // Note that if text and icon are set to at the same time on the bottom button, they are overlaid.
        private void ShowInformationPopup()
        {
            var informationPopup = new InformationPopup()
            {
                Text = AppResources.WatchItemNamePagePopupText,
                IsProgressRunning = true
            };


            informationPopup.BackButtonPressed += (s, e) =>
            {
                informationPopup.Dismiss();
                informationPopup = null;
            };

            informationPopup.BottomButton = new MenuItem()
            {
                Text = AppResources.WatchItemNamePageOkButtonText,
                Command = new Command(() =>
                {
                    informationPopup?.Dismiss();
                    informationPopup = null;
                })
            };

            informationPopup.Show();
        }
    }
}
