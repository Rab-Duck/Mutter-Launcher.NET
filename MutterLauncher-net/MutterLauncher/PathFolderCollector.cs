using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutterLauncher
{
    class PathFolderCollector : AppCollector
    {
        private String[] pathFolders = null;

        public PathFolderCollector()
        {
            pathFolders = Environment.GetEnvironmentVariable("PATH").Split(';');
        }

        private List<Item> items = new List<Item>();

        public void collect()
        {
            items = new List<Item>();
            foreach (String pathFolder in pathFolders)
            {
                try
                {
                    FileCollector fc = new FileCollector(pathFolder, false, null);
                    fc.collect();
                    items.AddRange(fc.getItemList());
                }
                catch (IOException ioex)
                {
                    Trace.WriteLine(pathFolder + ":" + ioex.Message);
                }
            }
        }

        /* 
         * @see AppCollector#getItemList()
         */
        public List<Item> getItemList()
        {
            return items;
        }

    }
}
