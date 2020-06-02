using System;
using System.Threading.Tasks;
using Tizen.Multimedia;

namespace Param_RootNamespace.Services
{
    // TODO: Remove this sample and Alarms_on_call.ogg if it's not needed.
    // This sample shows how to play alarm sound.

    public partial class SoundService : IDisposable
    {
        /// <summary>
        /// Play an alarm sound.
        /// </summary>
        public async Task PlayAlarmSoundSampleAsync()
        {
            Source = new MediaUriSource(Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Alarms_on_call.ogg");
            StreamType = AudioStreamType.Alarm;
            await PlayAsync();
        }
    }
}
