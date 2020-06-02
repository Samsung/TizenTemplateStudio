This feature allows you to get information about device's geographic position. 

This feature consumes much power, so you need to use this carefully to conserve battery life. For more details, see [Location Information Guide](https://docs.tizen.org/application/dotnet/guides/location-sensors/location), [Tizen.Location.Locator](https://samsung.github.io/TizenFX/stable/api/Tizen.Location.Locator.html) and [Best Practices for Location](https://docs.tizen.org/application/native/tutorials/feature/best-practice-battery).

In addition, this feature needs a privacy-related privilege ['http://tizen.org/privilege/location'](https://docs.tizen.org/application/dotnet/tutorials/sec-privileges). So, you must declare this privilege in the tizen-manifest.xml and request user to grant this permission using PrivacyPrivilegeManager. For more details see [Privacy-related Permissions](https://docs.tizen.org/application/dotnet/guides/security/requesting-permissions).

Check out sample below to learn about Location.

 - [Location](https://github.com/Samsung/Tizen-CSharp-Samples/tree/master/Wearable/Location)