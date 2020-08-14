using System;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.TizenSpecific;

namespace Param_RootNamespace.Views
{
    // Define an alias for Tizen PlatformConfiguration.
    using Tizen = Xamarin.Forms.PlatformConfiguration.Tizen;

    /// <summary>
    /// Xamarin.Forms Entry is used for single-line text input. Entry supports various keyboard types.
    /// For more details, see https://docs.microsoft.com/xamarin/xamarin-forms/user-interface/text/entry.
    /// </summary>
    public partial class WatchItemNamePage : ContentPage
    {
        public WatchItemNamePage()
        {
            InitializeComponent();

            // Only Tizen is supported to set the style in VisualElement(Button).
            // API Spec: https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.platformconfiguration.tizenspecific.buttonstyle?view=xamarin-forms
            BottomButton.On<Tizen>().SetStyle(ButtonStyle.Bottom);
        }

        // Called when the user finalizes the text in an entry with the return key.
        private void OnEntryCompleted(object sender, EventArgs e)
        {
            // TODO: Insert code to handle the Completed event.
            //
            // var text = ((Xamarin.Forms.Entry)sender).Text;
        }

        // Called when the bottom button is clicked.
        private void OnBottomButtonClicked(object sender, EventArgs e)
        {
            // TODO: Insert code to handle the bottom button click.
            //
            // var phoneNumber = PhoneNumber.Text;
        }
    }
}
