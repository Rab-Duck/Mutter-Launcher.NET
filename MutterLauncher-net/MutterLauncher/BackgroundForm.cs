using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MutterLauncher
{
    public partial class BackgroundForm : Form
    {
        public Form frmMain { get; set; }
        private MainCollector mc;

        public BackgroundForm(MainForm frmMain)
        {
            InitializeComponent();
            this.frmMain = frmMain;

            // ToDo: 前バージョンの復元
            Properties.Settings.Default.Upgrade();


            mc = new MainCollector(this);
            frmMain.mc = mc;
            mc.setInvoker(collectStateHandler);

        }

        private BackgroundForm()
        {
            
        }

        protected override void OnLoad(EventArgs e)
        {
            Visible = false; // Hide form window.
            ShowInTaskbar = false; // Remove from taskbar.
            Opacity = 0;

            base.OnLoad(e);
        }

        private void collectStateHandler(CollectState state, string msg)
        {
            switch (state)
            {
                case CollectState.START:
                    timerUpdate.Enabled = false;
                    break;
                case CollectState.END:
                    timerUpdate.Enabled = true;
                    break;
                case CollectState.FAILED:
                    break;
                default:
                    break;
            }
        }

        private void timerUpdate_Tick(object sender, EventArgs e)
        {
            Trace.WriteLine("Background Timer Ticked!");
            mc.setEvent();
        }

        private void notifyIconMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (frmMain.Visible)
                {
                    frmMain.Close();
                }
                else
                {
                    frmMain.Show();
                    frmMain.Activate();
                }
            }

        }

        private void BackgroundForm_Load(object sender, EventArgs e)
        {
            mc.run();

            timerUpdate.Interval = Properties.Settings.Default.updateInterval * 60 * 1000;
            timerUpdate.Enabled = true;

        }
    }
}
