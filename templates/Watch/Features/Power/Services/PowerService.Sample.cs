using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Param_RootNamespace.Services
{
    public partial class PowerService
    {
        public static async Task KeepScreenOnSampleAsync()
        {
            // Request a power lock that keeps the screen on
            // Note that the lock will be released automatically after the given timeout expires
            PowerService.Request(PowerLockState.Display, 10 * 1000);

            await Task.Delay(5 * 1000);

            // Release the lock after 5 seconds
            PowerService.Release(PowerLockState.Display);
        }
    }
}
