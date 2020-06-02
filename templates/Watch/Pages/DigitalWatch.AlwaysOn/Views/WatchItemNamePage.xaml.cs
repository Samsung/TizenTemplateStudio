using System;
using System.Runtime.CompilerServices;

using Tizen.Applications;
using TApplication = Tizen.Applications.Application;
using Xamarin.Forms;

namespace Param_RootNamespace.Views
{
    public partial class WatchItemNamePage : ContentPage
    {
        private DateTime _time;
        private string _timeString;
        private bool _ambientEnabled;

        public WatchItemNamePage()
        {
            InitializeComponent();
            _ambientEnabled = false;
            BindingContext = this;

            var WatchFace = TApplication.Current as WatchApplication;

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

        private bool Set<T>(ref T property, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(property, value))
            {
                return false;
            }

            property = value;
            OnPropertyChanged(propertyName);

            return true;
        }
    }
}
