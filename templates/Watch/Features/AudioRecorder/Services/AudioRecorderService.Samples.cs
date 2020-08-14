using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Param_RootNamespace.Services
{
    public partial class AudioRecorderService : IDisposable
    {
        public async static void RecordVoiceSampleAsync()
        {
            try
            {
                var recorder = new AudioRecorderService();

                recorder.Prepare(AudioRecorderPreset.HighQualitySpeech);

                string directory = SharedStorageService.GetDirectory(Tizen.System.DirectoryType.Sounds);
                string path = Path.Combine(directory, "Sample.m4a");

                recorder.Start(path);

                // record audio for 30 seconds
                await Task.Delay(30 * 1000);

                recorder.Stop();

                recorder.Dispose();
            }
            catch (InvalidOperationException)
            {
                // TODO: The app is not in an appropriate state for the requested operation, handle exception as appropriate to your scenario.
            }
        }
    }
}
