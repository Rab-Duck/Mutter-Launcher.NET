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
        private string envDir;
        private Object lockItemList = new Object();
        private Object lockHistoryList = new Object();

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
            envDir = Path.GetFullPath(Application.LocalUserAppDataPath + "\\..");
            itemListFilename = envDir + "\\" + itemListFilename;
            historyFilename = envDir + "\\" + historyFilename;
            anyFolderListFilename = envDir + "\\" + anyFolderListFilename;
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

        private void SaveList(List<Item> itemList, string fname)
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

        public string[] getAnyFolderList()
        {
            try
            {
                string [] allLines = File.ReadAllLines(anyFolderListFilename);
                return allLines;
            }
            catch (FileNotFoundException)
            {
                return new string[0];
            }
            catch (Exception e)
            {
                Trace.WriteLine("Cannot read " + anyFolderListFilename + ", " + e.Message + "\n" + e.StackTrace);
                MessageBox.Show("Can't read " + anyFolderListFilename + "\nreason:" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return new String[0];
        }

        public List<Item> getUserItemList()
        {
            List<Item> itemList = new List<Item>();
            itemList.Add(new UserItem("起動", "%1", true, true, false, null));
            itemList.Add(new UserItem("google", "http://www.google.com/search?hl=ja&ie=UTF-8&q=%1", true, false, true, "UTF-8"));
            itemList.Add(new UserItem("netstat", "netstat -rn %1", false, true, false, null));


            return itemList;
        }

    }
}
