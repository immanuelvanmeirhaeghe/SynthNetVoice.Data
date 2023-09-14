using SynthNetVoice.Data.Models;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace SynthNetVoice.Data.Instructions
{
    /// <summary>
    /// Manager for GPT system -, user - and other messages stored as text files.
    /// </summary>
    public class InstructionsManager
    {
        public InstructionsManager() { }

        /// <summary>
        /// Give instruction for a System message for an NPC bot.
        /// If not given, uses defaults.
        /// </summary>
        /// <param name="gameName">Name of the game</param>
        /// <param name="npcName">Name of the npc</param>
        /// <param name="npcNameParameter">placeholder for npc name</param>
        /// <param name="gameDataPath">Optional folder path where instructions are located</param>
        /// <param name="gameDataPathParameter">placeholder for game data path</param>
        /// <param name="systemInstructionsFileName">Optional file with instructions</param>
        /// <returns>System instructions</returns>
        public static async Task<string> GetSystemInstructionsAsync(
                                                                    string gameName = "",
                                                                    string? npcName = null,
                                                                    string? npcNameParameter = null,
                                                                    string? gameDataPath = null,
                                                                    string? gameDataPathParameter = null,
                                                                    string? systemInstructionsFileName = null)
        {
            string fromSystem = string.Empty;
            try
            {
                var task = new TaskFactory().StartNew(() =>
                {
                    switch (gameName.Trim().ToLower())
                    {
                        case "fallout4":
                            GetFallout4SystemInstruction(npcName,
                                           npcNameParameter,
                                           gameDataPath,
                                           gameDataPathParameter,
                                           systemInstructionsFileName,
                                           out string name,
                                           out string nameParameter,
                                           out string dataPath,
                                           out string pathParameter,
                                           out string path);
                            fromSystem = File.ReadAllText(path).Replace(pathParameter, dataPath).Replace(nameParameter, name);
                            break;
                        case "greenhell":
                            GetGreenHellSystemInstruction(npcName,
                                           npcNameParameter,
                                           gameDataPath,
                                           gameDataPathParameter,
                                           systemInstructionsFileName,
                                           out string ghname,
                                           out string ghnameParameter,
                                           out string ghdataPath,
                                           out string ghpathParameter,
                                           out string ghpath);
                            fromSystem = File.ReadAllText(ghpath).Replace(ghpathParameter, ghdataPath).Replace(ghnameParameter, ghname);
                            break;
                        case "vamx":
                            GetVamXSystemInstruction(npcName,
                                           npcNameParameter,
                                           gameDataPath,
                                           gameDataPathParameter,
                                           systemInstructionsFileName,
                                           out string vname,
                                           out string vnameParameter,
                                           out string vdataPath,
                                           out string vpathParameter,
                                           out string vpath);
                            fromSystem = File.ReadAllText(vpath).Replace(vpathParameter, vdataPath).Replace(vnameParameter, vname);
                            break;
                        default:
                            break;
                    }                   
                    return fromSystem;
                });

                fromSystem = await task;
                return fromSystem;
            }
            catch (Exception)
            {
                return fromSystem;
            }
        }

        private static void GetFallout4SystemInstruction(string? npcName,
                                                         string? npcNameParameter,
                                                         string? gameDataPath,
                                                         string? gameDataPathParameter,
                                                         string? systemInstructionsFileName,
                                                         out string name,
                                                         out string nameParameter,
                                                         out string dataPath,
                                                         out string pathParameter,
                                                         out string path)
        {
            name = npcName ?? InstructionsManagerHelpers.Fallout4.DefaultNpcName;
            nameParameter = npcNameParameter ?? InstructionsManagerHelpers.Fallout4.DefaultNpcNameParameter;
            dataPath = gameDataPath ?? InstructionsManagerHelpers.Fallout4.DefaultGameDataPath;
            pathParameter = gameDataPathParameter ?? InstructionsManagerHelpers.Fallout4.DefaultGameDataPathParameter;
            string fileName = systemInstructionsFileName ?? InstructionsManagerHelpers.Fallout4.DefaultSystemInstructionsFileName;
            path = Path.Combine(InstructionsManagerHelpers.Fallout4.DefaultPath, dataPath, fileName);
        }

        private static void GetGreenHellSystemInstruction(string? npcName,
                                                          string? npcNameParameter,
                                                          string? gameDataPath,
                                                          string? gameDataPathParameter,
                                                          string? systemInstructionsFileName,
                                                          out string name,
                                                          out string nameParameter,
                                                          out string dataPath,
                                                          out string pathParameter,
                                                          out string path)
        {
            name = npcName ?? InstructionsManagerHelpers.GreenHell.DefaultNpcName;
            nameParameter = npcNameParameter ?? InstructionsManagerHelpers.GreenHell.DefaultNpcNameParameter;
            dataPath = gameDataPath ?? InstructionsManagerHelpers.GreenHell.DefaultGameDataPath;
            pathParameter = gameDataPathParameter ?? InstructionsManagerHelpers.GreenHell.DefaultGameDataPathParameter;
            string fileName = systemInstructionsFileName ?? InstructionsManagerHelpers.GreenHell.DefaultSystemInstructionsFileName;
            path = Path.Combine(InstructionsManagerHelpers.GreenHell.DefaultPath, dataPath, fileName);
        }

        private static void GetVamXSystemInstruction(string? npcName,
                                                         string? npcNameParameter,
                                                         string? gameDataPath,
                                                         string? gameDataPathParameter,
                                                         string? systemInstructionsFileName,
                                                         out string name,
                                                         out string nameParameter,
                                                         out string dataPath,
                                                         out string pathParameter,
                                                         out string path)
        {
            name = npcName ?? InstructionsManagerHelpers.VamX.DefaultNpcName;
            nameParameter = npcNameParameter ?? InstructionsManagerHelpers.VamX.DefaultNpcNameParameter;
            dataPath = gameDataPath ?? InstructionsManagerHelpers.VamX.DefaultGameDataPath;
            pathParameter = gameDataPathParameter ?? InstructionsManagerHelpers.VamX.DefaultGameDataPathParameter;
            string fileName = systemInstructionsFileName ?? InstructionsManagerHelpers.VamX.DefaultSystemInstructionsFileName;
            path = Path.Combine(InstructionsManagerHelpers.VamX.DefaultPath, dataPath, fileName);
        }

        /// <summary>
        /// Give instruction for a User message for an NPC bot.
        /// If not given, uses defaults.
        /// </summary>
        /// <param name="gameName">Name of the game</param>
        /// <param name="npcName">Name of the npc</param>
        /// <param name="npcNameParameter">placeholder for npc name</param>
        /// <param name="gameDataPath">Optional folder path where instructions are located</param>
        /// <param name="gameDataPathParameter">placeholder for game data path</param>
        /// <param name="userInstructionsFileName">Optional file with instructions</param>
        /// <returns>User instructions</returns>
        public static async Task<string> GetUserInstructionsAsync(
                                                 string gameName = "",
                                                 string? npcName = null,
                                                 string? npcNameParameter = null,
                                                 string? gameDataPath = null,
                                                 string? gameDataPathParameter = null,
                                                 string? userInstructionsFileName = null)
        {
            string fromUser = string.Empty;           
            try
            {
                var task = new TaskFactory().StartNew(() =>
                {
                    switch (gameName.Trim().ToLower())
                    {
                        case "fallout4":
                            GetFallout4UserInstruction(npcName,
                                                       npcNameParameter,
                                                       gameDataPath,
                                                       gameDataPathParameter,
                                                       userInstructionsFileName,
                                                       out string dataPath,
                                                       out string fileName,
                                                       out string pathParameter,
                                                       out string nameParameter,
                                                       out string name,
                                                        out string path);
                            fromUser = File.ReadAllText(Path.Combine(InstructionsManagerHelpers.Fallout4.DefaultPath, dataPath, fileName)).Replace(pathParameter, dataPath).Replace(nameParameter, name);
                            break;
                        case "greenhell":
                            GetGreenHellUserInstructions(npcName,
                                           npcNameParameter,
                                           gameDataPath,
                                           gameDataPathParameter,
                                           userInstructionsFileName,
                                           out string ghname,
                                           out string ghfileName,
                                           out string ghnameParameter,
                                           out string ghdataPath,
                                           out string ghpathParameter,
                                           out string ghpath);
                            fromUser = File.ReadAllText(ghpath).Replace(ghpathParameter, ghdataPath).Replace(ghnameParameter, ghname);
                            break;
                        case "vamx":
                            GetVamXUserInstructions(npcName,
                                           npcNameParameter,
                                           gameDataPath,
                                           gameDataPathParameter,
                                           userInstructionsFileName,
                                           out string vname,
                                           out string vfileName,
                                           out string vnameParameter,
                                           out string vdataPath,
                                           out string vpathParameter,
                                           out string vpath);
                            fromUser = File.ReadAllText(vpath).Replace(vpathParameter, vdataPath).Replace(vnameParameter, vname);
                            break;
                        default:
                            break;
                    }
                    return fromUser;
                });

                fromUser = await task;
                return fromUser;
            }
            catch (Exception)
            {
                return fromUser;
            }
        }

        private static void GetGreenHellUserInstructions(string? npcName,
                                                         string? npcNameParameter,
                                                         string? gameDataPath,
                                                         string? gameDataPathParameter,
                                                         string? userInstructionsFileName,
                                                         out string ghname,
                                                         out string ghfileName,
                                                         out string ghnameParameter,
                                                         out string ghdataPath,
                                                         out string ghpathParameter,
                                                         out string ghpath)
        {
            ghname = npcName ?? InstructionsManagerHelpers.GreenHell.DefaultNpcName;
            ghnameParameter = npcNameParameter ?? InstructionsManagerHelpers.GreenHell.DefaultNpcNameParameter;
            ghdataPath = gameDataPath ?? InstructionsManagerHelpers.GreenHell.DefaultGameDataPath;
            ghpathParameter = gameDataPathParameter ?? InstructionsManagerHelpers.GreenHell.DefaultGameDataPathParameter;
            ghfileName = userInstructionsFileName ?? InstructionsManagerHelpers.GreenHell.DefaultUserInstructionsFileName;
            ghpath = Path.Combine(InstructionsManagerHelpers.GreenHell.DefaultPath, ghdataPath, ghfileName);
        }

        private static void GetFallout4UserInstruction(string? npcName,
                                                          string? npcNameParameter,
                                                          string? gameDataPath,
                                                          string? gameDataPathParameter,
                                                          string? userInstructionsFileName,
                                                          out string dataPath,
                                                          out string fileName,
                                                          out string pathParameter,
                                                          out string nameParameter,
                                                          out string name,
                                                           out string path)
        {
            name = npcName ?? InstructionsManagerHelpers.Fallout4.DefaultNpcName;
            nameParameter = npcNameParameter ?? InstructionsManagerHelpers.Fallout4.DefaultNpcNameParameter;
            dataPath = gameDataPath ?? InstructionsManagerHelpers.Fallout4.DefaultGameDataPath;
            pathParameter = gameDataPathParameter ?? InstructionsManagerHelpers.Fallout4.DefaultGameDataPathParameter;
            fileName = userInstructionsFileName ?? InstructionsManagerHelpers.Fallout4.DefaultUserInstructionsFileName;
            path = Path.Combine(InstructionsManagerHelpers.Fallout4.DefaultPath, dataPath, fileName);
        }

        private static void GetVamXUserInstructions(string? npcName,
                                                  string? npcNameParameter,
                                                  string? gameDataPath,
                                                  string? gameDataPathParameter,
                                                  string? userInstructionsFileName,
                                                  out string dataPath,
                                                  out string fileName,
                                                  out string pathParameter,
                                                  out string nameParameter,
                                                  out string name,
                                                   out string path)
        {
            name = npcName ?? InstructionsManagerHelpers.VamX.DefaultNpcName;
            nameParameter = npcNameParameter ?? InstructionsManagerHelpers.VamX.DefaultNpcNameParameter;
            dataPath = gameDataPath ?? InstructionsManagerHelpers.VamX.DefaultGameDataPath;
            pathParameter = gameDataPathParameter ?? InstructionsManagerHelpers.VamX.DefaultGameDataPathParameter;
            fileName = userInstructionsFileName ?? InstructionsManagerHelpers.VamX.DefaultUserInstructionsFileName;
            path = Path.Combine(InstructionsManagerHelpers.VamX.DefaultPath, dataPath, fileName);
        }

        /// <summary>
        /// Get system - and user instructions currently set for an NPC.
        /// </summary>
        /// <returns><see cref="Instruction"/></returns>
        public static async Task<Instruction> GetInstruction(
            string gameName = "",
            string? npcName = null)
        {
            Instruction instruction = new();
            try
            {
                string name = string.Empty;
                StringBuilder instructionsBuilder = new();

                switch (gameName.Trim().ToLower())
                {
                    case "fallout4":
                        name = npcName ?? InstructionsManagerHelpers.Fallout4.DefaultNpcName;
                        string systemInstructions = await GetSystemInstructionsAsync(gameName.Trim().ToLower(), name);
                        instructionsBuilder.AppendLine(systemInstructions);
                        instruction.FromSystem = systemInstructions;

                        string userInstructions = await GetUserInstructionsAsync(gameName.Trim().ToLower(), name);
                        instructionsBuilder.AppendLine(userInstructions);
                        instruction.FromUser = userInstructions;
                        break;

                    case "greenhell":
                        name = npcName ?? InstructionsManagerHelpers.GreenHell.DefaultNpcName;
                        string ghsystemInstructions = await GetSystemInstructionsAsync(gameName.Trim().ToLower(), name);
                        instructionsBuilder.AppendLine(ghsystemInstructions);
                        instruction.FromSystem = ghsystemInstructions;

                        string ghuserInstructions = await GetUserInstructionsAsync(gameName.Trim().ToLower(), name);
                        instructionsBuilder.AppendLine(ghuserInstructions);
                        instruction.FromUser = ghuserInstructions;
                        break;

                    case "vamx":
                        name = npcName ?? InstructionsManagerHelpers.VamX.DefaultNpcName;
                        string vsystemInstructions = await GetSystemInstructionsAsync(gameName.Trim().ToLower(), name);
                        instructionsBuilder.AppendLine(vsystemInstructions);
                        instruction.FromSystem = vsystemInstructions;

                        string vuserInstructions = await GetUserInstructionsAsync(gameName.Trim().ToLower(), name);
                        instructionsBuilder.AppendLine(vuserInstructions);
                        instruction.FromUser = vuserInstructions;
                        break;

                    default:
                        break;
                }
                return instruction;
            }
            catch (Exception)
            {
                return instruction;
            }
        }
    }
}
