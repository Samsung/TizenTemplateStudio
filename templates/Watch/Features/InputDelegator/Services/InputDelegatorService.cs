using System;
using Tizen.Applications;

namespace Param_RootNamespace.Services
{
    /// <summary>
    /// Provides the ability to get user input by input delegators.
    /// For more details, see https://docs.tizen.org/application/native/guides/app-management/common-appcontrols/#input-delegator.
    /// This service requests the launch of input delegator application by application control, so your application must declare the privilege 'http://tizen.org/privilege/appmanager.launch'.
    /// For more details about application controls, see https://docs.tizen.org/application/dotnet/guides/app-management/app-controls.
    /// </summary>
    public static partial class InputDelegatorService
    {
        /// <summary>
        /// Application control operation for getting user input.
        /// </summary>
        private const string InputOperation = "http://tizen.org/appcontrol/operation/get_input";

        /// <summary>
        /// Application control data which is used when setting the max text length in keyboard input type.
        /// </summary>
        private const string TextMaxLengthData = "http://tizen.org/appcontrol/data/input_max_text_length";

        /// <summary>
        /// Application control data which is used when setting the label of the return key in keyboard input type.
        /// </summary>
        private const string ReturnKeyTypeData = "http://tizen.org/appcontrol/data/input_returnkey_type";

        /// <summary>
        /// Application control data which is used when setting cursor position to entry in keyboard input type.
        /// </summary>
        private const string CursorPositionSetData = "http://tizen.org/appcontrol/data/input_cursor_position_set";

        /// <summary>
        /// Request the launch of Input Delegator to receive the input from user.
        /// Available input types such as voice, emoji, handwriting, and keyboard will be shown.
        /// Then user can select one of them and input the requested data.
        /// </summary>
        /// <remarks>
        /// You can get the user input by AppControlData.Text or AppControlData.Path.
        /// For more details, see https://docs.tizen.org/application/native/guides/app-management/common-appcontrols/#extra-output-11.
        /// If user selects recording type or drawing type, then input data may be stored in media storage.
        /// If so, your application needs the permission to access that input file.
        /// </remarks>
        /// <param name="inputCallback">The callback function to be called when the input is received.</param>
        public static void GetInput(AppControlReplyCallback inputCallback)
        {
            AppControl request = new AppControl
            {
                Operation = InputOperation,
                Mime = "*/*"
            };

            // Set the launch mode for the application to be launched.
            // For more details about launch mode, see https://docs.tizen.org/application/dotnet/guides/app-management/app-controls/#application-group-management.
            request.LaunchMode = AppControlLaunchMode.Group;

            AppControl.SendLaunchRequest(request, inputCallback);
        }

        /// <summary>
        /// Request the launch of Input Delegator to receive the text input from user.
        /// </summary>
        /// <remarks>
        /// You can get the user input by AppControlData.Text.
        /// For more details, see https://docs.tizen.org/application/native/guides/app-management/common-appcontrols/#extra-output-11.
        /// </remarks>
        /// <param name="inputCallback">The callback function to be called when the input is received.</param>
        /// <param name="guideText">The guide text such as "Input user name". This is optional.</param>
        public static void GetTextInput(AppControlReplyCallback inputCallback, string guideText = null)
        {
            AppControl request = new AppControl
            {
                Operation = InputOperation,
                Mime = "text/plain"
            };

            // The type of input method
            request.ExtraData.Add(AppControlData.InputType, "input_keyboard");

            // The maximum text length allowed.
            request.ExtraData.Add(TextMaxLengthData, "20");

            // The label of the return key.
            request.ExtraData.Add(ReturnKeyTypeData, "Done");

            if (guideText != null)
            {
                request.ExtraData.Add(AppControlData.InputGuideText, guideText);
            }

            // Set the launch mode for the application to be launched.
            // For more details about launch mode, see https://docs.tizen.org/application/dotnet/guides/app-management/app-controls/#application-group-management.
            request.LaunchMode = AppControlLaunchMode.Group;

            AppControl.SendLaunchRequest(request, inputCallback);
        }

        /// <summary>
        /// Request the launch of Input Delegator to receive the text input from user.
        /// </summary>
        /// <remarks>
        /// You can get the user input by AppControlData.Text.
        /// For more details, see https://docs.tizen.org/application/native/guides/app-management/common-appcontrols/#extra-output-11.
        /// </remarks>
        /// <param name="inputCallback">The callback function to be called when the input is received.</param>
        /// <param name="defaultText">The preformatted text to be used as default input, such as "http://" for Web addresses.</param>
        /// <param name="cursorPosition">The position where the cursor is to be set (start at 0). If cursorPosition < 0, then the length of defaultText is used.</param>
        public static void GetTextInput(AppControlReplyCallback inputCallback, string defaultText, int cursorPosition)
        {
            if (defaultText == null)
            {
                throw new ArgumentNullException(nameof(defaultText));
            }

            AppControl request = new AppControl
            {
                Operation = InputOperation,
                Mime = "text/plain"
            };

            // The type of input method
            request.ExtraData.Add(AppControlData.InputType, "input_keyboard");

            // The maximum text length allowed.
            request.ExtraData.Add(TextMaxLengthData, "20");

            // The label of the return key.
            request.ExtraData.Add(ReturnKeyTypeData, "Go");

            request.ExtraData.Add(AppControlData.InputDefaultText, defaultText);

            if (cursorPosition < 0)
            {
                cursorPosition = defaultText.Length;
            }
            request.ExtraData.Add(CursorPositionSetData, cursorPosition.ToString());

            // Set the launch mode for the application to be launched.
            // For more details about launch mode, see https://docs.tizen.org/application/dotnet/guides/app-management/app-controls/#application-group-management.
            request.LaunchMode = AppControlLaunchMode.Group;

            AppControl.SendLaunchRequest(request, inputCallback);
        }

