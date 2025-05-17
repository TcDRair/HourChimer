namespace HourChimer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip notifyIconMenu;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.components = new System.ComponentModel.Container();
      this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
      this.notifyIconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();

      SuspendLayout();
      // 
      // notifyIconMenu
      // 
      this.notifyIconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
          this.exitMenuItem
      });
      // 
      // exitMenuItem
      // 
      this.exitMenuItem.Text = "종료";
      this.exitMenuItem.Click += (sender, e) => { this.ExitApplication(); };
      // 
      // notifyIcon
      // 
      this.notifyIcon.Icon = SystemIcons.Application;
      this.notifyIcon.Text = "HourChimer";
      this.notifyIcon.Visible = true;
      this.notifyIcon.ContextMenuStrip = this.notifyIconMenu;
      // 
      // Form1
      // 
      AutoScaleDimensions = new SizeF(9F, 20F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(900, 426);
      Name = "Form1";
      Text = "Form1";
      ResumeLayout(false);
    }

    #endregion
  }
}
