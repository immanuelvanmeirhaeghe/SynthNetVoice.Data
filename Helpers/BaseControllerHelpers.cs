using SynthNetVoice.Data.Enums;

namespace SynthNetVoice.Data.Helpers
{
    public static class BaseControllerHelpers
    {
        public const string LocalConversationFolder = "D:\\Workspaces\\VSTS\\SynthNetVoice.Data\\Logs\\";
        public const string LocalAudioFolder = $"D:\\Workspaces\\VSTS\\SynthNetVoice.Data\\Voices\\";
        public const string ConversationTemplateAppend = "<div style=\"height:auto; width:auto;\">{{__TEXT__}}</div>{{__APPEND__}}";
        public const string ConversationTemplateFile = "D:\\Workspaces\\VSTS\\SynthNetVoice.Data\\Logs\\log.html";
        public const string ConversationTemplateTitleParam = "{{__TITLE__}}";
        public const string ConversationTemplateTextParam = "{{__TEXT__}}";
        public const string ConversationTemplateAppendParam = "{{__APPEND__}}";

        public static string LocalTextFromAudioFile { get; set; } = string.Empty;
        public static string LocalAudioFile { get; set; } = string.Empty;
        public static string LocalAudioFileTitle { get; set; } = string.Empty;
        public static string LocalConversationFile { get; set; } = string.Empty;
        public static string SelectedVoiceInfoName { get; set; } = string.Empty;
        public static bool IsCompleted { get; set; } = false;
        /// <summary>
        /// Name of the NPC.
        /// </summary>
        public static string LocalNpcName { get; set; } = "MamaMurphy";
        /// <summary>
        /// Game of the NPC.
        /// </summary>
        public static GameNames LocalGameName { get; set; } = GameNames.Fallout4;
    }
}