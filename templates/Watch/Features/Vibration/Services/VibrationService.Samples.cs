using System;

namespace Param_RootNamespace.Services
{
    // TODO: Remove these samples if it's not needed.
    // These samples show how to vibrate.

    public partial class VibrationService : IDisposable
    {
        /// <summary>
        /// Vibrates with custom pattern repeatedly.
        /// </summary>
        public void VibrateSample()
        {
            int[] durations = new int[6] { 1000, 300, 500, 300, 500, 1000 };
            int[] intensities = new int[6] { 50, -1, 100, -1, 0, 80 };
            Vibrate(durations, intensities, 0);
        }

        /// <summary>
        /// Vibrates with timer pattern only once.
        /// </summary>
        public void VibrateWithTimerPatternSample()
        {
            VibrateWithPredefinedPattern("Timer");
        }
    }
}
