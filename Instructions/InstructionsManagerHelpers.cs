namespace SynthNetVoice.Data.Instructions
{
    public class InstructionsManagerHelpers
    {
        public class DefaultGame
        {
            public static string DefaultPath { get; set; } = AppContext.BaseDirectory.ToString();
            public static string DefaultGameDataPath { get; set; } = "DefaultGameData";
            public static string DefaultSystemInstructionsFileName { get; set; } = "SystemInstructions.txt";
            public static string DefaultUserInstructionsFileName { get; set; } = "UserInstructions.txt";
            public static string DefaultNpcNameParameter { get; set; } = "__NPC__";
            public static string DefaultGameDataPathParameter { get; set; } = "__DataPath__";
            public static string DefaultNpcName { get; set; } = "Player";
        }
        public class Fallout4
        {
            public static string DefaultPath { get; set; } = AppContext.BaseDirectory.ToString();
            public static string DefaultGameDataPath { get; set; } = "Fallout4Data";
            public static string DefaultSystemInstructionsFileName { get; set; } = "SystemInstructions.txt";
            public static string DefaultUserInstructionsFileName { get; set; } = "UserInstructions.txt";
            public static string DefaultNpcNameParameter { get; set; } = "__NPC__";
            public static string DefaultGameDataPathParameter { get; set; } = "__DataPath__";
            public static string DefaultNpcName { get; set; } = "Codsworth";
        }
        public class GreenHell
        {
            public static string DefaultPath { get; set; } = AppContext.BaseDirectory.ToString();
            public static string DefaultGameDataPath { get; set; } = "GreenHellData";
            public static string DefaultSystemInstructionsFileName { get; set; } = "SystemInstructions.txt";
            public static string DefaultUserInstructionsFileName { get; set; } = "UserInstructions.txt";
            public static string DefaultNpcNameParameter { get; set; } = "__NPC__";
            public static string DefaultGameDataPathParameter { get; set; } = "__DataPath__";
            public static string DefaultNpcName { get; set; } = "a Spearman";
        }
        public class VamX
        {
            public static string DefaultPath { get; set; } = AppContext.BaseDirectory.ToString();
            public static string DefaultGameDataPath { get; set; } = "VamData";
            public static string DefaultSystemInstructionsFileName { get; set; } = "SystemInstructions.txt";
            public static string DefaultUserInstructionsFileName { get; set; } = "UserInstructions.txt";
            public static string DefaultNpcNameParameter { get; set; } = "__NPC__";
            public static string DefaultGameDataPathParameter { get; set; } = "__DataPath__";
            public static string DefaultNpcName { get; set; } = "Lexi";
        }
    }
}