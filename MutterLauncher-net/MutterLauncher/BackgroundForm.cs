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
        private EnvManager em = EnvManager.getInstance();
        private String tooltipText = "";

        public BackgroundForm()
        {
            InitializeComponent();

            // 前バージョンの復元
            if (!Properties.Settings.Default.Upgraded)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.Upgraded = true;
                Properties.Settings.Default.Save();
            }

            mc = new MainCollector(this);
            if (Properties.Settings.Default.KeepAliveWindow)
            {
                InitMainForm(false);
            }
            mc.setInvoker(collectStateHandler);

            em.setNotifier(EnvUpdated);
            tooltipText = notifyIconMain.Text;

        }

        private void InitMainForm(bool show)
        {
            if (frmMainForm == null || frmMainForm.IsDisposed)
                frmMainForm = new MainForm(mc);

            if (show)
            {
                frmMainForm.Show();
                frmMainForm.Activate();
            }
        }

        private void CloseMainForm()
        {
            frmMainForm.Close();
            if (!Properties.Settings.Default.KeepAliveWindow)
            {
                frmMainForm = null;
            }
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
                    timerUpdate.Stop();
                    miUpdate.Enabled = false;
                    notifyIconMain.Icon = Properties.Resources.RefreshIco;
                    break;
                case CollectState.END:
                    timerUpdate.Start();
                    miUpdate.Enabled = true;
                    notifyIconMain.Icon = Properties.Resources.MutterIco;
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
            if (this.IsDisposed)
            {
                return;
            }
            mc.setEvent();
        }

        private void notifyIconMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                InitMainForm(true);
            }
        }

        private void BackgroundForm_Load(object sender, EventArgs e)
        {
            mc.run();

            timerUpdate.Interval = Properties.Settings.Default.updateInterval * 60 * 1000;
            timerUpdate.Enabled = true;

            RegisterHotKey();

        }

        private void RegisterHotKey()
        {
            hk = new Hotkey();
            hk.KeyCode = (Keys)Properties.Settings.Default.HotKeyCode;
            hk.Windows = Properties.Settings.Default.HotKeyWin;
            hk.Alt = Properties.Settings.Default.HotKeyAlt;
            hk.Control = Properties.Settings.Default.HotKeyCtrl;
            hk.Shift = Properties.Settings.Default.HotKeyShift;
            notifyIconMain.Text = tooltipText + " | " + hk.ToString();

            hk.Pressed += (objSender, ea) => { this.InitMainForm(true); };

            if (!hk.GetCanRegister(this))
            {
                MessageBox.Show(Properties.Resources.ErrRegHotkey, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                hk.Register(this);
            }
        }

        private void BackgroundForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (hk.Registered)
                hk.Unregister();

            if (frmMainForm != null && !frmMainForm.IsDisposed)
                CloseMainForm();

        }

        private void BackgroundForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Debug.WriteLine(this + " closing!");
            mc.removeInvoker(collectStateHandler);
            timerUpdate.Stop();
            timerUpdate.Tick -= new EventHandler(this.timerUpdate_Tick);
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void miUpdate_Click(object sender, EventArgs e)
        {
            Trace.WriteLine("miUpdate Clicked!");
            mc.setEvent();
        }

        private void cmsMain_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            Debug.WriteLine("cmsMain closing!");
        }

        private void cmsMain_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
        }

        private void BackgroundForm_Deactivate(object sender, EventArgs e)
        {
            Debug.WriteLine(this + " de-activated!");
        }

        private void BackgroundForm_Activated(object sender, EventArgs e)
        {
            Debug.WriteLine(this + " activated!");
        }

        private void miSetting_Click(object sender, EventArgs e)
        {
            ShowSettingForm();
        }

        public static void ShowSettingForm()
        {
            SettingForm.ShowSettingForm();
        }

        private void EnvUpdated(bool bReCollect)
        {
            if (hk.Registered)
                hk.Unregister();

            RegisterHotKey();

            timerUpdate.Stop();
            timerUpdate.Interval = Properties.Settings.Default.updateInterval * 60 * 1000;
            timerUpdate.Start();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm.ShowAboutForm();
        }
    }
}
