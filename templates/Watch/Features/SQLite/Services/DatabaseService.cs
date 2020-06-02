using System.IO;
using Tizen.Applications;
using SQLite;

namespace Param_RootNamespace.Services
{
    /// <summary>
    /// Provides a connection for SQLite database.
    /// </summary>
    /// <remarks>
    /// This DatabaseService uses the SQLite-net and the SQLitePCLRaw packages.
    /// For more details see https://github.com/praeclarum/sqlite-net and https://github.com/ericsink/SQLitePCL.raw.
    /// </remarks>
    public static class DatabaseService
    {
        private const string DefaultDBName = "appdata";
        private const string DBFileExtension = ".db3";
        private static bool _initialized = false;

        /// <summary>
        /// Creates a new SQLite connection and opens a SQLite database specified by given name.
        /// </summary>
        /// <param name="dbname">Specifies the name to the database file. Default name is 'appdata'.</param>
        /// <returns>The connection object</returns>
        public static SQLiteConnection NewConnection(string dbname = DefaultDBName)
        {
            EnsureInitProvider();
            // Database file will be located in the application data directory.
            string dbfile = Path.Combine(Application.Current.DirectoryInfo.Data, dbname) + DBFileExtension;
            return new SQLiteConnection(dbfile);
        }

        private static void EnsureInitProvider()
        {
            if (!_initialized)
            {
                // The provider 'SQLite3Provider_sqlite3' uses libsqlite3.so installed in target system.
                SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_sqlite3());
                SQLitePCL.raw.FreezeProvider(true);
                _initialized = true;
            }
        }
    }
}
