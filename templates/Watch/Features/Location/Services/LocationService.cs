using System;
using System.Threading.Tasks;
using Tizen.Location;

namespace Param_RootNamespace.Services
{
    /// <summary>
    /// Provides the functionalities for obtaining the geographical information.
    /// </summary>
    public partial class LocationService : IDisposable
    {
        // LocationService needs http://tizen.org/privilege/location which is a privacy-related privilege,
        // so the app has to request user to grant this permission using PrivacyPrivilegeManager.
        // For more details, see https://docs.tizen.org/application/dotnet/guides/security/requesting-permissions.

        private Locator _locator = null;

        private bool _started = false;

        private bool _disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationService"/> class.
        /// </summary>
        /// <param name="type">The back-end positioning method type.</param>
        public LocationService(LocationType type)
        {
            // NotSupportedException will be thrown if the given type is not supported
            _locator = new Locator(type);
            State = ServiceState.Disabled;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="LocationService"/> class.
        /// </summary>
        ~LocationService()
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets the state of the LocationService.
        /// </summary>
        public ServiceState State { get; private set; }

        /// <summary>
        /// Releases all resources used by the current instance.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases all resources used by the current instance.
        /// </summary>
        /// <param name="disposing">Indicates whether the method call comes from a Dispose method or from a finalizer.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                Stop();
                _locator.Dispose();
            }

            _disposed = true;
        }

        /// <summary>
        /// Requests a location update.
        /// This function is useful if you want to update the location information only once.
        /// </summary>
        /// <remarks>
        /// Don't use this function mixed with RequestUpdates().
        /// It is not allowed to use Locator.GetLocationAsync() mixed with Locator.Start().
        /// </remarks>
        /// <param name="timeout">Timeout to cancel the request (second)</param>
        /// <returns>The current location</returns>
        public async Task<Location> RequestSingleUpdateAsync(int timeout)
        {
            if (_started)
            {
                throw new InvalidOperationException(Resources.AppResources.ExceptionLocationServiceAlreadyStarted);
            }

            var location = await _locator.GetLocationAsync(timeout);
            return location;
        }

        /// <summary>
        /// Request location updates.
        /// </summary>
        /// <param name="interval">The minimum time interval between location updates (1 ~ 120 second)</param>
        public void RequestUpdates(int interval)
        {
            Stop();
            _locator.Interval = interval;
            _locator.LocationChanged += OnLocationChanged;
            Start();
        }

        /// <summary>
        /// Request location updates.
        /// </summary>
        /// <param name="distance">The minimum distance interval between location updates (1 ~ 120 mether)</param>
        /// <param name="interval">The minimum time interval between location updates (1 ~ 120 second)</param>
        public void RequestUpdates(int distance, int interval)
        {
            Stop();
            _locator.StayInterval = interval;
            _locator.Distance = distance;
            _locator.DistanceBasedLocationChanged += OnDistanceBasedLocationChanged;
            Start();
        }

        /// <summary>
        /// Stop location updates.
        /// </summary>
        public void Stop()
        {
            if (_started)
            {
                _locator.ServiceStateChanged -= OnServiceStateChanged;
                _locator.LocationChanged -= OnLocationChanged;
                _locator.DistanceBasedLocationChanged -= OnDistanceBasedLocationChanged;
                _locator.Stop();
                State = ServiceState.Disabled;
                _started = false;
            }
        }

        private void Start()
        {
            if (!_started)
            {
                _locator.ServiceStateChanged += OnServiceStateChanged;
                _locator.Start();
                _started = true;
            }
        }

        // This event is invoked when the state of location service is changed.
        private void OnServiceStateChanged(object sender, ServiceStateChangedEventArgs e)
        {
            State = e.ServiceState;

            // TODO: Insert code to handle this event.
            // After calling Start(), this event is also invoked with enabled state when the state of location service is changed to enabled.
            if (e.ServiceState == ServiceState.Enabled)
            {
                // If the state of location service is not enabled, the location from GetLocation() is not the current location but a previous location.
                Location location = _locator.GetLocation();
                Logger.Info($"Current location: {location.Latitude}, {location.Longitude}");
            }
            else
            {
                // TODO: Insert code to handle this state.
            }
        }

        private void OnLocationChanged(object sender, LocationChangedEventArgs e)
        {
            // TODO: Insert code to handle this event.
            Logger.Info($"Current location: {e.Location.Latitude}, {e.Location.Longitude}");
        }

        private void OnDistanceBasedLocationChanged(object sender, LocationChangedEventArgs e)
        {
            // TODO: Insert code to handle this event.
            Logger.Info($"Current location: {e.Location.Latitude}, {e.Location.Longitude}");
        }
    }
}
