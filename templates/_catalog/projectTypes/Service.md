A service is an application runs in the background without any user interface.

On a watch, apps running in the background consume device resources and it can potentially cause battery drain.

To minimize battery consumption, the system applies the following restrictions:

* The system doesn't start services automatically at boot time.
* The system doesn't restart services that are terminated abnormally.
* A service cannot start itself and must be launched explicitly by another application.

For more details, see [Service Application](https://docs.tizen.org/application/native/guides/applications/service-app)

To package UI and Service application together, the UI application should have a reference to the project of Service application.

For more details, see [How to package UI and Service applications together and perform them](https://developer.samsung.com/tizen/blog/en-us/2019/01/04/how-to-package-ui-and-service-applications-together-and-perform-them)
