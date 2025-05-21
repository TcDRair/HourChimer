using System.IO;
using System.Drawing;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;

namespace HourChimer
{
  partial class Form1
  {
    private IContainer components = null;
    private NotifyIcon notifyIcon;
    private ContextMenuStrip notifyIconMenu;
    private ToolStripMenuItem titleMenuItem, exitMenuItem;
    private System.Windows.Forms.Timer hourTimer;

    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
        components.Dispose();
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent() {
      this.components = new System.ComponentModel.Container();
      this.notifyIcon = new NotifyIcon(this.components);
      this.notifyIconMenu = new ContextMenuStrip(this.components);
      this.titleMenuItem = new ToolStripMenuItem();
      this.exitMenuItem = new ToolStripMenuItem();
      this.hourTimer = new System.Windows.Forms.Timer(this.components);

      SuspendLayout();
      Name = "HourChimer";
      Text = "HourChimer";
      // System tray icon is same as the executable file icon
      this.notifyIcon.Icon = Icon.ExtractAssociatedIcon(Process.GetCurrentProcess().MainModule.FileName);
      this.notifyIcon.Visible = true;
      this.notifyIcon.Text = "HourChimer";
      this.notifyIcon.ContextMenuStrip = this.notifyIconMenu;
      this.notifyIconMenu.Items.Add(this.titleMenuItem);
      this.notifyIconMenu.Items.Add(this.exitMenuItem);
      this.titleMenuItem.Text = "HourChimer v1.0";
      this.titleMenuItem.Enabled = false;
      this.exitMenuItem.Text = "종료";
      this.exitMenuItem.Click += (sender, e) => { this.ExitApplication(); };
      this.hourTimer.Interval = 1000; // 1 second
      AutoScaleDimensions = new SizeF(9F, 20F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(900, 426);
      ResumeLayout(false);
    }
    #endregion
  }
}
