// Helpers/Settings.cs
using Mugelli.Software.It.Mgc.MessagingCenters;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using Mugelli.Software.It.Mgc.Extensions;

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
			get => AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
			set => AppSettings.AddOrUpdateValue(SettingsKey, value);
		}

        public static string PayloadId
        {
            get => AppSettings.GetValueOrDefault(PayloadId, string.Empty);
            set => AppSettings.AddOrUpdateValue(PayloadId, value);
        }

        public static string PayloadType
        {
            get => AppSettings.GetValueOrDefault(PayloadId, string.Empty);
            set => AppSettings.AddOrUpdateValue(PayloadId, value);
        }

        public static PayloadMessage Payload
        {
            get => AppSettings.GetValueOrDefault(PayloadId, default(PayloadMessage));
            set => AppSettings.AddOrUpdateValue(PayloadId, value);
        }
    }
}