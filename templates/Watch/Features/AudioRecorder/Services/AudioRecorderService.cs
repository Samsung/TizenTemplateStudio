using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tizen.Multimedia;
using Xamarin.Forms;

namespace Param_RootNamespace.Services
{
    /// <summary>
    /// Provides a service to record audio from the device.
    /// For more information about recorder see https://docs.tizen.org/application/dotnet/guides/multimedia/media-recording/
    /// For more information about managing the recorder state, see https://docs.tizen.org/application/native/api/wearable/4.0/group__CAPI__MEDIA__RECORDER__MODULE.html
    /// This service will access the device's audio input and you must declare the 'http://tizen.org/privilege/recorder' privilege in the manifest file.
    /// In order to produce the recorded output file to the shared storage, you must also declare the 'http://tizen.org/privilege/mediastorage' privilege in the manifest file.
    /// </summary>
    public partial class AudioRecorderService : IDisposable
    {
        private AudioRecorder _recorder = null;

        private bool _disposed = false;

        ~AudioRecorderService()
        {
            Dispose(false);
        }

        /// <summary>
        /// Prepares the audio recorder.
        /// </summary>
        /// <remarks>
        /// This method must be called before start().
        /// </remarks>
        /// <param name="preset">
        /// The preset to specify the quality of audio recording.
        /// </param>
        /// <exception cref="InvalidOperationException">If it is called after start().</exception>
        /// <exception cref="ArgumentNullException">preset is null</exception>
        public void Prepare(AudioRecorderPreset preset)
        {
            if (preset == null)
            {
                throw new ArgumentNullException(nameof(preset));
            }

            if (_recorder == null)
            {
                _recorder = new AudioRecorder(preset.Codec, preset.FileFormat);
                _recorder.StateChanged += OnStateChanged;
                _recorder.ErrorOccurred += OnErrorOccurred;
                _recorder.RecordingStatusChanged += OnRecordingStatusChanged;
                _recorder.RecordingLimitReached += OnRecordingLimitReached;
            }
            else
            {
                _recorder.SetFormatAndCodec(preset.Codec, preset.FileFormat);
            }

            _recorder.AudioBitRate = preset.BitRate;
            _recorder.AudioSampleRate = preset.SampleRate;

            _recorder.AudioDevice = RecorderAudioDevice.Mic;
            
            _recorder.Prepare();
        }

        /// <summary>
        /// Begins recording.
        /// </summary>
        /// <param name="path">
        /// The output file to be produced.
        /// </param>
        /// <exception cref="InvalidOperationException">If it is called before prepare() or when the recording is already started or paused</exception>
        public void Start(string path)
        {
            if (_recorder == null)
            {
                throw new InvalidOperationException("The recorder has not been prepared.");
            }

            _recorder.Start(path);
        }

        /// <summary>
        /// Pauses recording. Call Resume() to resume
        /// </summary>
        /// /// <exception cref="InvalidOperationException">If it is called before start(), or after stop()</exception>
        public void Pause()
        {
            if (_recorder == null)
            {
                throw new InvalidOperationException("The recorder has not been prepared.");
            }

            _recorder.Pause();
        }

        /// <summary>
        /// Resumes recording.
        /// </summary>
        /// <exception cref="InvalidOperationException">If it is called before start(), or after stop()</exception>
        public void Resume()
        {
            if (_recorder == null)
            {
                throw new InvalidOperationException("The recorder has not been prepared.");
            }

            _recorder.Resume();
        }

        /// <summary>
        /// Stops recording and closes the audio file.
        /// </summary>
        /// <exception cref="InvalidOperationException">If it is called before start()</exception>
        public void Stop()
        {
            if (_recorder == null)
            {
                throw new InvalidOperationException("The recorder has not been prepared.");
            }

            _recorder.Commit();
        }

        /// <summary>
        /// Cancels recording.
        /// </summary>
        /// <exception cref="InvalidOperationException">If it is called before start()</exception>
        public void Cancel()
        {
            if (_recorder == null)
            {
                throw new InvalidOperationException("The recorder has not been prepared.");
            }

            _recorder.Cancel();
        }

        /// <summary>
        /// Releases all resources used by the current instance
        /// </summary>
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases all resources used by the current instance
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_recorder != null)
                    {
                        if (_recorder.State == RecorderState.Paused || _recorder.State == RecorderState.Recording)
                        {
                            _recorder.Cancel();
                        }
                        _recorder.StateChanged -= OnStateChanged;
                        _recorder.ErrorOccurred -= OnErrorOccurred;
                        _recorder.RecordingStatusChanged -= OnRecordingStatusChanged;
                        _recorder.RecordingLimitReached -= OnRecordingLimitReached;
                        _recorder.Unprepare();
                        _recorder.Dispose();
                        _recorder = null;
                    }
                }

                _recorder = null;
                _disposed = true;
            }
        }

        private void OnRecordingLimitReached(object sender, RecordingLimitReachedEventArgs e)
        {
            switch (e.Type)
            {
                case RecordingLimitType.Time:
                    // TODO: Insert code to handle when a maximum duration has been reached.
                    break;

                case RecordingLimitType.Size:
                    // TODO: Insert code to handle when a maximum file size has been reached.
                    break;

                case RecordingLimitType.Space:
                    // TODO: Insert code to handle when there is not enough space available on the storage to continue recording.
                    break;
            }
        }

        private void OnRecordingStatusChanged(object sender, RecordingStatusChangedEventArgs e)
        {
            // TODO: Insert code to handle the recording status changes.
            // Logger.Info($"Elapsed time: {e.ElapsedTime} ms, file size: {e.FileSize} kb");
        }

        private void OnStateChanged(object sender, RecorderStateChangedEventArgs e)
        {
            // TODO: Insert code to handle the recorder state changes.
            // Logger.Info($"Recorder state changed: {e.PreviousState} > {e.CurrentState}");
        }

        private void OnErrorOccurred(object sender, RecordingErrorOccurredEventArgs e)
        {
            // TODO: Insert code to handle an error.
            // Logger.Error($"An error occurred during recording: {e.Error}");
        }
    }
}