        /// <summary>
        /// Request the launch of Input Delegator to receive the voice input from user.
        /// </summary>
        /// <remarks>
        /// Spoken voice input is converted into text, so you can get the user input by AppControlData.Text.
        /// For more details, see https://docs.tizen.org/application/native/guides/app-management/common-appcontrols/#extra-output-11.
        /// </remarks>
        /// <param name="inputCallback">The callback function to be called when the input is received.</param>
        public static void GetVoiceInput(AppControlReplyCallback inputCallback)
        {
            AppControl request = new AppControl
            {
                Operation = InputOperation,
                Mime = "text/plain"
            };

            // The type of input method
            request.ExtraData.Add(AppControlData.InputType, "input_voice");

            // Set the launch mode for the application to be launched.
            // For more details about launch mode, see https://docs.tizen.org/application/dotnet/guides/app-management/app-controls/#application-group-management.
            request.LaunchMode = AppControlLaunchMode.Group;

            AppControl.SendLaunchRequest(request, inputCallback);
        }

        /// <summary>
        /// Request the launch of Input Delegator to receive the emoticon input from user.
        /// </summary>
        /// <remarks>
        /// You can get the user input by AppControlData.Text.
        /// For more details, see https://docs.tizen.org/application/native/guides/app-management/common-appcontrols/#extra-output-11.
        /// </remarks>
        /// <param name="inputCallback">The callback function to be called when the input is received.</param>
        public static void GetEmoticonInput(AppControlReplyCallback inputCallback)
        {
            AppControl request = new AppControl
            {
                Operation = InputOperation,
                Mime = "text/plain"
            };

            // The type of input method
            request.ExtraData.Add(AppControlData.InputType, "input_emoticon");

            // Set the launch mode for the application to be launched.
            // For more details about launch mode, see https://docs.tizen.org/application/dotnet/guides/app-management/app-controls/#application-group-management.
            request.LaunchMode = AppControlLaunchMode.Group;

            AppControl.SendLaunchRequest(request, inputCallback);
        }

        /// <summary>
        /// Request the launch of Input Delegator to receive the reply input from user.
        /// </summary>
        /// <remarks>
        /// You can get the user input by AppControlData.Text.
        /// For more details, see https://docs.tizen.org/application/native/guides/app-management/common-appcontrols/#extra-output-11.
        /// </remarks>
        /// <param name="inputCallback">The callback function to be called when the input is received.</param>
        /// <param name="incomingMessage">The message to be used as the hint at reply suggestions. This is optional.</param>
        public static void GetReplyInput(AppControlReplyCallback inputCallback, string incomingMessage = null)
        {
            AppControl request = new AppControl
            {
                Operation = InputOperation,
                Mime = "text/plain"
            };

            // The type of input method
            request.ExtraData.Add(AppControlData.InputType, "input_reply");

            if (incomingMessage != null)
            {
                request.ExtraData.Add(AppControlData.InputPredictionHint, incomingMessage);
            }

            // Set the launch mode for the application to be launched.
            // For more details about launch mode, see https://docs.tizen.org/application/dotnet/guides/app-management/app-controls/#application-group-management.
            request.LaunchMode = AppControlLaunchMode.Group;

            AppControl.SendLaunchRequest(request, inputCallback);
        }

        /// <summary>
        /// Request the launch of Input Delegator to receive the drawing input from user.
        /// </summary>
        /// <remarks>
        /// You can get the user input by AppControlData.Path which contains the list of multiple image file paths.
        /// For more details, see https://docs.tizen.org/application/native/guides/app-management/common-appcontrols/#extra-output-11.
        /// If input data is stored in media storage, then your application needs the permission to access that input file.
        /// </remarks>
        /// <param name="inputCallback">The callback function to be called when the input is received.</param>
        public static void GetDrawingInput(AppControlReplyCallback inputCallback)
        {
            AppControl request = new AppControl
            {
                Operation = InputOperation,
                Mime = "image/*"
            };

            // The type of input method
            request.ExtraData.Add(AppControlData.InputType, "input_drawing");

            // Set the launch mode for the application to be launched.
            // For more details about launch mode, see https://docs.tizen.org/application/dotnet/guides/app-management/app-controls/#application-group-management.
            request.LaunchMode = AppControlLaunchMode.Group;

            AppControl.SendLaunchRequest(request, inputCallback);
        }

        /// <summary>
        /// Request the launch of Input Delegator to receive the recording input from user.
        /// </summary>
        /// <remarks>
        /// You can get the user input by AppControlData.Path which contains the list of multiple audio file paths.
        /// For more details, see https://docs.tizen.org/application/native/guides/app-management/common-appcontrols/#extra-output-11.
        /// If input data is stored in media storage, then your application needs the permission to access that input file.
        /// </remarks>
        /// <param name="inputCallback">The callback function to be called when the input is received.</param>
        public static void GetRecordingInput(AppControlReplyCallback inputCallback)
        {
            AppControl request = new AppControl
            {
                Operation = InputOperation,
                Mime = "audio/*"
            };

            // The type of input method
            request.ExtraData.Add(AppControlData.InputType, "input_recording");

            // Set the launch mode for the application to be launched.
            // For more details about launch mode, see https://docs.tizen.org/application/dotnet/guides/app-management/app-controls/#application-group-management.
            request.LaunchMode = AppControlLaunchMode.Group;

            AppControl.SendLaunchRequest(request, inputCallback);
        }
    }
}
