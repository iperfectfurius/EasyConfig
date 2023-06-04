using IniParser;
using IniParser.Model;
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
        public IniData? ConfigData { get => configData; }

        public Config(string ProjectName,string ConfigName = CONFIG_NAME)
        {
            if (string.IsNullOrWhiteSpace(ProjectName)) ProjectName = Assembly.GetCallingAssembly().GetName().Name;

            folderApplication += $"\\{ProjectName}" ;
        }
    }
}