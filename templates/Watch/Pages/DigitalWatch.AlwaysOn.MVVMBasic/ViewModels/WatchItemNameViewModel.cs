using System;
using Tizen.Applications;
using Param_RootNamespace.Mvvm;

namespace Param_RootNamespace.ViewModels
{
    public class WatchItemNameViewModel : BaseViewModel
    {
        private DateTime _time;
        private string _timeString;
        private bool _ambientEnabled;

        public WatchItemNameViewModel()
        {
            _ambientEnabled = false;

            var WatchFace = Application.Current as WatchApplication;

            // Subscribe to the TimeTick event
            WatchFace.TimeTick += OnTimeChanged;

            // Subscribe to the AmbientTick event
            WatchFace.AmbientTick += OnTimeChanged;

            // Subscribe to the AmbientChanged event
            WatchFace.AmbientChanged += OnAmbientChanged;
        }

        // Get or set time to be displayed.
        public string TimeString
        {
            get { return _timeString; }
            set { Set(ref _timeString, value); }
        }

        // Update time to be displayed.
        private void UpdateTime()
        {
            if (_ambientEnabled)
            {
                TimeString = _time.ToString("HH:mm");
            }
            else
            {
                TimeString = _time.ToString("HH:mm:ss");
            }
        }

        // Called at least once per second when ambient mode is disabled.
        // Called every ambient tick when ambient mode is enabled.
        private void OnTimeChanged(object sender, TimeEventArgs e)
        {
            _time = e.Time.UtcTimestamp;
            UpdateTime();
        }

        // Called when ambient mode state is changed.
        private void OnAmbientChanged(object sender, AmbientEventArgs e)
        {
            _ambientEnabled = e.Enabled;
            UpdateTime();
        }
    }
}
