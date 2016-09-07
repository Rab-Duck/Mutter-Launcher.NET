using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
            Mutex mutex;
            bool bNew;
            try
            {
                mutex = new Mutex(true, "Mutter Launcher .NET", out bNew);
                if (!bNew)
                {
                    MessageBox.Show(Properties.Resources.ErrDuplexRun);
                    return;
                }
            }
            catch (Exception ex)
            {
                if (ex is WaitHandleCannotBeOpenedException ||
                    ex is UnauthorizedAccessException)
                {
                    MessageBox.Show(Properties.Resources.ErrDuplexRun);
                }
                throw ex;
            }


            // reference: http://urashita.com/archives/3521
            // System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmBackground = new BackgroundForm();
            //frmMainForm.Show();
            frmBackground.Show();


            Application.Run();

            frmBackground.Close();

            mutex.ReleaseMutex();
            mutex.Close();
        }

        private static BackgroundForm frmBackground;
    }
}
