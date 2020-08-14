using System;
using System.Windows.Input;

using Xamarin.Forms;
using Tizen.Wearable.CircularUI.Forms;

using Param_RootNamespace.Mvvm;

namespace Param_RootNamespace.ViewModels
{
    public partial class WatchItemNameViewModel : BaseViewModel
    {
        public WatchItemNameViewModel()
        {
            ClickButtonCommand = new Command(() => ClickButton());
        }

        public ICommand ClickButtonCommand { get; private set; }

        public IMapViewPage MapViewPage { set; get; }

        public void UpdateLocation()
        {
            // Sets the latitude and longitude.
            var location = new LatLng(40.7157961, -74.0252194);

            var option = new GoogleMapOption
            {
                Center = location,
                Zoom = 12,
            };

            MapViewPage.UpdateLocation(option);
        }

        public void AddMarkers()
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

            MapViewPage.AddMarker(marker1);
            MapViewPage.AddMarker(marker2);
            MapViewPage.AddMarker(marker3);
        }

        private void ClickButton()
        {
            UpdateLocation();
            AddMarkers();
        }
    }
}
