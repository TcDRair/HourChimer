namespace HourChimer;

using System.Configuration;

public sealed class AppSettings : ApplicationSettingsBase
{
  private static AppSettings? _defaultInstance;

  public static AppSettings Default {
    get {
      _defaultInstance ??= new AppSettings();
      return _defaultInstance;
    }
  }

  [UserScopedSetting]
  [DefaultSettingValue("0001-01-01")]
  public DateTime PostponedTime {
    get => (DateTime)(this[nameof(PostponedTime)] ?? DateTime.MinValue);
    set => this[nameof(PostponedTime)] = value;
  }
}