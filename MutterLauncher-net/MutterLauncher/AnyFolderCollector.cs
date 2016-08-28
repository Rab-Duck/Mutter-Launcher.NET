using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutterLauncher
{
    class AnyFolderCollector : AppCollector
    {
        private String[] anyFolders = null;
        private EnvManager envmngr = EnvManager.getInstance();

        public AnyFolderCollector()
        {
            anyFolders = envmngr.getAnyFolderList();
        }

        private List<Item> items;
        void AppCollector.collect()
        {
            items = new List<Item>();
            string[] pathargs;
            string pathExt;
            foreach (string anyFolder in anyFolders)
            {
                try
                {
                    pathargs = anyFolder.Split(new char[]{';'}, 2);
                    if (pathargs.Length < 2 || String.IsNullOrEmpty(pathargs[1]))
                    {
                        pathExt = null;
                    }
                    else
                    {
                        pathExt = pathargs[1];
                    }
                    FileCollector fc = new FileCollector(pathargs[0], true, pathExt);
                    fc.collect();
                    items.AddRange(fc.getItemList());
                }
                catch (System.IO.IOException ioe)
                {
                    Trace.WriteLine("Any Folder not exists: " + anyFolder + ", " + ioe.Message);
                }
            }
        }

        List<Item> AppCollector.getItemList()
        {
            return items;
        }
    }
}
