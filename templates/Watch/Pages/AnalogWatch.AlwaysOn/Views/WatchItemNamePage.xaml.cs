﻿using System;
using System.Runtime.CompilerServices;

using Tizen.Applications;
using TApplication = Tizen.Applications.Application;
using Xamarin.Forms;

namespace Param_RootNamespace.Views
{
    public partial class WatchItemNamePage : ContentPage
    {
        private bool _ambientDisabled;
        private double _rotationHour;
        private double _rotationMinute;
        private double _rotationSecond;

        public WatchItemNamePage()
        {
            InitializeComponent();
            AmbientDisabled = true;
            BindingContext = this;

            var WatchFace = TApplication.Current as WatchApplication;

            // Subscribe to the TimeTick event
            WatchFace.TimeTick += OnTimeChanged;

            // Subscribe to the AmbientTick event
            WatchFace.AmbientTick += OnTimeChanged;

            // Subscribe to the AmbientChanged event
            WatchFace.AmbientChanged += OnAmbientChanged;
        }

        // Get or set if ambient mode is disabled.
        public bool AmbientDisabled
        {
            get { return _ambientDisabled; }
            set { Set(ref _ambientDisabled, value); }
        }

        // Get or set the rotation of the hour hand about the Z-axis.
        public double RotationHour
        {
            get { return _rotationHour; }
            set { Set(ref _rotationHour, value); }
        }

        // Get or set the rotation of the minute hand about the Z-axis.
        public double RotationMinute
        {
            get { return _rotationMinute; }
            set { Set(ref _rotationMinute, value); }
        }

        // Get or set the rotation of the second hand about the Z-axis.
        public double RotationSecond
        {
            get { return _rotationSecond; }
            set { Set(ref _rotationSecond, value); }
        }

        // Update the rotation of the watch hands about the Z-axis.
        private void UpdateTime(WatchTime time)
        {
            RotationSecond = time.Second * 6.0;
            RotationMinute = (time.Minute * 6.0) + (time.Second / 10.0);
            RotationHour = ((time.Hour % 12) * 30.0) + (time.Minute / 2.0);
        }

        // Called at least once per second when ambient mode is disabled.
        // Called every ambient tick when ambient mode is enabled.
        private void OnTimeChanged(object sender, TimeEventArgs e)
        {
            UpdateTime(e.Time);
        }

        // Called when ambient mode state is changed.
        private void OnAmbientChanged(object sender, AmbientEventArgs e)
        {
            AmbientDisabled = !e.Enabled;
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
