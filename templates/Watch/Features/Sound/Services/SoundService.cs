using System;
using System.Threading.Tasks;
using Tizen.Multimedia;

namespace Param_RootNamespace.Services
{
    /// <summary>
    /// Provides the ability to control media playback.
    /// </summary>
    public partial class SoundService : IDisposable
    {
        private Player _player = null;

        private bool _streamTypeUpdated = true;

        private AudioStreamType _streamType = AudioStreamType.Media;

        private AudioStreamPolicy _streamPolicy = null;

        private bool _mediaSourceUpdated = false;

        private MediaSource _mediaSource = null;

        private bool _disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="SoundService"/> class.
        /// </summary>
        public SoundService()
        {
            _player = new Player();
            _player.PlaybackInterrupted += OnInterrupted;
            _player.ErrorOccurred += OnErrorOccurred;
            _player.PlaybackCompleted += OnCompleted;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="SoundService"/> class.
        /// </summary>
        ~SoundService()
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets the state of the player.
        /// </summary>
        public PlayerState State => _player.State;

        /// <summary>
        /// Gets or sets the media source.
        /// </summary>
        /// <remarks>
        /// This source will be played when Play() is called.
        /// </remarks>
        public MediaSource Source
        {
            get
            {
                return _mediaSource;
            }

            set
            {
                _mediaSourceUpdated = true;
                _mediaSource = value;
            }
        }

        /// <summary>
        /// Gets or sets the type of the sound stream. Default type is media.
        /// </summary>
        /// <remarks>
        /// This type will be applied when Play() is called.
        /// </remarks>
        public AudioStreamType StreamType
        {
            get
            {
                return _streamType;
            }

            set
            {
                if (_streamType != value)
                {
                    _streamTypeUpdated = true;
                    _streamType = value;
                }
            }
        }

        /// <summary>
        /// Releases all resources used by the current instance.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases all resources used by the current instance.
        /// </summary>
        /// <param name="disposing">Indicates whether the method call comes from a Dispose method or from a finalizer.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _player.PlaybackCompleted -= OnCompleted;
                _player.PlaybackInterrupted -= OnInterrupted;
                _player.ErrorOccurred -= OnErrorOccurred;
                _player.Dispose();

                _streamPolicy.FocusStateChanged -= OnFocusStateChanged;
                _streamPolicy.Dispose();
            }

            _disposed = true;
        }

        /// <summary>
        /// Plays a sound.
        /// </summary>
        /// <remarks>
        /// You may need to stop or pause playing a sound when your app is paused.
        /// </remarks>
        /// <param name="isLooping">Indicates whether play sound repeatedly.</param>
        public async Task PlayAsync(bool isLooping = true)
        {
            if (_mediaSourceUpdated || _streamTypeUpdated)
            {
                if (_player.State != PlayerState.Idle)
                {
                    _player.Unprepare();
                }

                if (_mediaSourceUpdated)
                {
                    _player.SetSource(_mediaSource);
                    _mediaSourceUpdated = false;
                }

                if (_streamTypeUpdated)
                {
                    if (_streamPolicy != null)
                    {
                        _streamPolicy.FocusStateChanged -= OnFocusStateChanged;
                        _streamPolicy.Dispose();
                    }

                    _streamPolicy = new AudioStreamPolicy(_streamType);
                    _streamPolicy.FocusStateChanged += OnFocusStateChanged;

                    // TODO: If you want to reacquire the focus you've lost automatically, enable the focus reacquisition.
                    // In addition, you may need to implement the case of AudioStreamFocusState.Acquired in OnFocusStateChanged.
                    _streamPolicy.FocusReacquisitionEnabled = false;
                    _player.ApplyAudioStreamPolicy(_streamPolicy);
                    _streamTypeUpdated = false;
                }
            }

            if (_player.State == PlayerState.Playing)
            {
                _player.Stop();
            }
            else if (_player.State == PlayerState.Idle)
            {
                await _player.PrepareAsync();
            }

            if (_streamPolicy.PlaybackFocusState != AudioStreamFocusState.Acquired)
            {
                _streamPolicy.AcquireFocus(AudioStreamFocusOptions.Playback, AudioStreamBehaviors.Fading, null);
            }

            _player.IsLooping = isLooping;
            _player.Start();
        }

        /// <summary>
        /// Stops the playback.
        /// </summary>
        /// <remarks>
        /// You may need to stop or pause playing a sound when your app is paused.
        /// </remarks>
        public void Stop()
        {
            if (_player.State == PlayerState.Playing)
            {
                _player.Stop();
                _streamPolicy.ReleaseFocus(AudioStreamFocusOptions.Playback, AudioStreamBehaviors.Fading, null);
            }
        }

        /// <summary>
        /// Pauses the playback. You can resume the playback by calling Play().
        /// </summary>
        /// <remarks>
        /// You may need to stop or pause playing a sound when your app is paused.
        /// </remarks>
        public void Pause()
        {
            if (_player.State == PlayerState.Playing)
            {
                _player.Pause();
                _streamPolicy.ReleaseFocus(AudioStreamFocusOptions.Playback, AudioStreamBehaviors.Fading, null);
            }
        }

        private void OnFocusStateChanged(object sender, AudioStreamPolicyFocusStateChangedEventArgs e)
        {
            // SoundService stops the playback when the AudioStreamPolicy has lost the stream focus
            if (e.FocusState == AudioStreamFocusState.Released)
            {
                Stop();
            }

            // TODO: If you want to reacquire the focus you've lost automatically, then you may need to implement the case of AudioStreamFocusState.Acquired
        }

        private void OnInterrupted(object sender, PlaybackInterruptedEventArgs e)
        {
            // TODO: Insert code to handle the interrupted event.
            // This event is triggered when the application is interrupted by another applications.
            // The player is paused or moved to the Idle state according to the audio session manager (ASM) policy.
            // You need to check the current state of player before taking an action.
            // For more details, see https://docs.tizen.org/application/dotnet/guides/multimedia/media-playback.
        }

        private void OnErrorOccurred(object sender, PlayerErrorOccurredEventArgs e)
        {
            // TODO: Insert code to handle the error
            // This event is triggered when an error occurs from the player.
        }

        private void OnCompleted(object sender, EventArgs e)
        {
            // TODO: Insert code to handle the completed event.
            // This event is triggered when the playback is finished.
        }
    }
}
