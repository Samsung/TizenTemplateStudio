using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tizen.Multimedia;
using Xamarin.Forms;

namespace Param_RootNamespace.Services
{
    /// <summary>
    /// Provides presets to set the quality of audio recordings.
    /// </summary>
    public class AudioRecorderPreset
    {
        /// <summary>
        /// A low-quality voice recording with smaller file size.
        /// </summary>
        public static readonly AudioRecorderPreset LowQualitySpeech = new AudioRecorderPreset()
        {
            Codec = RecorderAudioCodec.Aac,
            FileFormat = RecorderFileFormat.ThreeGp,
            BitRate = 24000,
            SampleRate = 8000
        };

        /// <summary>
        /// A high-quality voice recording.
        /// </summary>
        public static readonly AudioRecorderPreset HighQualitySpeech = new AudioRecorderPreset()
        {
            Codec = RecorderAudioCodec.Aac,
            FileFormat = RecorderFileFormat.ThreeGp,
            BitRate = 64000,
            SampleRate = 16000
        };

        /// <summary>
        /// A high-quality audio recording.
        /// </summary>
        public static readonly AudioRecorderPreset HighQualityAudio = new AudioRecorderPreset()
        {
            Codec = RecorderAudioCodec.Aac,
            FileFormat = RecorderFileFormat.ThreeGp,
            BitRate = 128000,
            SampleRate = 44100
        };

        /// <summary>
        /// Gets the audio codec.
        /// </summary>
        public RecorderAudioCodec Codec { get; private set; }

        /// <summary>
        /// Gets the audio file format.
        /// </summary>
        public RecorderFileFormat FileFormat { get; private set; }

        /// <summary>
        /// Gets the audio bit rate.
        /// </summary>
        public int BitRate { get; private set; }

        /// <summary>
        /// Gets the sample rate.
        /// </summary>
        public int SampleRate { get; private set; }
    }
}
