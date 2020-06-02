using System;
using Tizen.Applications;
using Param_RootNamespace.Mvvm;

namespace Param_RootNamespace.ViewModels
{
    public class WatchItemNameViewModel : BaseViewModel
    {
        private double _rotationHour;
        private double _rotationMinute;
        private double _rotationSecond;

        public WatchItemNameViewModel()
        {
            // Subscribe to the TimeTick event
            (Application.Current as WatchApplication).TimeTick += OnTimeChanged;
        }

        // Get or set the rotation of the hour hand about the Z-axis.
        public double RotationHour
        {
            set { Set(ref _rotationHour, value); }
            get { return _rotationHour; }
        }

        // Get or set the rotation of the minute hand about the Z-axis.
        public double RotationMinute
        {
            set { Set(ref _rotationMinute, value); }
            get { return _rotationMinute; }
        }

        // Get or set the rotation of the second hand about the Z-axis.
        public double RotationSecond
        {
            set { Set(ref _rotationSecond, value); }
            get { return _rotationSecond; }
        }

        // Update the rotation of the watch hands about the Z-axis.
        private void UpdateTime(WatchTime time)
        {
            RotationSecond = time.Second * 6.0;
            RotationMinute = time.Minute * 6.0 + time.Second / 10.0;
            RotationHour = (time.Hour % 12) * 30.0 + time.Minute / 2.0;
        }

        // Called at least once per second.
        private void OnTimeChanged(object sender, TimeEventArgs e)
        {
            UpdateTime(e.Time);
        }
    }
}
