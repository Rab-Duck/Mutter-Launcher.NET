using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MutterLauncher
{
    class EnvManager
    {
        private string historyFilename = "HistoryList.bin";
        private string itemListFilename = "ItemList.bin";
        private string anyFolderListFilename = "AnyFolderList.txt";
        private string userItemListFilename = "UserItemList.bin";
        private string searchHistoryFilename = "SearchHistory.bin";
        private string envDir;
        private bool bNeedUpdateList = false;
        private Object lockItemList = new Object();
        private Object lockHistoryList = new Object();
        private Object lockAnyFolerList = new Object();

        public delegate void MultiNotifier(bool bReCollect);
        private MultiNotifier multinotifier;
        private MultiNotifier multinotifierFinished;

        public static EnvManager envmngr;
        public static EnvManager getInstance()
        {
            if (envmngr == null)
            {
                envmngr = new EnvManager();
            }
            return envmngr;
        }

        private EnvManager()
        {
            // reference: https://msdn.microsoft.com/en-us/library/ms134265(v=vs.110).aspx
            System.Configuration.Configuration config =
                System.Configuration.ConfigurationManager.OpenExeConfiguration(
                System.Configuration.ConfigurationUserLevel.PerUserRoamingAndLocal);

            // change to the same (but non-version) dir of user.config
            // envDir = Path.GetFullPath(Application.LocalUserAppDataPath + "\\..");
            envDir = Path.GetFullPath(Path.GetDirectoryName(config.FilePath) + "\\..");

            itemListFilename = envDir + "\\" + itemListFilename;
            historyFilename = envDir + "\\" + historyFilename;
            anyFolderListFilename = envDir + "\\" + anyFolderListFilename;
            userItemListFilename = envDir + "\\" + userItemListFilename;
            searchHistoryFilename = envDir + "\\" + searchHistoryFilename;
        }

        public void setItemList(List<Item> itemList)
        {
            lock (lockItemList)
            {
                SaveList(itemList, itemListFilename);
            }
        }

        public List<Item> getItemList()
        {
            lock (lockItemList)
            {
                return LoadList(itemListFilename);
            }

        }

        public void setExecHistory(List<Item> itemList)
        {
            lock (lockHistoryList)
            {
                SaveList(itemList, historyFilename);
            }
        }

        public List<Item> getExecHistory()
        {
            lock (lockHistoryList)
            {
                return LoadList(historyFilename);
            }
        }

        private void SaveList(object itemList, string fname)
        {
          IFormatter formatter = new BinaryFormatter();
            Stream stream = null;
            try
            {
                stream = new FileStream(fname, FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, itemList);
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message + "\n" + e.StackTrace);
                throw e;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
        }


        private List<Item> LoadList(string fname)
        {
            List<Item> itemList = new List<Item>();
            IFormatter formatter = new BinaryFormatter();
            Stream stream = null;
            try
            {
                stream = new FileStream(fname, FileMode.Open, FileAccess.Read, FileShare.Read);
                itemList = (List<Item>)formatter.Deserialize(stream);
            }
            catch (FileNotFoundException)
            {

            }
            catch (SerializationException)
            {
                // the file may be broken...
                stream.Close();
                stream = null;
                File.Delete(fname);
                itemList = new List<Item>();
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message + "\n" + e.StackTrace);
                throw e;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
            return itemList;
        }

        public void setAnyFolderList(string strAnyFolerList)
        {
            string[] oldValue;
            string[] newValue;
            try
            {
                lock (lockAnyFolerList)
                {
                    oldValue = getAnyFolderList();
                    File.WriteAllText(anyFolderListFilename, strAnyFolerList);
                    newValue = getAnyFolderList();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine("Cannot write " + anyFolderListFilename + ", " + e.Message + "\n" + e.StackTrace);
                MessageBox.Show(Properties.Resources.ErrWrite + anyFolderListFilename + "\nreason:" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!oldValue.SequenceEqual(newValue))
            {
                bNeedUpdateList = true;
            }

            return;
        }

        public string[] getAnyFolderList()
        {
            try
            {
                string[] allLines;
                lock (lockAnyFolerList)
                {
                    allLines = File.ReadAllLines(anyFolderListFilename);
                }
                return allLines;
            }
            catch (FileNotFoundException)
            {
                return new string[0];
            }
            catch (Exception e)
            {
                Trace.WriteLine("Cannot read " + anyFolderListFilename + ", " + e.Message + "\n" + e.StackTrace);
                MessageBox.Show(Properties.Resources.ErrWrite + anyFolderListFilename + "\nreason:" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return new String[0];
        }

        public List<Item> getUserItemList()
        {
            if (!File.Exists(userItemListFilename))
            {
                List<Item> itemList = new List<Item>();
                itemList.Add(new UserItem("Run", "%1", true, true, false, null));
                itemList.Add(new UserItem("Google Search", "http://www.google.com/search?ie=UTF-8&q=%1", true, false, true, "UTF-8"));
                itemList.Add(new UserItem("netstat", "netstat -rn %1", false, true, false, null));
                return itemList;
            }

            return LoadList(userItemListFilename);
        }

        public void setUerItemlist(List<Item> itemList)
        {
            SaveList(itemList, userItemListFilename);
        }

        public void setSearchHistory(string [] items)
        {
            SaveList(items, searchHistoryFilename);
        }

        public string[] getSearchHistory()
        {
            string[] itemList = new string[0];
            IFormatter formatter = new BinaryFormatter();
            Stream stream = null;
            try
            {
                stream = new FileStream(searchHistoryFilename, FileMode.Open, FileAccess.Read, FileShare.Read);
                itemList = (string [])formatter.Deserialize(stream);
            }
            catch (FileNotFoundException)
            {

            }
            catch (SerializationException)
            {
                // the file may be broken...
                stream.Close();
                stream = null;
                File.Delete(searchHistoryFilename);
                itemList = new string[0];
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message + "\n" + e.StackTrace);
                throw e;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
            return itemList;
        }

        public void setNotifier(MultiNotifier notifier)
        {
            multinotifier += notifier;
        }
        public void removeNotifier(MultiNotifier notifier)
        {
            multinotifier -= notifier;
        }
        public void notifyAll()
        {
            multinotifier(bNeedUpdateList);
        }
        public void setNotifyFinished(MultiNotifier notifier)
        {
            multinotifierFinished += notifier;
        }
        public void removeNotifyFinished(MultiNotifier notifier)
        {
            multinotifierFinished -= notifier;
        }
        public void notifyFinishedAll()
        {
            multinotifierFinished(bNeedUpdateList);
            bNeedUpdateList = false;
        }
    }
}
