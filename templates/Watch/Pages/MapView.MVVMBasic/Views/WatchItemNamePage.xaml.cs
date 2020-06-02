using System;

using Tizen.Wearable.CircularUI.Forms;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.TizenSpecific;

using Param_RootNamespace.ViewModels;

namespace Param_RootNamespace.Views
{
    public partial class WatchItemNamePage : ContentPage, IMapViewPage
    {
        public WatchItemNamePage()
        {
            // TODO: The api key must be set before the GoogleMapView is initialized.
            // UpdateApiKey("API_KEY");

            InitializeComponent();
            (BindingContext as WatchItemNameViewModel).MapViewPage = this as IMapViewPage;

            bottomButton.On<Xamarin.Forms.PlatformConfiguration.Tizen>().SetStyle(ButtonStyle.Bottom);
        }

        // The map is moved to the location it sets.
        public void UpdateLocation(GoogleMapOption googleMapOption)
        {
            mapview.Update(googleMapOption);
        }

        // Add markers to be displayed on the map.
        public void AddMarker(Marker marker)
        {
            mapview.Markers.Add(marker);
        }

        // Insert your google map api key.
        private void UpdateApiKey(string apiKey)
        {
            Tizen.Wearable.CircularUI.Forms.FormsCircularUI.Init(apiKey);
        }
    }
}
