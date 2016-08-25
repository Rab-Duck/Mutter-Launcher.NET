using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shell32;
using System.Diagnostics;

namespace MutterLauncher
{
    class ControlPanelCollector : AppCollector
    {
        private List<Item> items = new List<Item>();

        void AppCollector.collect()
        {
            // [STAThread] でないと、この↓書き方ではダメ
            // Shell shell = new Shell();
            // Folder folder = shell.NameSpace("::{21EC2020-3AEA-1069-A2DD-08002B30309D}");
            // これは別スレッドで走るので、
            // reference: http://detail.chiebukuro.yahoo.co.jp/qa/question_detail/q13163101003
            //            http://stackoverflow.com/questions/12075188/reference-a-windows-shell-interface-using-net-4-0
            var shellAppType = Type.GetTypeFromProgID("Shell.Application");
            if (shellAppType == null)
            {
                return;
            }
            dynamic shell = Activator.CreateInstance(shellAppType);
            Folder folder = shell.NameSpace("::{21EC2020-3AEA-1069-A2DD-08002B30309D}");
            if (folder == null)
            {
                return;
            }

            items.Clear();
            foreach (FolderItem item in folder.Items())
            {
                if (item.Name == "")
                {
                    continue;
                }
                items.Add(new FileItem(item.Path, item.Name));
                Debug.WriteLine("match:" + item.Name + ", " + item.Path);
            }

            folder = null;
            shell = null;
        }

        List<Item> AppCollector.getItemList()
        {
            return items;
        }
    }
}
