using System;
using System.Runtime.InteropServices;

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
        CPU = 0,

        /// <summary>
        /// Prevents both the display and CPU from turning off
        /// </summary>
        Display,

        /// <summary>
        /// Prevents both the display and CPU from turning off, but the display may be dimmed
        /// </summary>
        DisplayDim,
    }

    /// <summary>
    /// The PowerService provides a way to prevent the display and CPU from turning off
    /// This service has a significant impact on the device's battery life, hold the lock for as short a time as possible when really necessary
    /// More about controlling the power state at https://docs.tizen.org/application/dotnet/guides/device/attached-devices#controlling-the-power-state
    /// </summary>
    public static partial class PowerService
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
            _ = NativeMethods.DevicePowerRequestLock((int)state, timeout);
        }

        /// <summary>
        /// Release the power lock
        /// </summary>
        /// <param name="state">The power state</param>
        public static void Release(PowerLockState state)
        {
            _ = NativeMethods.DevicePowerReleaseLock((int)state);
        }
    }

    internal static partial class NativeMethods
    {
        [DllImport("libcapi-system-device.so.0", EntryPoint = "device_power_request_lock", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DevicePowerRequestLock(int type, int timeout_ms);

        [DllImport("libcapi-system-device.so.0", EntryPoint = "device_power_release_lock", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DevicePowerReleaseLock(int type);
    }
}
