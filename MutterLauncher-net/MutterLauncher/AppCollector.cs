using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutterLauncher
{
    interface AppCollector
    {
        void collect();
        List<Item> getItemList();
    }
}
