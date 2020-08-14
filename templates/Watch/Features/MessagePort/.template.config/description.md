Tizen applications can communicate with other applications using [Tizen.Application.Messages.MessagePort](https://samsung.github.io/TizenFX/stable/api/Tizen.Applications.Messages.MessagePort.html). Message Port passes a message between applications using [Tizen.Applications.Bundle](https://samsung.github.io/TizenFX/stable/api/Tizen.Applications.Bundle.html). Message Port is designed for transporting small size of data, so it is recommended to send a message under 4KB.

For more details, see [Message Port Guide](https://docs.tizen.org/application/dotnet/guides/app-management/message-port/#using-trusted-communication).

Check out samples below to learn about Message Port.

 - [MessagePortSampleApp](https://github.com/Samsung/Tizen-CSharp-Samples/tree/master/Wearable/MessagePortSampleApp)

 - [ServiceApp](https://github.com/Samsung/Tizen-CSharp-Samples/tree/master/Wearable/ServiceApp)