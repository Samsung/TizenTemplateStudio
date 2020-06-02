Use shared storage for files that other apps can access.

The files in shared storage remain on the device even after the app is uninstalled.

Note that this template declares the ['http://tizen.org/privilege/mediastorage'](https://docs.tizen.org/application/dotnet/tutorials/sec-privileges) privilege and asks the user to grant the permissions at runtime.

For more details about storage, see [Data Storages Guide](https://docs.tizen.org/application/dotnet/guides/data/data-storages).

You can also use the app's private directories to store sensitive files that other apps shouldn't access.

For details about working with app's directories, see [Tizen.Application.DirectoryInfo](https://samsung.github.io/TizenFX/stable/api/Tizen.Applications.DirectoryInfo.html)

Check out sample below to learn about Shared Storage.

 - [StorageApp](https://github.com/Samsung/Tizen-CSharp-Samples/tree/master/Wearable/StorageApp)