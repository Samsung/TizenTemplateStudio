using System;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.TizenSpecific;

namespace Param_RootNamespace.Views
{
    // Define an alias for Tizen PlatformConfiguration.
    using Tizen = Xamarin.Forms.PlatformConfiguration.Tizen;

    public partial class WatchItemNamePage : ContentPage
    {
        public WatchItemNamePage()
        {
            InitializeComponent();

            // Only Tizen is supported to set the style in VisualElement(Button).
            // API Spec: https://docs.microsoft.com/en-us/dotnet/api/xamarin.forms.platformconfiguration.tizenspecific.buttonstyle?view=xamarin-forms
            BottomButton.On<Tizen>().SetStyle(ButtonStyle.Bottom);
        }
    }
}
