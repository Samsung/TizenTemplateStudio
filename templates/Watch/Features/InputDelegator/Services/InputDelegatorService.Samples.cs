using System;
using System.Collections.Generic;
using System.Text;

using Tizen.Applications;

namespace Param_RootNamespace.Services
{
    public static partial class InputDelegatorService
    {
        public static void GetInputSample()
        {
            GetInput((launchRequest, reply, result) =>
            {
                if (result == AppControlReplyResult.Succeeded)
                {
                    if (reply.ExtraData.TryGet(AppControlData.Text, out string text))
                    {
                        Logger.Info("Text: " + text);
                    }

                    if (reply.ExtraData.TryGet(AppControlData.Path, out IEnumerable<string> paths))
                    {
                        // If user selects recording type or drawing type,
                        // then you can get the user input by AppControlData.Path which contains the list of multiple file paths.
                        foreach (string path in paths)
                        {
                            Logger.Info("Path: " + path);
                        }
                    }
                }
            });
        }

        public static void GetTextInputSample()
        {
            GetTextInput((launchRequest, reply, result) =>
            {
                if (result == AppControlReplyResult.Succeeded)
                {
                    if (reply.ExtraData.TryGet(AppControlData.Text, out string text))
                    {
                        Logger.Info("Text: " + text);
                    }
                }
            },
            "Name");    // Guide text
        }

        public static void GetVoiceInputSample()
        {
            GetVoiceInput((launchRequest, reply, result) =>
            {
                if (result == AppControlReplyResult.Succeeded)
                {
                    if (reply.ExtraData.TryGet(AppControlData.Text, out string text))
                    {
                        Logger.Info("Text: " + text);
                    }
                }
            });
        }

        public static void GetEmoticonInputSample()
        {
            GetEmoticonInput((launchRequest, reply, result) =>
            {
                if (result == AppControlReplyResult.Succeeded)
                {
                    if (reply.ExtraData.TryGet(AppControlData.Text, out string text))
                    {
                        byte[] byteReply = Encoding.BigEndianUnicode.GetBytes(text);
                        Logger.Info("Emoticon in UTF-16: " + BitConverter.ToString(byteReply).Replace("-", ""));
                    }
                }
            });
        }

        public static void GetReplyInputSample()
        {
            GetReplyInput((launchRequest, reply, result) =>
            {
                if (result == AppControlReplyResult.Succeeded)
                {
                    if (reply.ExtraData.TryGet(AppControlData.Text, out string text))
                    {
                        Logger.Info("Text: " + text);
                    }
                }
            },
            "Hello");   // Incomming message
        }

        public static void GetDrawingInputSample()
        {
            GetDrawingInput((launchRequest, reply, result) =>
            {
                if (result == AppControlReplyResult.Succeeded)
                {
                    if (reply.ExtraData.TryGet(AppControlData.Path, out IEnumerable<string> paths))
                    {
                        foreach (string path in paths)
                        {
                            Logger.Info("Path: " + path);
                        }
                    }
                }
            });
        }

        public static void GetRecordingInputSample()
        {
            GetRecordingInput((launchRequest, reply, result) =>
            {
                if (result == AppControlReplyResult.Succeeded)
                {
                    if (reply.ExtraData.TryGet(AppControlData.Path, out IEnumerable<string> paths))
                    {
                        foreach (string path in paths)
                        {
                            Logger.Info("Path: " + path);
                        }
                    }
                }
            });
        }
    }
}
