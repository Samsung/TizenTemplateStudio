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

        public WatchItemNamePage()
        {
            InitializeComponent();
            BindingContext = this;

            // Subscribe to the TimeTick event
            (TApplication.Current as WatchApplication).TimeTick += OnTimeChanged;
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
