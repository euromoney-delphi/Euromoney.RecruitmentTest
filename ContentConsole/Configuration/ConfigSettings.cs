using System.Configuration;

namespace ContentConsole.Configuration
{
    public static class ConfigSettings
    {
        private const string FilterWordsRepoFilePathAppSettingKey = "FilterWordsRepoFilePath";
        public static string FilterBadWordsRepoFilePath => ConfigurationManager.AppSettings.Get(FilterWordsRepoFilePathAppSettingKey);
    }
}
