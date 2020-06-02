Ask the user to grant the privacy permissions at runtime.

You can check current permissions for privacy-related privileges and request user permission to use specified privileges.

Before Tizen 4.0, the pop-up requesting the user's consent to use privacy-related privileges was triggered by first access to protected resources or functionality. 
Since Tizen 4.0, you can decide the moment in the application life-cycle when permissions are granted. 
It can be at the application startup, or at the moment when some additional functionality is to be used.

For more details see [Privacy-related Permissions](https://docs.tizen.org/application/dotnet/guides/security/requesting-permissions).

Check out samples below to learn about Privacy Permission.

 - [ImageViewer](https://github.com/Samsung/Tizen-CSharp-Samples/tree/master/Wearable/ImageViewer)
 - [VoiceMemo](https://github.com/Samsung/Tizen-CSharp-Samples/tree/master/Wearable/VoiceMemo)