using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Tizen.System;

namespace Param_RootNamespace.Services
{
    /// <summary>
    /// Provides a wrapper for examining shared storage.
    /// </summary>
    public static partial class SharedStorageService
    {
        private static readonly Lazy<Storage> _storage = new Lazy<Storage>(() => FindStorage());

        /// <summary>
        /// Gets the primary shared storage
        /// </summary>
        public static Storage Storage
        {
            get
            {
                return _storage.Value;
            }
        }

        /// <summary>
        /// Gets a value that indicates whether the storage can be read
        /// </summary>
        public static bool Readable
        {
            get
            {
                return (Storage != null) && (Storage.State == StorageState.Mounted || Storage.State == StorageState.MountedReadOnly);
            }
        }

        /// <summary>
        /// Gets a value that indicates whether the storage is writable
        /// </summary>
        public static bool Writable
        {
            get
            {
                return (Storage != null) && (Storage.State == StorageState.Mounted);
            }
        }

        /// <summary>
        /// Returns the absolute path for the specified directory
        /// </summary>
        /// <param name="directory">The directory for which to obtain absolute path</param>
        /// <returns>The absolute path of the directory</returns>
        public static string GetDirectory(DirectoryType directory)
        {
            return (Storage != null) ? Storage.GetAbsolutePath(directory) : null;
        }

        private static Storage FindStorage()
        {
            Storage storage = null;

            foreach (var found in StorageManager.Storages)
            {
                storage = found;

                // In a watch, use internal storage by default
                if (found.StorageType == StorageArea.Internal)
                {
                    break;
                }
            }

            return storage;
        }
    }
}
