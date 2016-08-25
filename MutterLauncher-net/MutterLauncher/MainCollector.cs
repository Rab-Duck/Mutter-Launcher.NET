using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
        private List<Item> historyItemList = null;
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
            historyItemList = envmngr.getExecHistory();
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
            string[] collectors = { "MutterLauncher.SHFolderCollector", "MutterLauncher.PathFolderCollector", "MutterLauncher.ControlPanelCollector"};
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
            // historyItemList = null;

            listApp = null;
        }


        public List<Item> getAllItemList()
        {
            List<Item> allItemList = new List<Item>();

            allItemList.AddRange(historyItemList);
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


            IEnumerable<Item> grepQuery;

            grepQuery =
                from item in historyItemList
                where item.getItemName().ToUpper(CultureInfo.CurrentUICulture).Contains(grepStr.ToUpper(CultureInfo.CurrentUICulture))
                select item;
            grepList.AddRange(grepQuery);


            lock (syncItem)
            {
                grepQuery =
                    from item in itemList
                    where item.getItemName().ToUpper(CultureInfo.CurrentUICulture).Contains(grepStr.ToUpper(CultureInfo.CurrentUICulture))
                    select item;
            }
            
            grepList.AddRange(grepQuery);

            return grepList;
        }


        public void setExecHistory(Item execItem)
        {
            int historyMax = Properties.Settings.Default.HistoryMax;


            for (int i = historyItemList.Count - 1; i >= 0; i--)
            {
                if (historyItemList.ElementAt(i).historyEquals(execItem))
                {
                    historyItemList.RemoveAt(i);
                }
            }

            Item historyItem = execItem.cloneItem();
            historyItem.setType(ItemType.TYPE_HISTORY);
            historyItemList.Insert(0, historyItem);

            if (historyItemList.Count > historyMax)
            {
                historyItemList.RemoveRange(historyMax, historyItemList.Count - historyMax);
            }

            envmngr.setExecHistory(historyItemList);
        }
    }
}
