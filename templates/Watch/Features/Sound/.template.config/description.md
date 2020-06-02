You can play a sound by [Tizen.Multimedia.Player](https://samsung.github.io/TizenFX/stable/api/Tizen.Multimedia.Player.html). Your sound can be mixed other sounds if you don't control the stream focus. You can control it by [Tizen.Multimedia.AudioStreamPolicy](https://samsung.github.io/TizenFX/stable/api/Tizen.Multimedia.AudioStreamPolicy.html). [Tizen.Multimedia.Player](https://samsung.github.io/TizenFX/stable/api/Tizen.Multimedia.Player.html) and [Tizen.Multimedia.AudioStreamPolicy](https://samsung.github.io/TizenFX/stable/api/Tizen.Multimedia.AudioStreamPolicy.html) are implemented using the dispose pattern, so you can call Dispose() when you don't need them any more.

You may need to stop or pause playing a sound when your app is paused. For more information about media playback, see [Media Playback Guide](https://docs.tizen.org/application/dotnet/guides/multimedia/media-playback).

Check out sample below to learn about Sound.

 - [VoiceMemo](https://github.com/Samsung/Tizen-CSharp-Samples/tree/master/Wearable/VoiceMemo)