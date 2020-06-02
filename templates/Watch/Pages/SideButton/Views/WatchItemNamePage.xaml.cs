using System;

using Xamarin.Forms;
using Tizen.Wearable.CircularUI.Forms;

namespace Param_RootNamespace.Views
{
    // This page supports FirstButton and SecondButton.
    // The buttons are in MenuItem type.
    // More details about MenuItem can be found at https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.menuitem?view=xamarin-forms

    // The image set in the IconImageSourceProperty is displayed in the button.
    // Note, text is ignored even when set.

    public partial class WatchItemNamePage : TwoButtonPage
    {
        public WatchItemNamePage()
        {
            InitializeComponent();
        }

        // When the FirstButton is clicked, the command below is invoked.
        public Command ClickFirstButtonCommand => new Command(() =>
        {
            // TODO: Insert code to handle the first button click.
        });

        // When the SecondButton is clicked, the command below is invoked.
        public Command ClickSecondButtonCommand => new Command(() =>
        {
            // TODO: Insert code to handle the second button click.
        });
    }
}
