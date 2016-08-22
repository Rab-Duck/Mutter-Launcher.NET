using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MutterLauncher
{
    public enum CollectState
    {
        IDLE = 0,
        START = 10,
        RUNNING = 15,
        END = 20,
        FAILED = -1,
    }


    public class MainCollector
    {
        private static Object syncStoreItem = new Object();
        private static Object syncStoreHistory = new Object();

        private Object syncItem = new Object();
        private List<Item> itemList = new List<Item>();
        private List<Item> historyItemList;
        private EnvManager envmngr = EnvManager.getInstance();

        private Task taskCollect;
        private AutoResetEvent autoEvent = new AutoResetEvent(true);

        public delegate void MultiInvoker(CollectState type, string msg);
        private volatile MultiInvoker multiInvoker;
        private Form frmCtrl;
        private volatile CollectState _state = CollectState.IDLE;
        public CollectState state { get { return _state; } set { _state = value; } }
       
        public MainCollector(Form frmCtrl)
        {
            this.frmCtrl = frmCtrl;
            cachedCollect();
        }

        public void cachedCollect()
        {
            itemList = envmngr.getItemList();
        }

        public void run()
        {
            taskCollect = Task.Run(() => {
                while (true)
                {
                    autoEvent.WaitOne();
                    try
                    {
                        state = CollectState.RUNNING;
                        frmCtrl.Invoke(multiInvoker, new object[] { CollectState.START, "START" });
                        collect();
                        state = CollectState.END;
                        frmCtrl.Invoke(multiInvoker, new object[] { CollectState.END, "END" });
                    }
                    catch (Exception ex)
                    {
                        state = CollectState.FAILED;
                        frmCtrl.Invoke(multiInvoker, new object[] { CollectState.FAILED,  ex.Message });
                        Trace.WriteLine(ex.Message + "\n" + ex.StackTrace);
                    }
                    autoEvent.Reset();
                }
            });
    
        }

        public void setEvent()
        {
            autoEvent.Set();
        }

        public void setInvoker(MultiInvoker invoker)
        {
            multiInvoker += invoker;
        }

        public void removeInvoker(MultiInvoker invoker)
        {
            multiInvoker -= invoker;
        }

        public void collect()
        {
            List<AppCollector> listApp = new List<AppCollector>();
            string[] collectors = { "MutterLauncher.SHFolderCollector", "MutterLauncher.PathFolderCollector"};
            foreach (string collector in collectors)
            {
                listApp.Add((AppCollector)Activator.CreateInstance(Type.GetType(collector)));
            }

            /*
            foreach (AppCollector app in listApp)
            {
                app.collect();
            }
            */
            Parallel.ForEach(listApp, app =>
            {
                app.collect();
            });

            lock (syncItem)
            {
                itemList = null;
                itemList = new List<Item>();
                foreach (AppCollector app in listApp)
                {
                    itemList.AddRange(app.getItemList());
                }
                envmngr.setItemList(itemList);
            }
            historyItemList = null;

            listApp = null;
        }


        public List<Item> getAllItemList()
        {
            List<Item> allItemList = new List<Item>();
            if (historyItemList == null)
            {
                lock(syncStoreHistory) {
                    // historyItemList = envmngr.getExecHistory();
                }
            }
            // allItemList.AddRange(historyItemList);
            lock (syncItem)
            {
                allItemList.AddRange(itemList);
            }

            return allItemList;
        }

        public List<Item> grep(String grepStr)
        {

            if (grepStr == null || grepStr == "")
            {
                return getAllItemList();
            }

            List<Item> grepList = new List<Item>();

            if (historyItemList == null)
            {
                lock(syncStoreHistory) {
                    // historyItemList = envmngr.getExecHistory();
                }
            }
            // historyItemList.stream()
            // .filter(item-> { return item.getItemName().toUpperCase(Locale.JAPANESE).contains(grepStr.toUpperCase(Locale.JAPANESE)); })
            // .forEach(item-> { grepList.add(item); });

            IEnumerable<Item> grepQuery;
            lock (syncItem)
            {
                grepQuery =
                from item in itemList
                where item.getItemName().ToUpper().Contains(grepStr.ToUpper())
                select item;
            }
            
            grepList.AddRange(grepQuery);

            return grepList;
        }


#if false
    public boolean cachedCollect()
        {
            List<Item> cachedItemList = envmngr.getItemList();
            if (cachedItemList == null)
            {
                return false;
            }
            itemList = cachedItemList;
            return true;
        }


        public void setExecHistory(Item execItem)
        {
            final int historyMax = envmngr.getIntProperty("HistoryMax");

            Item historyItem = execItem.copy();
            historyItem.setType(Item.TYPE_HISTORY);
            historyItemList.add(0, historyItem);

            int i = 0;
            for (Iterator<Item> iterator = historyItemList.iterator(); iterator.hasNext(); i++)
            {
                Item itrItem = (Item)iterator.next();
                if (i >= historyMax || (i != 0 && itrItem.historyEquals(execItem)))
                {
                    iterator.remove();
                    i--;
                }
            }

            synchronized(syncObj) {
                envmngr.setExecHistory(historyItemList);
            }

#endif
    }
}
