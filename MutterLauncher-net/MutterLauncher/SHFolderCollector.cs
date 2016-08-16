using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MutterLauncher
{
    class SHFolderCollector : AppCollector
    {
        private String[] shFolders;

        public SHFolderCollector()
        {
            Environment.SpecialFolder[] sfs = {
                Environment.SpecialFolder.CommonStartMenu,
                Environment.SpecialFolder.StartMenu,
                Environment.SpecialFolder.CommonDesktopDirectory,
                Environment.SpecialFolder.Desktop,
                Environment.SpecialFolder.Favorites,
                // Environment.SpecialFolder.Recent,
            };
            shFolders = new String[sfs.Length];
            for (int i = 0; i < sfs.Length; i++)
            {
                shFolders[i] = Environment.GetFolderPath(sfs[i]);
            }
        }

        private List<Item> items = new List<Item>();

        public void collect()
        {
            items = new List<Item>();
            foreach (String shFolder in shFolders)
            {
                try
                {
                    FileCollector fc = new FileCollector(shFolder, true, "*");
                    fc.collect();
                    items.AddRange(fc.getItemList());
                }
                catch (IOException ioex)
                {
                    Trace.WriteLine(shFolder + ":" + ioex.Message);
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
