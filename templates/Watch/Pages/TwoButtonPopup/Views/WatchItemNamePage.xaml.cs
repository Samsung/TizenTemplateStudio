﻿using System;

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

        private void OnTwoButtonPopupClicked(object sender, EventArgs e)
        {
            ShowTwoButtonPopup();
        }

        // TwoButtonPopup contains two buttons located at both ends.
        // The two buttons only display Icon.
        // Note that the text is not displayed even if the button's Text property is set.
        private void ShowTwoButtonPopup()
        {
            var twoButtonPopup = new TwoButtonPopup();

            twoButtonPopup.Title = AppResources.WatchItemNamePagePopupTitle;
            twoButtonPopup.Content = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    new Label
                    {
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        Text = AppResources.WatchItemNamePagePopupText
                    }
                }
            };

            twoButtonPopup.FirstButton = new MenuItem()
            {
                IconImageSource = new FileImageSource()
                {
                    File = "WatchItemNameCancel.png"
                },
                Command = new Command(() => {
                    twoButtonPopup?.Dismiss();
                    twoButtonPopup = null;
                })
            };
            twoButtonPopup.SecondButton = new MenuItem()
            {
                IconImageSource = new FileImageSource()
                {
                    File = "WatchItemNameCheck.png"
                }
            };

            twoButtonPopup.Show();
        }
    }
}
