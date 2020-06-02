using System;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.TizenSpecific;
using TizenSpecific = Xamarin.Forms.PlatformConfiguration.Tizen;

namespace Param_RootNamespace.Views
{
    public partial class WatchItemNamePage : ContentPage
    {
        // Supports a circular button that can contain image.
        // Note, Ignored even if text is set.
        public WatchItemNamePage()
        {
            InitializeComponent();

            // Only Tizen platform is supported to set the style in VisualElement(Button).
            // Sets the default display of the button to the circle style.
            // API Spec: https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.platformconfiguration.tizenspecific.buttonstyle?view=xamarin-forms
            denyButton.On<TizenSpecific>().SetStyle(ButtonStyle.Circle);
            confirmButton.On<TizenSpecific>().SetStyle(ButtonStyle.Circle);
        }

        // Called when the deny circle button is clicked.
        private void OnDenyButtonClicked(object sender, EventArgs e)
        {
            // TODO: Insert code to handle the circle button click.

        }

        // Called when the confirm circle button is clicked.
        private void OnConfirmButtonClicked(object sender, EventArgs e)
        {
            // TODO: Insert code to handle the circle button click.

        }
    }
}
