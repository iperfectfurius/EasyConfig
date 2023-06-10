using IniParser;
using IniParser.Model;
using System.Diagnostics;
using System.Reflection;

namespace EasyConfig
{
    public class Config
    {
        private readonly string folderApplication = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString();
        private const string CONFIG_NAME = "Config.ini";
        private string? fullPathConfig;
        private IniData? configData;
        private readonly FileIniDataParser iniDataParser = new FileIniDataParser();
        private bool isLoaded = false;
        private Dictionary<(string,string),string> DefaultConfig = null;
        public IniData? ConfigData { get => configData; }

        public Config(string FolderName = "", string ConfigName = CONFIG_NAME, Dictionary<(string, string), string>? defaultConfig = null)
        {
            if (string.IsNullOrWhiteSpace(FolderName)) FolderName = Assembly.GetCallingAssembly().GetName().Name;
            folderApplication += $"\\{FolderName}";
            fullPathConfig = folderApplication + "\\" + ConfigName;

            DefaultConfig = defaultConfig ?? new Dictionary<(string, string), string>();

            LoadConfig();
        }
        private void LoadConfig()
        {
            if (!Directory.Exists(folderApplication)) CreateConfigDirectory();
            if (!File.Exists(fullPathConfig)) CreateConfigFile();

            if (!isLoaded) LoadConfigFile();
        }
        private bool CreateConfigDirectory()
        {
            Directory.CreateDirectory(folderApplication);

            return Directory.Exists(folderApplication);
        }
        private bool CreateConfigFile()
        {
            File.Create(fullPathConfig).Close();

            LoadConfigFile();

            ResetConfig(DefaultConfig);

            return Directory.Exists(folderApplication);
        }

        private bool LoadConfigFile()
        {
            configData = iniDataParser.ReadFile(fullPathConfig);
            isLoaded = true;
            return true;
        }
        public bool ResetConfig(Dictionary<(string, string), string>? defaultConfig = null)
        {
            configData = new IniData();
            if (defaultConfig == null || defaultConfig.Count == 0) return false;

            foreach (KeyValuePair<(string, string), string> entry in defaultConfig)
            {
                (string key1, string key2 ) = (entry.Key.Item1, entry.Key.Item2);
                configData[key1][key2] = entry.Value;
            }

            return true;
        }
        public static void DeleteFileConfig(Config ConfigFile,bool ResetConfigMemory = false)
        {          
            File.Delete(ConfigFile.fullPathConfig);

            if (ResetConfigMemory) ConfigFile.ResetConfig();
        }
        public bool SaveConfig()
        {
            iniDataParser.WriteFile(fullPathConfig, configData);
            return true;
        }
    }
}