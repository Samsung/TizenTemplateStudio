On a watch, you should not assume an app can always access to the internet.

You can use the [Tizen.Network.Connection.ConnectionManager](https://samsung.github.io/TizenFX/stable/api/Tizen.Network.Connection.ConnectionManager.html) to check if an active network exists and determine a suitable network.

The app can access the internet directly if a watch's Wi-Fi or cellular network are available, but it may cause battery drain.

When a watch has a Bluetooth connection to a phone, the app can configure a proxy to access the internet through the phone.

For more details see [Use Web Proxy to Access the Internet When a Samsung Galaxy Watch and a Phone are Connected with Bluetooth](https://developer.samsung.com/tizen/blog/en-us/2019/08/14/tizen190814).

Check out samples below to learn about Network Access.

 - [NetworkApp](https://github.com/Samsung/Tizen-CSharp-Samples/tree/master/Wearable/NetworkApp)
 - [WeatherWatch](https://github.com/Samsung/Tizen-CSharp-Samples/tree/master/Wearable/WeatherWatch)