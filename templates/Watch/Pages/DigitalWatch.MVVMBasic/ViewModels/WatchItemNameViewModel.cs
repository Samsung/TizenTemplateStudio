using System;
using Tizen.Applications;
using Param_RootNamespace.Mvvm;

namespace Param_RootNamespace.ViewModels
{
    public class WatchItemNameViewModel : BaseViewModel
    {
        private DateTime _time;
        private string _timeString;

        public WatchItemNameViewModel()
        {
            // Subscribe to the TimeTick event
            (Application.Current as WatchApplication).TimeTick += OnTimeChanged;
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
            TimeString = _time.ToString("HH:mm:ss");
        }

        // Called at least once per second.
        private void OnTimeChanged(object sender, TimeEventArgs e)
        {
            _time = e.Time.UtcTimestamp;
            UpdateTime();
        }
    }
}
