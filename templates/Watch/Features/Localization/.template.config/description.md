This feature provides functionalities for localizing applications.

- String localization
- Image localization

Strings should be stored using a naming convention for resource files. The file name of each resource should include the language information. For example, AppResources.ko-KR.resx and AppResources.en.resx. For more details, see [Managing Strings for Localization in Tizen .NET Applications](https://developer.samsung.com/tizen/blog/en-us/2020/04/24/managing-strings-for-localization-in-tizen-net-applications).

Image files should be stored using a naming convention for folders in res/contents directory. Folders are named as `Language_Country-DPI`. For example, `en_US-All`. For more details, see [Managing Images for Localization in Tizen .NET Applications](https://developer.samsung.com/tizen/blog/en-us/2020/04/28/managing-images-for-localization-in-tizen-net-applications).

Check out sample below to learn about Localization.

 - [UsingResxLocalization](https://github.com/Samsung/Tizen-CSharp-Samples/tree/master/Wearable/UsingResxLocalization)