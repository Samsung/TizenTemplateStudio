using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tizen.System;

namespace Param_RootNamespace.Services
{
    /// <summary>
    /// For more information about using the Battery API, see https://docs.tizen.org/application/dotnet/guides/device/attached-devices#retrieving-battery-information
    /// </summary>
    public class BatteryService
    {
        /// <summary>
        /// Initializes the battery service to monitor the battery level and charging state
        /// </summary>
        public BatteryService()
        {
            Battery.PercentChanged += OnBatteryPercentChanged;
            Battery.LevelChanged += OnBatteryLevelChanged;
            Battery.ChargingStateChanged += OnBatteryChargingStateChanged;
        }

        private void OnBatteryPercentChanged(object sender, BatteryPercentChangedEventArgs e)
        {
            // TODO: Insert code to handle changes in battery level
            // Note that battery level is scaled to a value between 0 and 100
        }

        private void OnBatteryLevelChanged(object sender, BatteryLevelChangedEventArgs e)
        {
            // TODO: Insert code to handle significant changes in battery level

            switch (e.Level)
            {
                // The battery goes empty and the device starts to shut down, stop all work immediately
                case BatteryLevelStatus.Empty:
                    break;

                // The battery is critically low, the battery intensive operation like handling media files may not work correctly
                case BatteryLevelStatus.Critical:
                    break;

                // The battery is low, adjust battery-related operations and resources
                case BatteryLevelStatus.Low:
                    break;

                // The battery is sufficiently charged
                case BatteryLevelStatus.High:
                    break;
            }
        }

        private void OnBatteryChargingStateChanged(object sender, BatteryChargingStateChangedEventArgs e)
        {
            // TODO: Insert code to handle the charging state changes
        }
    }
}
