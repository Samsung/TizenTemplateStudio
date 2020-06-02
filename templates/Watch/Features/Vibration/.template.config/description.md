This feature provides two types of vibration:

- Predefined pattern such as message, timer, power off. This type of vibration is played only once. You can find the supported patterns in [Tizen.System.Feedback](https://samsung.github.io/TizenFX/stable/api/Tizen.System.Feedback.html).

- Custom pattern. You can play your own vibration patterns just one time or repeatedly.

You may need to turn off vibration when your app is paused. In addition, this feature is implemented using the dispose pattern, so you can call Dispose() when you don't need this any more.

You can find the related API references:

- [Tizen.System.Vibrator](https://samsung.github.io/TizenFX/stable/api/Tizen.System.Vibrator.html)

- [Tizen.System.Feedback](https://samsung.github.io/TizenFX/stable/api/Tizen.System.Feedback.html)

Check out samples below to learn about Vibration.

 - [Alarm](https://github.com/Samsung/Tizen-CSharp-Samples/tree/master/Wearable/Alarm)
 - [FeedbackApp](https://github.com/Samsung/Tizen-CSharp-Samples/tree/master/Wearable/FeedbackApp)
 - [RotaryTimer](https://github.com/Samsung/Tizen-CSharp-Samples/tree/master/Wearable/RotaryTimer)