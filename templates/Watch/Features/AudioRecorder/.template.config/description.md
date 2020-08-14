
This feature allows you to record audio from microphone.

For more information about the recorder see [Media Recording](https://docs.tizen.org/application/dotnet/guides/multimedia/media-recording)

The recorder is based on a state machine and invoking a recording operation in an invalid state may throw an exception.
For instructions on managing the recorder state, see [Recorder API](https://docs.tizen.org/application/native/api/wearable/4.0/group__CAPI__MEDIA__RECORDER__MODULE.html)

In order to access the device's microphone and store the recorded file to the shared storage, this feature declares the [http://tizen.org/privilege/recorder](https://docs.tizen.org/application/dotnet/tutorials/sec-privileges) and [http://tizen.org/privilege/mediastorage](https://docs.tizen.org/application/dotnet/tutorials/sec-privileges).
