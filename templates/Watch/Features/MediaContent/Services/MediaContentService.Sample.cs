using System;
using System.Threading.Tasks;
using Tizen.Content.MediaContent;

namespace Param_RootNamespace.Services
{
    public static class MediaContentService
    {
        /// <summary>
        /// This is a sample to demonstrate how to query the media database to retrieve media content
        /// For more information about media content, see https://docs.tizen.org/application/dotnet/guides/multimedia/media-content
        /// </summary>
        public static async Task AccessMediaContentSampleAsync()
        {
            // Ask the user for the permission
            PrivacyPermissionStatus permission = await PrivacyPermissionService.RequestAsync(PrivacyPrivilege.MediaStorage);

            if (permission != PrivacyPermissionStatus.Granted)
            {
                // TODO: The permission is not granted
                return;
            }

            using (var database = new MediaDatabase())
            {
                try
                {
                    // Establish a connection to the media database.
                    database.Connect();

                    // Note that the system automactically scans storage and adds media files to the database.
                    // To request the system to scan a directory explicitly, use MediaDatabase.ScanFolderAsync()
                    // await database.ScanFolderAsync(path);

                    // Query the database to retrieve media files and get a Reader containing results.
                    var command = new MediaInfoCommand(database);
                    var reader = command.SelectMedia(new SelectArguments()
                    {
                        FilterExpression = $"{MediaInfoColumns.MediaType}={(int)MediaType.Music}"
                            + $" OR {MediaInfoColumns.MediaType}={(int)MediaType.Sound}"
                            + $" OR {MediaInfoColumns.MediaType}={(int)MediaType.Video}"
                    });

                    // Iterate over media data in the results.
                    while (reader.Read())
                    {
                        var media = reader.Current;

                        // TODO: Insert code to do something with a media file.
                        // Note that your app needs adequate permissions to perform operations on the file
                        Logger.Info($"{media.MediaType}: {media.Title}");
                    }
                }
                catch (MediaDatabaseException)
                {
                    // TODO: Handle exception as appropriate to your scenario.
                }
            }
        }
    }
}
