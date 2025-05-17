using System;
using System.Windows.Forms;

namespace HourChimer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;
        }

        private bool reallyClose = false;

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!reallyClose)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        // "종료" 메뉴에서 호출할 메서드
        public void ExitApplication()
        {
            reallyClose = true;
            Application.Exit();
        }
    }
}
