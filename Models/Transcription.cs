using System.Media;
using System.Text.Json.Serialization;
namespace SynthNetVoice.Data.Models
{
    /// <summary>
    /// Transcription info
    /// </summary>
    public class Transcription
    {
        /// <summary>
        /// File path with file name of input document containing text that will be transcribed to a sound file and spoken out.
        /// </summary>
        public string? TextFilePath { get; set; }
        /// <summary>
        /// File path where the transcribed audio file will be saved.
        /// </summary>
        public string? AudioFilePath { get; set; }
        /// <summary>
        /// File name for the audio file with extension.
        /// </summary>
        public string? AudioFileName { get; set; }

        [JsonIgnore]
        public SoundPlayer? SoundPlayer { get; set; }

    }
}