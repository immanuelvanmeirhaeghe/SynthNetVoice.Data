using System.Media;
using System.Text.Json.Serialization;
using System.Windows;
namespace SynthNetVoice.Data.Models
{
    public class Transcription
    {
        public string? Text { get; set; }

        public string? AudioFilePath { get; set; }

        public string? AudioFileName { get; set; }

        [JsonIgnore]
        public SoundPlayer? SoundPlayer { get; set; }

    }
}