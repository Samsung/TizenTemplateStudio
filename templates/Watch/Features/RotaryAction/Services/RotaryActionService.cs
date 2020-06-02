using System;

using Tizen.Wearable.CircularUI.Forms;

namespace Param_RootNamespace.Services
{
    /// <summary>
    /// This service provides a rotated event of RotaryEventManager.
    /// For more information about rotary event, see https://developer.tizen.org/development/training/native-application/understanding-tizen-programming/event-handling#rotary
    /// </summary>
    public static class RotaryActionService
    {
        public static void Initialize()
        {
            // RotaryEventManager can receive rotary event for rotary action globally.
            RotaryEventManager.Rotated += OnRotated;
        }

        private static void OnRotated(object sender, RotaryEventArgs args)
        {
            // Return true if rotated clockwise, otherwise false
            // TODO: Insert code to handle the Rotary rotated.
            Logger.Info($"Rotating clockwise is {args.IsClockwise}");
        }
    }
}
