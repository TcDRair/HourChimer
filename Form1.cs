#define DEBUG_TICK

namespace HourChimer;

using Microsoft.Toolkit.Uwp.Notifications;

public partial class Form1 : Form
{
  private bool _exitOngoing;
  private int _lastHour = -1;

  public Form1() {
    InitializeComponent();

    Load += Form1_Load;
    FormClosing += Form1_FormClosing;
    ToastNotificationManagerCompat.OnActivated += OnToastActivated;

    hourTimer.Tick += HourTimer_Tick;
    hourTimer.Start();
  }

  private void Form1_Load(object? sender, EventArgs e) {
    // Hide(); // Not working as expected
    ShowInTaskbar = false;
    WindowState = FormWindowState.Minimized;
    Visible = false;
  }

  private void Form1_FormClosing(object? sender, FormClosingEventArgs e) {
    if (_exitOngoing) return;
    e.Cancel = true;
    Hide();
  }

  // Method to be called when the "Exit" menu item (in the notify icon) is clicked
  private void ExitApplication() {
    _exitOngoing = true;
    hourTimer.Stop();
    hourTimer.Tick -= HourTimer_Tick;

    AppSettings.Default.Save();

    Application.Exit();
  }

  private void PostponeTimer(bool active = true) {
    // Default setting : restart next Monday 5 AM
    var daysUntilMonday = ((int)DayOfWeek.Monday - (int)DateTime.Now.DayOfWeek + 7) % 7;
    AppSettings.Default.PostponedTime = active
      ? DateTime.Now.Date.AddDays(daysUntilMonday + 7).AddHours(5)
      : DateTime.MinValue;
    AppSettings.Default.Save();
  }

  private void OnToastActivated(ToastNotificationActivatedEventArgsCompat e) {
    var args = ToastArguments.Parse(e.Argument);

    if (args.TryGetValue("action", out var action) && action == "postpone")
      // UI 스레드에서 실행
      Invoke(() => {
        postponeMenuItem.Checked = true;
        PostponeTimer();
      });
  }

  private void HourTimer_Tick(object? sender, EventArgs e) {
    var now = DateTime.Now;

    if (now >= AppSettings.Default.PostponedTime && postponeMenuItem.Checked)
      postponeMenuItem.Checked = false;

#if DEBUG_TICK
    if (now.Second % 10 != 0
        || now < AppSettings.Default.PostponedTime) return;
#else
    if (now is not { Second: 0, Minute: 0 }
        || now.Hour == _lastHour
        || now < AppSettings.Default.PostponedTime) return;
    _lastHour = now.Hour;
#endif

    new ToastContentBuilder()
      .AddText("정각 알림")
      .AddText(GetNotifyMessage(now))
      .AddButton(new ToastButton()
        .SetContent("이번 주는 알림 없음")
        .AddArgument("action", "postpone"))
      .SetToastDuration(ToastDuration.Short)
      .Show();
  }


  private static string GetNotifyMessage(DateTime time) {
    var hour = time.Hour;
    var amPm = hour < 12 ? "오전" : "오후";
    var hour12 = hour % 12 == 0 ? "12" : $"{hour % 12}";
    return $"{amPm} {hour12}시 정각입니다.";
  }
}