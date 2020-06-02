using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Tizen.System;

namespace Param_RootNamespace.Services
{
    /// <summary>
    /// Specifies the resources that need to be kept awake
    /// </summary>
    /// <remarks>
    /// These states are mutually exclusive
    /// </remarks>
    public enum PowerLockState
    {
        /// <summary>
        /// Prevents the CPU from falling asleep, but the display will be turned off
        /// </summary>
        CPU = PowerLock.Cpu,

        /// <summary>
        /// Prevents both the display and CPU from turning off
        /// </summary>
        Display = PowerLock.DisplayNormal,

        /// <summary>
        /// Prevents both the display and CPU from turning off, but the display may be dimmed
        /// </summary>
        DisplayDim = PowerLock.DisplayDim,
    }

    /// <summary>
    /// The PowerService provides a way to prevent the display and CPU from turning off
    /// This service has a significant impact on the device's battery life, hold the lock for as short a time as possible when really necessary
    /// More about controlling the power state at https://docs.tizen.org/application/dotnet/guides/device/attached-devices#controlling-the-power-state
    /// </summary>
    public partial class PowerService
    {
        /// <summary>
        /// Acquire the power lock and let the device stay on at the state requested
        /// </summary>
        /// <remarks>
        /// A value of 0 permanently holds the power lock
        /// </remarks>
        /// <param name="state">The power state</param>
        /// <param name="timeout">The time until the request times out, in milliseconds</param>
        public static void Request(PowerLockState state, int timeout = 0)
        {
            Power.RequestLock((PowerLock)state, timeout);
        }

        /// <summary>
        /// Release the power lock
        /// </summary>
        /// <param name="state">The power state</param>
        public static void Release(PowerLockState state)
        {
            Power.ReleaseLock((PowerLock)state);
        }
    }
}
