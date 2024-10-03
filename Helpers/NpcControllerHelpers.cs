using OpenAI.Chat;

namespace SynthNetVoice.Data.Helpers
{
    public static class NpcControllerHelpers
    {

        /// <summary>
        /// Conversation which encapsulates an AI ongoing chat.
        /// </summary>
        public static ChatClient? LocalConversation { get; set; } = default;
        /// <summary>
        /// Get/set the instructions for the NPC bot..
        /// </summary>
        public static string LocalSystemInstructions { get; set; } = string.Empty;
        /// <summary>
        /// Get/set the instructions for the NPC bot..
        /// </summary>
        public static string LocalUserInstructions { get; set; } = string.Empty;
        /// <summary>
        /// All messages to complete the chat.
        /// </summary>
        public static List<ChatMessage> LocalMessages { get; set; } = [];
        /// <summary>
        /// Inidicates NPC bot state.
        /// </summary>
        public static bool IsInitialized { get; set; } = false;
        /// <summary>
        /// Status NPC training
        /// </summary>
        public static bool IsTrained { get; set; } = false;
    }
}