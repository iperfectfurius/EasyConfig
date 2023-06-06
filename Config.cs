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
        private Dictionary<(string,string),string> DefaultConfig;
        public IniData? ConfigData { get => configData; }

        public Config(string ProjectName, string ConfigName = CONFIG_NAME, Dictionary<(string, string), string> defaultConfig = null)
        {
            if (string.IsNullOrWhiteSpace(ProjectName)) ProjectName = Assembly.GetCallingAssembly().GetName().Name;
            folderApplication += $"\\{ProjectName}";
            fullPathConfig = folderApplication + "\\" + CONFIG_NAME;

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
        public bool ResetConfig(Dictionary<(string, string), string> defaultConfig = null)
        {
            if (defaultConfig == null) return false;

            foreach (var key in defaultConfig.Keys)
            {
                foreach (var value in defaultConfig[key])
                {
                    Debug.WriteLine(defaultConfig[key][value]);
                }
            }
            //foreach (KeyValuePair<(string, string),string> entry in defaultConfig)
            //{


            //        configData[entry.Key][entry.Value] = defaultConfig[entry.Key,entry.Value];
            //}
            return true;
        }
    }
}