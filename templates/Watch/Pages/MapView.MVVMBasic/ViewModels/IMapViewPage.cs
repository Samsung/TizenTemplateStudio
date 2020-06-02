using System;

using Tizen.Wearable.CircularUI.Forms;

namespace Param_RootNamespace.ViewModels
{
    public interface IMapViewPage
    {
        void UpdateLocation(GoogleMapOption googleMapOption);

        void AddMarker(Marker marker);
    }
}
