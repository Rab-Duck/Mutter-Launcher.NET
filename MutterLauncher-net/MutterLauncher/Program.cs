using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MutterLauncher
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        // reference: https://msdn.microsoft.com/ja-jp/library/754w18dd(v=vs.110).aspx
        //            http://dobon.net/vb/dotnet/form/hideformwithtrayicon.html#section3
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm frmMainForm = new MainForm();
            BackgroundForm frmBackground = new BackgroundForm(frmMainForm);
            //frmMainForm.Show();
            frmBackground.Show();

            Hotkey hk = new Hotkey();
            hk.KeyCode = (Keys)Properties.Settings.Default.HotKeyCode;
            hk.Windows = Properties.Settings.Default.HotKeyWin;
            hk.Alt = Properties.Settings.Default.HotKeyAlt;
            hk.Control = Properties.Settings.Default.HotKeyCtrl;
            hk.Shift = Properties.Settings.Default.HotKeyShift;

            hk.Pressed += (sender, e) => { frmMainForm.Show(); frmMainForm.Activate(); };

            if (!hk.GetCanRegister(frmMainForm))
            {
                MessageBox.Show("Can't register Hot-Key", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                hk.Register(frmMainForm);
            }

            Application.Run();

            frmMainForm.Close();
            frmBackground.Close();

            if (hk.Registered)
            {
                hk.Unregister();
            }
        }
    }
}
