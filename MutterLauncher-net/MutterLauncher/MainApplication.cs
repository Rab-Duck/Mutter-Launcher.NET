using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MutterLauncher
{
    class MainApplication
    {
        // reference: https://msdn.microsoft.com/ja-jp/library/754w18dd(v=vs.110).aspx
        //            http://dobon.net/vb/dotnet/form/hideformwithtrayicon.html#section3
        [STAThread]
        public static void Main()
        {
            MainForm frmMainForm = new MainForm();

            Application.EnableVisualStyles();
            // Application.SetCompatibleTextRenderingDefault(false);

            Application.Run();

        }
    }
}
