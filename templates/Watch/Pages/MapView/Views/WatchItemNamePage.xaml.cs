using System;

using Xamarin.Forms;
using Tizen.Wearable.CircularUI.Forms;

namespace Param_RootNamespace.Views
{
    public partial class WatchItemNamePage : ContentPage
    {
        public WatchItemNamePage()
        {
            // TODO: The api key must be set before the GoogleMapView is initialized.
            // UpdateApiKey("API_KEY");

            InitializeComponent();

            UpdateLocation();
            AddMarkers();
        }

        // The map is moved to the location it sets.
        private void UpdateLocation()
        {
            // Sets the latitude and longitude.
            var location = new LatLng(40.7157961, -74.0252194);

            var option = new GoogleMapOption
            {
                Center = location,
                Zoom = 12,
            };
            mapview.Update(option);
        }

        // Add markers to be displayed on the map.
        private void AddMarkers()
        {
            var marker1 = new Marker
            {
                Position = new LatLng(40.711493, -74.011351),
                Description = "Westfield World Trade Center",
                Address = "185 Greenwich St, New York, NY 10007",
            };

            var marker2 = new Marker
            {
                Position = new LatLng(40.689651, -74.045412),
                Description = "Statue of Liberty National Monument",
                Address = "New York, NY 10004",
            };

            var marker3 = new Marker
            {
                Position = new LatLng(40.748368, -73.985560),
                Description = "Empire State Building",
                Address = "20 W 34th St, New York, NY 10001",
            };

            mapview.Markers.Add(marker1);
            mapview.Markers.Add(marker2);
            mapview.Markers.Add(marker3);
        }

        // Insert your google map api key.
        private void UpdateApiKey(string apiKey)
        {
            Tizen.Wearable.CircularUI.Forms.FormsCircularUI.Init(apiKey);
        }
    }
}
