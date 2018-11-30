// Helpers/Settings.cs
using Mugelli.Software.It.Mgc.Extensions;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Mugelli.Software.It.Mgc.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;



        #region Setting Constants

        private const string SettingsKey = "settings_key";
        private static readonly string SettingsDefault = string.Empty;

        #endregion


        public static string GeneralSettings
        {
            get => AppSettings.GetValueOrDefault(nameof(GeneralSettings), SettingsDefault);
            set => AppSettings.AddOrUpdateValue(nameof(GeneralSettings), value);
        }

        public static string PayloadType
        {
            get => AppSettings.GetValueOrDefault(nameof(PayloadType), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(PayloadType), value);
        }

        public static string PayloadId
        {
            get => AppSettings.GetValueOrDefault(nameof(PayloadId), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(PayloadId), value);
        }
    }
}