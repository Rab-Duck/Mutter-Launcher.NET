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

            Hotkey hk = new Hotkey();
            hk.KeyCode = Keys.C;
            hk.Windows = true;
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

            if (hk.Registered)
            {
                hk.Unregister();
            }
        }
    }
}
