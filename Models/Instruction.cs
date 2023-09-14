namespace SynthNetVoice.Data.Models
{
    /// <summary>
    /// Represents a model for instructions.
    /// </summary>
    public class Instruction
    {
        /// <summary>
        /// System instructions
        /// </summary>
        public string FromSystem { get; set; } = string.Empty;
        /// <summary>
        /// User instructions
        /// </summary>
        public string FromUser { get; set; } = string.Empty;

        public Instruction() { }

    }
}
