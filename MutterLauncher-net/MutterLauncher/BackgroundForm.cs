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
        public MainForm frmMainForm { get; set; }
        private MainCollector mc;
        private Hotkey hk;

        public BackgroundForm()
        {
            InitializeComponent();

            // ToDo: 前バージョンの復元
            Properties.Settings.Default.Upgrade();


            mc = new MainCollector(this);
            // InitMainForm(false);
            mc.setInvoker(collectStateHandler);

        }

        private void InitMainForm(bool show)
        {
            if (frmMainForm == null || frmMainForm.IsDisposed)
            {
                frmMainForm = new MainForm(mc);
            }

            if (show)
            {
                frmMainForm.Show();
                frmMainForm.Activate();
            }
        }

        private void CloseMainForm()
        {
            frmMainForm.Close();
            frmMainForm = null;
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
            Debug.WriteLine("called BackgroundForm.collectStateHandler():" + state + ", " + msg);
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
                if (frmMainForm != null &&  frmMainForm.Visible)
                {
                    CloseMainForm();
                }
                else
                {
                    InitMainForm(true);
                }
            }

        }

        private void BackgroundForm_Load(object sender, EventArgs e)
        {
            mc.run();

            timerUpdate.Interval = Properties.Settings.Default.updateInterval * 60 * 1000;
            timerUpdate.Enabled = true;

            hk = new Hotkey();
            hk.KeyCode = (Keys)Properties.Settings.Default.HotKeyCode;
            hk.Windows = Properties.Settings.Default.HotKeyWin;
            hk.Alt = Properties.Settings.Default.HotKeyAlt;
            hk.Control = Properties.Settings.Default.HotKeyCtrl;
            hk.Shift = Properties.Settings.Default.HotKeyShift;

            hk.Pressed += (objSender, ea) => { this.InitMainForm(true); };

            if (!hk.GetCanRegister(this))
            {
                MessageBox.Show("Can't register Hot-Key", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                hk.Register(this);
            }

        }

        private void BackgroundForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (hk.Registered)
            {
                hk.Unregister();
            }
            if (frmMainForm != null && !frmMainForm.IsDisposed)
            {
                CloseMainForm();
            }
        }

        private void BackgroundForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            mc.removeInvoker(collectStateHandler);
        }
    }
}
