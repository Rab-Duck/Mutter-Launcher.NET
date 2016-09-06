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
                    MessageBox.Show("Mutter Launcher .NET is already running.");
                    return;
                }
            }
            catch (Exception ex)
            {
                if (ex is WaitHandleCannotBeOpenedException ||
                    ex is UnauthorizedAccessException)
                {
                    MessageBox.Show("Mutter Launcher .NET is already running.");
                }
                throw ex;
            }

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
