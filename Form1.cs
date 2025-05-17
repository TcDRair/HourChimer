#define HOURCHIMER_DEBUG // DEBUG_MODE

namespace HourChimer
{
  public partial class Form1 : Form
  {
    public Form1() {
      InitializeComponent();
      this.FormClosing += Form1_FormClosing;
      this.hourTimer.Tick += HourTimer_Tick;
      this.hourTimer.Start();
    }

    private bool reallyClose = false;
    private int lastHour = -1;

    private void Form1_FormClosing(object? sender, FormClosingEventArgs e) {
      if (!reallyClose) {
        e.Cancel = true;
        this.Hide();
      }
    }

    // "종료" 메뉴에서 호출할 메서드
    public void ExitApplication() {
      reallyClose = true;
      Application.Exit();
    }


    private void HourTimer_Tick(object? sender, EventArgs e) {
      var now = DateTime.Now;
      if (
#if HOURCHIMER_DEBUG
        now.Second % 10 == 0
#else
        now.Second == 0 && now.Minute == 0 && now.Hour != lastHour
#endif
        ) {
        lastHour = now.Hour;
        notifyIcon.ShowBalloonTip(
          5000, // milliseconds
          "정각 알림",
          DefaultNotifyMessage(now),
          ToolTipIcon.Info
        );
      }

      static string DefaultNotifyMessage(DateTime time) {
        var hour = time.Hour;
        string AM_PM = (hour < 12) ? "오전" : "오후";
        string hourString = (hour % 12 == 0) ? "12" : $"{hour % 12}";
        return $"{AM_PM} {hourString}시 정각입니다.";
      }
    }
  }
}
