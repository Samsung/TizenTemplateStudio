using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Param_RootNamespace.Services;

namespace Param_RootNamespace.Services
{
    public static partial class SharedStorageService
    {
        public static async Task WriteFileToSharedStorageSampleAsync()
        {
            // Ask the user to grant the privacy permissions at runtime
            var permission = await PrivacyPermissionService.RequestAsync(PrivacyPrivilege.MediaStorage);

            if (permission != PrivacyPermissionStatus.Granted)
            {
                // The permission is not granted
                return;
            }

            if (SharedStorageService.Writable)
            {
                // Store a file in public directory so that other apps can access the file
                var directory = SharedStorageService.GetDirectory(Tizen.System.DirectoryType.Downloads);
                var path = Path.Combine(directory, "sample.txt");
                File.WriteAllText(path, "Hello World!");
            }
        }
    }
}
