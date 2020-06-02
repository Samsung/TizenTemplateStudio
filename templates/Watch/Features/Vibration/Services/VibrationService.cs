using System;
using System.Timers;
using Tizen.System;

namespace Param_RootNamespace.Services
{
    /// <summary>
    /// Provides the ability to control a vibration.
    /// </summary>
    public partial class VibrationService : IDisposable
    {
        private Feedback _feedback = null;

        private Vibrator _vibrator = null;

        private VibratorTimer _vibratorTimer = null;

        private bool _disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="VibrationService"/> class.
        /// </summary>
        public VibrationService()
        {
            try
            {
                _feedback = new Feedback();
            }
            catch (NotSupportedException)
            {
                // This exception is not handled here,
                // instead NotSupportedException will be thrown by VibrateWithPredefinedPattern().
            }

            if (Vibrator.NumberOfVibrators > 0)
            {
                _vibrator = Vibrator.Vibrators[0];
            }
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="VibrationService"/> class.
        /// </summary>
        ~VibrationService()
        {
            Dispose(false);
        }

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
                if (_vibrator != null)
                {
                    _vibrator.Dispose();
                }

                if (_vibratorTimer != null)
                {
                    _vibratorTimer.Stop();
                    _vibratorTimer.Elapsed -= OnTimedEvent;
                    _vibratorTimer.IsValid = false;
                    _vibratorTimer.Dispose();
                }
            }

            _disposed = true;
        }

        /// <summary>
        /// Vibrates for the specified duration of time.
        /// </summary>
        /// <remarks>
        /// You may need to turn off vibration when your app is paused.
        /// </remarks>
        /// <param name="duration">The number of milliseconds to vibrate.</param>
        /// <param name="intensity">The amount of the intensity variation (0 ~ 100). There will be no vibration if intensity < 0.</param>
        public void Vibrate(int duration, int intensity)
        {
            if (_vibrator == null)
            {
                throw new NotSupportedException(Resources.AppResources.ExceptionVibrationServiceNotSupported);
            }

            StopPredifendPattern();

            if (intensity >= 0)
            {
                _vibrator.Vibrate(duration, intensity);
            }
        }

        /// <summary>
        /// Vibrates with a given pattern.
        /// </summary>
        /// <remarks>
        /// You may need to turn off vibration when your app is paused.
        /// </remarks>
        /// <param name="durations">
        /// The duration values of the duration and intensity pairs. A duration is the number of milliseconds to vibrate.
        /// </param>
        /// <param name="intensities">
        /// The intensity values of the duration and intensity pairs.
        /// A intensity is the amount of intensity variation (0 ~ 100). There will be no vibration for the duration of time if intensity < 0.
        /// </param>
        /// <param name="repeat">The index at which to repeat. There will be no repetition if repeat < 0.</param>
        public void Vibrate(int[] durations, int[] intensities, int repeat)
        {
            if (durations == null)
            {
                throw new ArgumentNullException(nameof(durations));
            }

            if (intensities == null)
            {
                throw new ArgumentNullException(nameof(intensities));
            }

            if (durations.Length < 1 || durations.Length <= repeat || durations.Length > intensities.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(durations));
            }

            if (intensities.Length < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(intensities));
            }

            if (_vibratorTimer != null)
            {
                Stop();
            }

            Vibrate(durations[0], intensities[0]);
            if (durations.Length > 1)
            {
                _vibratorTimer = new VibratorTimer
                {
                    Interval = durations[0],
                    Durations = (int[])durations.Clone(),
                    Intensities = (int[])intensities.Clone(),
                    Repeat = repeat,
                    CurrentIndex = 1,
                    IsValid = true,
                    AutoReset = false,
                    Enabled = true,
                };
                _vibratorTimer.Elapsed += OnTimedEvent;
                _vibratorTimer.Start();
            }
        }

        /// <summary>
        /// Vibrates with the predefined pattern only one time.
        /// </summary>
        /// <remarks>
        /// You may need to turn off vibration when your app is paused.
        /// </remarks>
        /// <param name="pattern">
        /// The predefined pattern such as "Timer" and "WakeUp" and so on. You can find the supported patterns in https://samsung.github.io/TizenFX/stable/api/Tizen.System.Feedback.html.
        /// </param>
        public void VibrateWithPredefinedPattern(string pattern)
        {
            if (_feedback == null)
            {
                throw new NotSupportedException(Resources.AppResources.ExceptionVibrationServicePredefinedNotSupported);
            }

            Stop();

            // If the pattern is not supported, then NotSupportedException will be thrown.
            // You can check whether a pattern is supported by Feedback.IsSupportedPattern().
            _feedback.Play(FeedbackType.Vibration, pattern);
        }

        /// <summary>
        /// Turns off the vibration.
        /// </summary>
        /// <remarks>
        /// You may need to turn off vibration when your app is paused.
        /// </remarks>
        public void Stop()
        {
            if (_vibrator != null)
            {
                _vibrator.Stop();
                if (_vibratorTimer != null)
                {
                    _vibratorTimer.Stop();
                    _vibratorTimer.IsValid = false;
                    _vibratorTimer.Elapsed -= OnTimedEvent;
                    _vibratorTimer.Dispose();
                    _vibratorTimer = null;
                }
            }
        }

        /// <summary>
        /// Turns off the predefined pattern.
        /// </summary>
        /// <remarks>
        /// You may need to turn off vibration when your app is paused.
        /// </remarks>
        public void StopPredifendPattern()
        {
            if (_feedback != null)
            {
                _feedback.Stop();
            }
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            VibratorTimer timer = (VibratorTimer)source;
            if (!timer.IsValid)
            {
                return;
            }

            int index = timer.CurrentIndex;
            if (index == timer.Durations.Length && timer.Repeat >= 0)
            {
                index = timer.Repeat;
            }

            if (index < timer.Durations.Length)
            {
                Vibrate(_vibratorTimer.Durations[index], _vibratorTimer.Intensities[index]);
                _vibratorTimer.Interval = _vibratorTimer.Durations[index];
                _vibratorTimer.CurrentIndex = index + 1;
                _vibratorTimer.Start();
            }
            else
            {
                Stop();
            }
        }

        private class VibratorTimer : Timer
        {
            /// <summary>
            /// Gets or sets the duration values of the duration and intensity pairs.
            /// A duration is the number of milliseconds to vibrate.
            /// </summary>
            public int[] Durations { get; set; }

            /// <summary>
            /// Gets or sets the intensity values of the duration and intensity pairs.
            /// </summary>
            public int[] Intensities { get; set; }

            /// <summary>
            /// Gets or sets the index at which to repeat.
            /// There will be no repetition if repeat < 0.
            /// </summary>
            public int Repeat { get; set; }

            /// <summary>
            /// Gets or sets the index at which to vibrate.
            /// </summary>
            public int CurrentIndex { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether the event handler for the Elapsed event to ignore subsequent events.
            /// </summary>
            public bool IsValid { get; set; }
        }
    }
}
