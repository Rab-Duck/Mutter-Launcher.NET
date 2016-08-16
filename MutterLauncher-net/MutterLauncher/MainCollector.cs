using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutterLauncher
{
    class MainCollector
    {
        private static Object syncStoreItem = new Object();
        private static Object syncStoreHistory = new Object();

        private Object syncItem = new Object();
        private List<Item> itemList = new List<Item>();
        private List<Item> historyItemList;

        public MainCollector()
        {
        }

        public void collect()
        {

            List<AppCollector> listApp = new List<AppCollector>();
            string[] collectors = { "MutterLauncher.SHFolderCollector", "MutterLauncher.PathFolderCollector"};
            foreach (string collector in collectors)
            {
                listApp.Add((AppCollector)Activator.CreateInstance(Type.GetType(collector)));
            }

            foreach (AppCollector app in listApp)
            {
                app.collect(); ;
            }

            lock (syncItem)
            {
                itemList = null;
                itemList = new List<Item>();
                foreach (AppCollector app in listApp)
                {
                    itemList.AddRange(app.getItemList());
                }
            }
            storeItemList();
            historyItemList = null;

            listApp = null;
        }

        private void storeItemList()
        {
            lock (syncStoreItem)
            {
                // todo
            }
            return;
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
            lock (syncStoreItem)
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
