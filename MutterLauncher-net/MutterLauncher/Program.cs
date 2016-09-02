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
            frmBackground = new BackgroundForm();
            //frmMainForm.Show();
            frmBackground.Show();


            Application.Run();

            frmBackground.Close();

        }

        private static BackgroundForm frmBackground;
        public static void EnvUpdated()
        {
            if (frmBackground != null && !frmBackground.IsDisposed)
            {
                frmBackground.EnvUpdated();
            }
        }
    }
}
